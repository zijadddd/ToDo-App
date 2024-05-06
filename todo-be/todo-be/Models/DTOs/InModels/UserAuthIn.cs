using System.ComponentModel.DataAnnotations;

namespace todo_be.Models.DTOs.InModels;
public record UserAuthIn {

    [Required]
    public string UserName { get; init; } = string.Empty;
    [Required]
    [StringLength(64, MinimumLength = 8, ErrorMessage = "Invalid password. The password should be at least 8 characters long.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
    ErrorMessage = "Invalid password. Valid: Abcdef1*")]
    public string Password { get; init; } = string.Empty;

    public UserAuthIn(string userName, string password) {
        UserName = userName;
        Password = password;
    }
}
