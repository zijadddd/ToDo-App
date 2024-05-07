namespace todo_be.Exceptions;
public sealed class NotASingleUserWasFoundException : Exception {
    public NotASingleUserWasFoundException() : base("Not a single user was found.") { }
}

