namespace todo_be.Exceptions;
public class PasswordsNotMatchingException : Exception {
    public PasswordsNotMatchingException() : base("You need to put your old password to change it.") { }
}
