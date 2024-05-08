using System.ComponentModel.DataAnnotations;

namespace todo_be.Models.DTOs.InModels;
public sealed record ToDoIn {
    
    public int Id { get; init; }
    // For update request
    [Required]
    public string Title { get; init; } = string.Empty;
    [Required]
    public string Description { get; init; } = string.Empty;
    
    public ToDoIn(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
    
    public ToDoIn(string title, string description) {
        Title = title;
        Description = description;
    }
}
