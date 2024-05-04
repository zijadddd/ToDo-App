using Microsoft.AspNetCore.Mvc;
using todo_be.Services.Interfaces;

namespace todo_be.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ToDoController : ControllerBase {
    private readonly IToDoService _toDoService;

    public ToDoController(IToDoService toDoService) {
        _toDoService = toDoService;
    }
}
