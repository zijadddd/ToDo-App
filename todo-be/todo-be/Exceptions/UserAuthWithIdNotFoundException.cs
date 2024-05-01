namespace todo_be.Exceptions;
public class UserAuthWithIdNotFoundException : Exception {

    public UserAuthWithIdNotFoundException(int id) : base($"User authentication data with id {id} not found.") { }
}
