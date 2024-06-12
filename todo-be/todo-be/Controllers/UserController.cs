using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using todo_be.Models.DTOs.InModels;
using todo_be.Models.DTOs.OutModels;
using todo_be.Services.Interfaces;

namespace todo_be.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class UserController : ControllerBase {

    private readonly IUserService _userService;

    public UserController(IUserService userService) {
        _userService = userService;
    }

    [HttpPost, AllowAnonymous]
    public async Task<ActionResult<UserOutWithoutPassword>> CreateAnUser(UserIn request) {
        if (request is null) return BadRequest("You must fill the data to register.");
        try {
            if (ModelState.IsValid) {
                var response = await _userService.CreateAnUser(request);

                return Ok(response);
            }
            return BadRequest("User data is not good.");
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet, Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<UserOutWithoutPassword>>> GetAllUsers() {
        try {
            var response = await _userService.GetAllUsers();

            return Ok(response);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("getUserWithPassword/{id}"), Authorize(Roles = "Admin")]
    public async Task<ActionResult<UserOut>> GetAnUserWithPassword(int id) {
        try {
            var response = await _userService.GetAnUserWithPassword(id);

            return Ok(response);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("getUserWithoutPassword/{id}"), Authorize(Roles = "User, Admin")]
    public async Task<ActionResult<UserOut>> GetAnUserWithoutPassword(int id) {
        try {
            var response = await _userService.GetAnUserWithoutPassword(id);

            return Ok(response);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}"), Authorize(Roles = "Admin")]
    public async Task<ActionResult<string>> DeleteAnUser(int id) {
        try {
            var response = await _userService.DeleteAnUser(id);

            return Ok(response);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("changeRole/{id}"), Authorize(Roles = "Admin")]
    public async Task<ActionResult<string>> ChangeRole(int id, [FromBody] string role) {
        if (role is null) return BadRequest("You must provide a role name to change user's role.");
        try {
            var response = await _userService.ChangeRole(id, role);

            return Ok(response);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("changePassword/{id}"), Authorize(Roles = "User, Admin")]
    public async Task<ActionResult<string>> ChangePassword(int id, [FromBody] ChangePasswordIn request) {
        if (request is null) return BadRequest("You need to provide old and new passwords to change it.");
        try {
            var response = await _userService.ChangePassword(id, request);

            return Ok(response);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}
