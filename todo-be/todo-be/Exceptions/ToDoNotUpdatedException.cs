namespace todo_be.Exceptions;
public sealed class ToDoNotUpdatedException : Exception {
    public ToDoNotUpdatedException() : base("ToDo is not updated.") { }
}
