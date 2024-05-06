namespace todo_be.Models.DTOs.OutModels;
public record UserAuthOut {
    public string Token { get; init; } = string.Empty;

    public UserAuthOut(string token) {
        Token = token;      
    }
}
