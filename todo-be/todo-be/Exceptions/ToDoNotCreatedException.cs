namespace todo_be.Exceptions;
public sealed class ToDoNotCreatedException : Exception {
    public ToDoNotCreatedException() : base("ToDo is not created.") {}
}
