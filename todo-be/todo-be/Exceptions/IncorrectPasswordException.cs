namespace todo_be.Exceptions;
public sealed class IncorrectPasswordException : Exception {
    public IncorrectPasswordException() : base("Incorrect password.") { }
}
