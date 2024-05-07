namespace todo_be.Exceptions;

public sealed class UserWithUserNameNotFoundException : Exception {
    public UserWithUserNameNotFoundException(string userName) : base($"User with username {userName} not found.") { }
}