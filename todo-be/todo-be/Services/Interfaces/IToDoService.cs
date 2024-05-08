using todo_be.Models.DTOs.InModels;
using todo_be.Models.DTOs.OutModels;

namespace todo_be.Services.Interfaces;
public interface IToDoService {
    Task<List<ToDoOut>> GetAllToDos(string username);
    Task<ToDoOut> GetToDo(int id);
    Task<ToDoOut> CreateToDo(string username, ToDoIn request);
    Task<ToDoOut> UpdateToDo(ToDoIn request);
    Task<string> DeleteToDo(int id);
}

