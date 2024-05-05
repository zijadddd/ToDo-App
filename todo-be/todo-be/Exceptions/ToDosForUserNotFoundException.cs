namespace todo_be.Exceptions;

public class ToDosForUserNotFoundException : Exception {
    public ToDosForUserNotFoundException(string username) : base($"ToDos for user with username {username} not found.") { }
}