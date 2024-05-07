namespace todo_be.Exceptions;
public sealed class RoleNotFoundException : Exception {
    public RoleNotFoundException(string roleName) : base($"Role {roleName} was not found.") { }
}
