﻿using todo_be.Models.DTOs.In;
using todo_be.Models.DTOs.Out;

namespace todo_be.Services.Interfaces;
public interface IToDoService {
    Task<List<ToDoOut>> GetAllToDos(string username);
    Task<ToDoOut> GetToDo(string username, int id);
    Task<ToDoOut> CreateToDo(int userId, ToDoIn request);
    Task<ToDoOut> UpdateToDo(int userId, ToDoIn request);
    Task<string> DeleteToDo(int id);
}
