namespace todo_be.Exceptions;
public sealed class UserNotCreatedException : Exception {
    public UserNotCreatedException() : base("User isn't created.") { }
}
