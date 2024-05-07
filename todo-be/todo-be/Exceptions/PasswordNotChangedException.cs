namespace todo_be.Exceptions;
public sealed class PasswordNotChangedException : Exception {
    public PasswordNotChangedException() : base("Password is not changed.") { }
}
