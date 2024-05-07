using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using todo_be.Models.DAOs;
using todo_be.Models.DTOs.OutModels;
using todo_be.Services.Interfaces;

namespace todo_be.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class ToDoController : ControllerBase {
    private readonly IToDoService _toDoService;

    public ToDoController(IToDoService toDoService) {
        _toDoService = toDoService;
    }

    [HttpGet, Authorize(Roles = "User, Admin")]
    public async Task<ActionResult<ToDoOut>> GetAllToDos() {
        try {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;

            var username = tokenS.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;

            var toDos = await _toDoService.GetAllToDos(username);

            return Ok(toDos);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}
