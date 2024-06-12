using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using todo_be.Models.DTOs.InModels;
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
    public async Task<ActionResult<List<ToDoOut>>> GetAllToDos() {
        try {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;

            var username = tokenS.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;

            var response = await _toDoService.GetAllToDos(username);

            return Ok(response);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}"), Authorize(Roles = "User, Admin")]
    public async Task<ActionResult<ToDoOut>> GetAnToDo(int id) {
        try {
            var response = await _toDoService.GetToDo(id);

            return Ok(response);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost, Authorize(Roles = "User, Admin")]
    public async Task<ActionResult<ToDoOut>> CreateAnToDo(ToDoIn request) {
        var bearerToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(bearerToken) as JwtSecurityToken;

        var claimValue = jsonToken.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;

        try {
            var response = await _toDoService.CreateToDo(claimValue, request);

            return Ok(response);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete("{id}"), Authorize(Roles = "User, Admin")]
    public async Task<ActionResult<string>> DeleteAnToDo(int id) {
        try {
            var response = await _toDoService.DeleteToDo(id);

            return Ok(response);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}"), Authorize(Roles = "User, Admin")]
    public async Task<ActionResult<ToDoOut>> UpdateAnToDo(int id, ToDoIn request) {
        if (request is null) return BadRequest("You need to provide new data to update ToDo.");

        var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        var handler = new JwtSecurityTokenHandler();
        var tokenS = handler.ReadToken(token) as JwtSecurityToken;

        var username = tokenS.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;

        try {
            var response = await _toDoService.UpdateToDo(id, request, username);

            return Ok(response);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}
