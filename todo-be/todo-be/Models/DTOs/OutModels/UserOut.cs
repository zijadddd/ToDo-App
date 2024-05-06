namespace todo_be.Models.DTOs.OutModels;
public record UserOut : UserOutWithoutPassword {
    public string Password { get; init; } = string.Empty;

    public UserOut(string id, string firstName, string lastName, string email, string dateOfBirth, string dateTimeOfRegistration, string password, string role) 
        : base(id, firstName, lastName, email, dateOfBirth, dateTimeOfRegistration, role) {
        Password = password;
    }
}

