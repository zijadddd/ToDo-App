namespace todo_be.Exceptions;
public class UserNotDeletedException : Exception {
    public UserNotDeletedException(int id) : base($"User with id {id} is not deleted.") { }
}
