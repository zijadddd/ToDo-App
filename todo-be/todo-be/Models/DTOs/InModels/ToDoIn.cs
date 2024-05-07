using System.ComponentModel.DataAnnotations;

namespace todo_be.Models.DTOs.InModels;
public sealed record ToDoIn {

    [Required]
    public string Title { get; init; } = string.Empty;
    [Required]
    public string Description { get; init; } = string.Empty;

    public ToDoIn(string title, string description) {
        Title = title;
        Description = description;
    }
}
