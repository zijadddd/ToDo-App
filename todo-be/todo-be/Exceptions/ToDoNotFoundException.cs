namespace todo_be.Exceptions;

public class ToDoNotFoundException : Exception{
    public ToDoNotFoundException() : base("ToDo not found."){ }
}