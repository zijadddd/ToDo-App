namespace todo_be.Exceptions;

public sealed class ToDosForUserNotFoundException : Exception {
    public ToDosForUserNotFoundException(string username) : base($"ToDos for user with username {username} not found.") { }
}