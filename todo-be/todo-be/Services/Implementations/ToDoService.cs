using Microsoft.EntityFrameworkCore;
using todo_be.Database;
using todo_be.Exceptions;
using todo_be.Models.DAOs;
using todo_be.Models.DTOs.InModels;
using todo_be.Models.DTOs.OutModels;
using todo_be.Services.Interfaces;

namespace todo_be.Services.Implementations;
public sealed class ToDoService : IToDoService {
    private readonly DatabaseContext _databaseContext;

    public ToDoService(DatabaseContext databaseContext) {
        _databaseContext = databaseContext;
    }

    public Task<ToDoOut> CreateToDo(string username, ToDoIn request) {
        throw new NotImplementedException();
    }

    public Task<string> DeleteToDo(int id) {
        throw new NotImplementedException();
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

    public async Task<ToDoOut> GetToDo(string username, int id) {
        throw new NotImplementedException();
    }

    public Task<ToDoOut> UpdateToDo(ToDoIn request) {
        throw new NotImplementedException();
    }
}
