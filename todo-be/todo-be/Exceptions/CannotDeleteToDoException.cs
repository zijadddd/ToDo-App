namespace todo_be.Exceptions;
public class CannotDeleteToDoException : Exception {
    public CannotDeleteToDoException(int id) : base($"You cannot delete ToDo with id {id} because you didn't create id.") { }
}
