using todo_be.Database;
using todo_be.Models.DTOs.In;
using todo_be.Models.DTOs.Out;
using todo_be.Services.Interfaces;

namespace todo_be.Services.Implementations;
public class ToDoService : IToDoService {
    private readonly DatabaseContext _databaseContext;

    public ToDoService(DatabaseContext databaseContext) {
        _databaseContext = databaseContext;
    }

    public Task<ToDoOut> CreateToDo(int userId, ToDoIn request) {
        throw new NotImplementedException();
    }

    public Task<string> DeleteToDo(int id) {
        throw new NotImplementedException();
    }

    public Task<List<ToDoOut>> GetAllToDos() {
        throw new NotImplementedException();
    }

    public Task<ToDoOut> GetToDo(int id) {
        throw new NotImplementedException();
    }

    public Task<ToDoOut> UpdateToDo(int userId, ToDoIn request) {
        throw new NotImplementedException();
    }
}
