using System.ComponentModel.DataAnnotations;

namespace todo_be.Models.DTOs.In;
public record UserAuthIn {

    [Required]
    public string UserName { get; init; } = string.Empty;
    [Required]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}$", ErrorMessage = "Invalid password. Valid: Example123*")]
    public string Password { get; init; } = string.Empty;

    public UserAuthIn(string userName, string password) {
        UserName = userName;
        Password = password;
    }
}
