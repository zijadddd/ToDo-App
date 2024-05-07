namespace todo_be.Exceptions;
public sealed class UserAuthenticationDetailsNotFoundException : Exception {
    public UserAuthenticationDetailsNotFoundException(int id) : base($"Authentication details for user with id {id} was not found.") { }
}
