namespace todo_be.Models.DTOs.Out;
public record UserOut : UserOutWithoutPassword {
    public string Password { get; init; } = string.Empty;

    public UserOut(string id, string firstName, string lastName, string email, string dateOfBirth, string dateTimeOfRegistration, string password) 
        : base(id, firstName, lastName, email, dateOfBirth, dateTimeOfRegistration) {
        Password = password;
    }
}

