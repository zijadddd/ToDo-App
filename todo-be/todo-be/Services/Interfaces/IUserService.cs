using todo_be.Models.DTOs.In;
using todo_be.Models.DTOs.Out;

namespace todo_be.Services.Interfaces;
public interface IUserService {
    Task<UserOutWithoutPassword> CreateAnUser(UserIn request);
    Task<string> ChangePassword(int id, ChangePasswordIn request);
    Task<List<UserOutWithoutPassword>> GetAllUsers();
    Task<UserOut> GetAnUserWithPassword(int id);
    Task<UserOutWithoutPassword> GetAnUserWithoutPassword(int id);
    Task<string> DeleteAnUser(int id);
    Task<string> ChangeRole(int id, string roleName);
}
