namespace todo_be.Exceptions;
public sealed class UserWithIdNotFoundException : Exception {
    public UserWithIdNotFoundException(int id) : base($"User with id {id} not found.") { }
}
