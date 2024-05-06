using System.ComponentModel.DataAnnotations;

namespace todo_be.Models.DTOs.InModels;
public record UserIn {
    [Required]
    [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Invalid first name. Valid: John")]
    public string FirstName { get; init; } = string.Empty;
    [Required]
    [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Invalid last name. Valid: Smith")]
    public string LastName { get; init; } = string.Empty;
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address. Valid: johnsmith@gmail.com")]
    public string Email { get; init; } = string.Empty;
    [Required]
    [StringLength(64, MinimumLength = 8, ErrorMessage = "Invalid password. The password should be at least 8 characters long.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
    ErrorMessage = "Invalid password. Valid: Abcdef1*")]
    public string Password { get; init; } = string.Empty;
    [Required]
    [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage ="Invalid date. Valid: 2024-05-01 (yyyy-mm-dd)")]
    public string DateOfBirth { get; init; } = string.Empty;

    public UserIn(string firstName, string lastName, string email, string password, string dateOfBirth) {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        DateOfBirth = dateOfBirth;
    }
}
