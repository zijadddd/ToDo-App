namespace todo_be.Exceptions;
public sealed class CannotModifieToDoException : Exception {
    public CannotModifieToDoException(int id) : base($"You cannot modifie ToDo with id {id} because you didn't create id.") { }
}
