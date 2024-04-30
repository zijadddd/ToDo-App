using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using todo_be.Database;
using todo_be.Exceptions;
using todo_be.Models.DAOs;
using todo_be.Models.DTOs.In;
using todo_be.Models.DTOs.Out;
using todo_be.Services.Interfaces;

namespace todo_be.Services.Implementations;
public class UserAuthService : IUserAuthService {

    private readonly DatabaseContext _databaseContext;
    private readonly IConfiguration _configuration;

    public UserAuthService(DatabaseContext databaseContext, IConfiguration configuration) {
        _databaseContext = databaseContext;
        _configuration = configuration;
    }

    public async Task<UserAuthOut> AuthenticateUser(UserAuthIn request) {
        var user = await _databaseContext.UsersAuths.FirstOrDefaultAsync(u => u.UserName.Equals(request.UserName));

        if (user == null) throw new UserNotFoundException();
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password)) throw new IncorrectPasswordException();

        user.Role = await _databaseContext.Roles.FirstOrDefaultAsync(r => r.Id == user.RoleId);
        user.User = await _databaseContext.Users.FirstOrDefaultAsync(u => u.Id == user.UserId);


        return await CreateTokenAsync(user);
    }

    private async Task<UserAuthOut> CreateTokenAsync(UserAuth user) {
        List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role.Name),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Secret").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return new UserAuthOut(jwt);
    }
}
