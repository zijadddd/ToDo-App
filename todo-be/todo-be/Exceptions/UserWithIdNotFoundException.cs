namespace todo_be.Exceptions;
public class UserWithIdNotFoundException : Exception {
    public UserWithIdNotFoundException(int id) : base($"User with id {id} not found.") { }
}
