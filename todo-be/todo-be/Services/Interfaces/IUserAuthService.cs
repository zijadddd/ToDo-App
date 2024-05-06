using todo_be.Models.DTOs.InModels;
using todo_be.Models.DTOs.OutModels;

namespace todo_be.Services.Interfaces;
public interface IUserAuthService {
    Task<UserAuthOut> AuthenticateUser(UserAuthIn request);
}

