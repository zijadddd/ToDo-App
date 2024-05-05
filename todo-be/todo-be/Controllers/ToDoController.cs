using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using todo_be.Models.DAOs;
using todo_be.Models.DTOs.Out;
using todo_be.Services.Interfaces;

namespace todo_be.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ToDoController : ControllerBase {
    private readonly IToDoService _toDoService;

    public ToDoController(IToDoService toDoService) {
        _toDoService = toDoService;
    }

    [HttpGet, Authorize(Roles = "User, Admin")]
    public async Task<ActionResult<ToDoOut>> GetAllToDos() {
        return Ok("Ok");
    }
}
