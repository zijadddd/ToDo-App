namespace todo_be.Models.DTOs.In;
public record UserAuthIn {
    public string UserName { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;

    public UserAuthIn(string userName, string password) {
        UserName = userName;
        Password = password;
    }
}
