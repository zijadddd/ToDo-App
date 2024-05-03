using Microsoft.EntityFrameworkCore;
using todo_be.Database;
using todo_be.Exceptions;
using todo_be.Models.DAOs;
using todo_be.Models.DTOs.In;
using todo_be.Models.DTOs.Out;
using todo_be.Services.Interfaces;

namespace todo_be.Services.Implementations;
public class UserService : IUserService {

    private readonly DatabaseContext _databaseContext;

    public UserService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<UserOutWithoutPassword> CreateAnUser(UserIn request) {
        var role = await _databaseContext.Roles.FirstOrDefaultAsync(r => r.Id == 1);

        var username = $"{request.FirstName.ToLower()}_{request.LastName.ToLower()}_{GenerateRandomString(10)}";

        var userExist = await _databaseContext.UsersAuths.FirstOrDefaultAsync(ue => ue.UserName.Equals(username));
        do {
            if (userExist is null) break;

            username = $"{request.FirstName.ToLower()}_{request.LastName.ToLower()}_{GenerateRandomString(10)}";
        } while (userExist.UserName.Equals(username));
        // There's a chance that two individuals may share both their first and last names.
        // I'm addressing this to prevent any potential bugs.

        User user = new User {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = DateOnly.Parse(request.DateOfBirth),
            DateTimeOfRegistration = DateTime.Now
        };

        UserAuth userAuth = new UserAuth {
            UserName = username,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = role,
            User = user
        };

        try {
            await _databaseContext.Users.AddAsync(user);
            await _databaseContext.UsersAuths.AddAsync(userAuth);
            await _databaseContext.SaveChangesAsync();
        } catch (Exception ex) {
            throw new UserNotCreatedException();
        }

        return new UserOutWithoutPassword(user.Id.ToString(), user.FirstName, user.LastName, user.Email, user.DateOfBirth.ToString(), user.DateTimeOfRegistration.ToString());
    }

    public async Task<string> DeleteAnUser(int id) {
        var user = await _databaseContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null) throw new UserWithIdNotFoundException(id);

        try {
            _databaseContext.Remove(user);
            await _databaseContext.SaveChangesAsync();
        } catch (Exception ex) {
            throw new UserNotDeletedException(id);
        }

        return $"User with id {id} has been successfully deleted";
    }

    public async Task<List<UserOutWithoutPassword>> GetAllUsers() {
        var users = await _databaseContext.Users.ToListAsync();
        if (users.Count == 0) throw new NotASingleUserWasFoundException();

        List<UserOutWithoutPassword> usersOut = new List<UserOutWithoutPassword>();

        foreach (var user in users)
            usersOut.Add(new UserOutWithoutPassword(user.Id.ToString(), user.FirstName, user.LastName, user.Email, user.DateOfBirth.ToString(), user.DateTimeOfRegistration.ToString()));

        return usersOut;
    }

    public async Task<UserOutWithoutPassword> GetAnUserWithoutPassword(int id) {
        var user = await _databaseContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null) throw new UserWithIdNotFoundException(id);

        UserOutWithoutPassword userOutWithoutPassword = new UserOutWithoutPassword(
            user.Id.ToString(),
            user.FirstName,
            user.LastName,
            user.Email,
            user.DateOfBirth.ToString(),
            user.DateTimeOfRegistration.ToString()
        );

        return userOutWithoutPassword;
    }

    public async Task<UserOut> GetAnUserWithPassword(int id) {
        var user = await _databaseContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null) throw new UserWithIdNotFoundException(id);

        var userAuth = await _databaseContext.UsersAuths.FirstOrDefaultAsync(u => u.UserId == id);
        if (userAuth == null) throw new UserAuthWithIdNotFoundException(id);

        UserOut userOut = new UserOut(
             user.Id.ToString(),
             user.FirstName,
             user.LastName,
             user.Email,
             user.DateOfBirth.ToString(),
             user.DateTimeOfRegistration.ToString(),
             userAuth.Password
         );

        return userOut;
    }

    public async Task<string> ChangePassword(int id, ChangePasswordIn request) {
        if (!request.OldPassword.Equals(request.NewPassword)) throw new PasswordsNotMatchingException();

        var userAuth = await _databaseContext.UsersAuths.FirstOrDefaultAsync(ua => ua.UserId == id);
        if (userAuth == null) throw new UserAuthWithIdNotFoundException(id);

        userAuth.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

        try {
            _databaseContext.UsersAuths.Update(userAuth);
            await _databaseContext.SaveChangesAsync();
        } catch (Exception ex) {
            throw new PasswordNotChangedException();
        }

        return $"Password is successfully changed for user {userAuth.UserName}";
    }

    public async Task<string> ChangeRole(int id, string roleName) {
        var role = await _databaseContext.Roles.FirstOrDefaultAsync(r => r.Name.Equals(roleName));
        if (role == null) throw new RoleNotFoundException(roleName);

        var userAuth = await _databaseContext.UsersAuths.FirstOrDefaultAsync(ua => ua.Id == id);
        if (userAuth == null) throw new UserAuthWithIdNotFoundException(id);

        userAuth.Role = role;

        try {
            _databaseContext.UsersAuths.Update(userAuth);
            await _databaseContext.SaveChangesAsync();
        } catch (Exception ex) {
            throw new RoleNotChangedException(id);
        }

        return $"Role for user with id {id} is changed.";
    }

    private string GenerateRandomString(int length) {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        string randomChars = "";

        for (int i = 0; i < length; i++) {
            randomChars += chars[random.Next(chars.Length)];
        }

        return randomChars;
    }
}
