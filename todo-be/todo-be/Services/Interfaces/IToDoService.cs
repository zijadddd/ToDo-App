using todo_be.Models.DTOs.In;
using todo_be.Models.DTOs.Out;

namespace todo_be.Services.Interfaces;
public interface IToDoService {
    Task<List<ToDoOut>> GetAllToDos();
    Task<ToDoOut> GetToDo(int id);
    Task<ToDoOut> CreateToDo(ToDoIn request);
    Task<ToDoOut> UpdateToDo(ToDoIn request);
    Task<string> DeleteToDo(int id);
}

