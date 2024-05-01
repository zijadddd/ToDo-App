namespace todo_be.Exceptions;
public class UserNotCreatedException : Exception {
    public UserNotCreatedException() : base("User isn't created.") { }
}
