namespace todo_be.Exceptions;
public class UserNotFoundException : Exception {
    public UserNotFoundException() : base("User not found.") { }
}
