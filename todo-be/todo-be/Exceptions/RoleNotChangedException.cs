namespace todo_be.Exceptions;
public class RoleNotChangedException : Exception {
    public RoleNotChangedException(int userId) : base($"Role for user with id {userId} is not changed.") { }
}
