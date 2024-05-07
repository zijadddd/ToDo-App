namespace todo_be.Exceptions;
public sealed class InvalidBirthDateException : Exception {
    public InvalidBirthDateException() : base("Invalid date of birth. Date of birth must be between 1950-01-01 and today's date.") { }
}

