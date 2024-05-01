namespace todo_be.Exceptions;
public class NotASingleUserWasFoundException : Exception {
    public NotASingleUserWasFoundException() : base("Not a single user was found.") { }
}

