﻿namespace todo_be.Models.DAOs;
public class ToDo {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int UserId { get; set; }
    public User? User { get; set; }
}
