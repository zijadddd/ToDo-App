namespace todo_be.Models.DTOs.In;
public record ToDoIn {
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;

    public ToDoIn(string title, string description) {
        Title = title;
        Description = description;
    }
}
