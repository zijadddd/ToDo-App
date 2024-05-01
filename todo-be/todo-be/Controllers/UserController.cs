using Microsoft.AspNetCore.Mvc;
using todo_be.Services.Interfaces;

namespace todo_be.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase {

    private readonly IUserService _userCRUDService;

    public UserController(IUserService userCRUDService)
    {
        _userCRUDService = userCRUDService;
    }
}
