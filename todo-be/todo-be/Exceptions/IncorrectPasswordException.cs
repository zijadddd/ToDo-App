namespace todo_be.Exceptions;
public class IncorrectPasswordException : Exception {
    public IncorrectPasswordException() : base("Incorrect password") { }
}
