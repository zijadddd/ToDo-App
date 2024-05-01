namespace todo_be.Exceptions;
public class PasswordNotChangedException : Exception {
    public PasswordNotChangedException() : base("Password is not changed.") { }
}
