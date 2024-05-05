namespace todo_be.Exceptions;

public class UserWithUserNameNotFoundException : Exception {
    public UserWithUserNameNotFoundException(string userName) : base($"User with username {userName} not found.") { }
}