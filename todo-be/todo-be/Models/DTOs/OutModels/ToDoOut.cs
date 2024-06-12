namespace todo_be.Models.DTOs.OutModels;

public sealed record ToDoOut {
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime Created { get; init; }
    public DateTime Modified { get; init; }
    public string UserName { get; init; } = string.Empty;

    public ToDoOut(int id, string title, string description, DateTime created, DateTime modified, string username) {
        Id = id;
        Title = title;
        Description = description;
        Created = created;
        Modified = modified;
        UserName = username;
    }
}