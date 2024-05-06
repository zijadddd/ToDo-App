namespace todo_be.Models.DTOs.Out;
public record UserAuthOut {
    public string Token { get; init; } = string.Empty;

    public UserAuthOut(string token) {
        Token = token;      
    }
}
