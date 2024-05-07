using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using todo_be.Models.DTOs.InModels;
using todo_be.Models.DTOs.OutModels;
using todo_be.Services.Interfaces;

namespace todo_be.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class UserAuthController : ControllerBase {

    private readonly IUserAuthService _userAuthService;

    public UserAuthController(IUserAuthService userAuthService) {
        _userAuthService = userAuthService;
    }

    [HttpPost("authentication"), AllowAnonymous]
    public async Task<ActionResult<UserAuthOut>> Authentication(UserAuthIn request) {
        if (request == null) return BadRequest("User authentication info does not exist in request.");
        try {
            var response = await _userAuthService.AuthenticateUser(request);
            if (response.GetType() != typeof(string)) return BadRequest(response);
            return Ok(response);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}
