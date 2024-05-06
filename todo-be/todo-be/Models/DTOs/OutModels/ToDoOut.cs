namespace todo_be.Models.DTOs.OutModels;

public record ToDoOut {
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime Created { get; init; }
    public DateTime Updated { get; init; }
    public string UserName { get; init; } = string.Empty;

    public ToDoOut(int id, string title, string description, DateTime created, DateTime updated, string username) {
        Id = id;
        Title = title;
        Description = description;
        Created = created;
        Updated = updated;
        UserName = username;
    }
}