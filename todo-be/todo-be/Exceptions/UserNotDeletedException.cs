namespace todo_be.Exceptions;
public sealed class UserNotDeletedException : Exception {
    public UserNotDeletedException(int id) : base($"User with id {id} is not deleted.") { }
}
