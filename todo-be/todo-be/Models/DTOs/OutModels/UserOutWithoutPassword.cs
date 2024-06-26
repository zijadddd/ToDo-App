﻿namespace todo_be.Models.DTOs.OutModels;
public record UserOutWithoutPassword {
    public string Id { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string DateOfBirth { get; init; } = string.Empty;
    public string DateTimeOfRegistration { get; init; } = string.Empty;
    public string Role {  get; init; } = string.Empty;

    public UserOutWithoutPassword(string id, string firstName, string lastName, string email, string dateOfBirth, string dateTimeOfRegistration, string role) {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        DateOfBirth = dateOfBirth;
        DateTimeOfRegistration = dateTimeOfRegistration;
        Role = role;
    }
}
