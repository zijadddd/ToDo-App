using todo_be.Models.DTOs.In;
using todo_be.Models.DTOs.Out;

namespace todo_be.Services.Interfaces;
public interface IUserAuthService {
    Task<UserAuthOut> AuthenticateUser(UserAuthIn request);
}

