namespace todo_be.Exceptions;

public sealed class ToDoNotDeletedException : Exception {
    public ToDoNotDeletedException(int id) : base($"ToDo with id {id} is not deleted.") {
        
    }
}