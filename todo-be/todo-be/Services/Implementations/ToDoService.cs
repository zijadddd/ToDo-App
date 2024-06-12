using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using todo_be.Database;
using todo_be.Exceptions;
using todo_be.Models.DAOs;
using todo_be.Models.DTOs.InModels;
using todo_be.Models.DTOs.OutModels;
using todo_be.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace todo_be.Services.Implementations;
public sealed class ToDoService : IToDoService {
    private readonly DatabaseContext _databaseContext;

    public ToDoService(DatabaseContext databaseContext) {
        _databaseContext = databaseContext;
    }

    public async Task<ToDoOut> CreateToDo(string username, ToDoIn request) {
        var userAuth = await _databaseContext.UsersAuths.FirstOrDefaultAsync(user => user.UserName.Equals(username));
        if (userAuth is null) throw new UserWithUserNameNotFoundException(username);

        var user = await _databaseContext.Users.FirstOrDefaultAsync(user => user.Id == userAuth.UserId);
        if (user is null) throw new UserWithUserNameNotFoundException(username);

        ToDo toDo = new ToDo {
            Title = request.Title,
            Description = request.Description,
            Created = DateTime.UtcNow,
            User = user
        };

        try {
            _databaseContext.Add(toDo);
            await _databaseContext.SaveChangesAsync();

            return new ToDoOut(toDo.Id, toDo.Title, toDo.Description, toDo.Created, toDo.Modified, username);
        } catch (Exception ex) {
            throw new ToDoNotCreatedException();
        }
    }

    public async Task<string> DeleteToDo(int id) {
        ToDo toDo = await _databaseContext.ToDos.FirstOrDefaultAsync(td => td.Id == id);
        if (toDo is null) throw new ToDoNotFoundException();
        
        try {
            _databaseContext.ToDos.Remove(toDo);
            await _databaseContext.SaveChangesAsync();
        } catch (Exception ex) {
            throw new ToDoNotDeletedException(id);
        }

        return $"ToDo with id {id} has been successfully deleted.";
    }

    public async Task<List<ToDoOut>> GetAllToDos(string username) {
        UserAuth userAuth = await _databaseContext.UsersAuths.FirstOrDefaultAsync(ua => ua.UserName.Equals(username));
        if (userAuth is null) throw new UserWithUserNameNotFoundException(username);

        List<ToDo> toDos = await _databaseContext.ToDos.Where(td => td.UserId == userAuth.UserId).ToListAsync();
        if (toDos.Count == 0) throw new ToDosForUserNotFoundException(username);

        List<ToDoOut> toDosOut = new List<ToDoOut>();

        foreach (var toDo in toDos) 
            toDosOut.Add(new ToDoOut(toDo.Id, toDo.Title, toDo.Description, toDo.Created, toDo.Modified, username));

        return toDosOut;
    }

    public async Task<ToDoOut> GetToDo(int id) {
        var toDo = await _databaseContext.ToDos.FirstOrDefaultAsync(td => td.Id == id);
        if (toDo is null) throw new ToDoNotFoundException();

        var userAuth = await _databaseContext.UsersAuths.FirstOrDefaultAsync(u => u.UserId == toDo.UserId);

        ToDoOut toDoOut = new ToDoOut(toDo.Id,
            toDo.Title,
            toDo.Description,
            toDo.Created,
            toDo.Modified,
            userAuth.UserName ?? "Unknown");

        return toDoOut;
    }

    public Task<ToDoOut> UpdateToDo(ToDoIn request) {
        throw new NotImplementedException();
    }
}
