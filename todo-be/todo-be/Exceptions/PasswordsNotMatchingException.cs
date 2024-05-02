namespace todo_be.Exceptions;
public class PasswordsNotMatchingException : Exception {
    public PasswordsNotMatchingException() : base("Your old and new password do not match.") { }
}
