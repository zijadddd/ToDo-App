namespace todo_be.Exceptions;
public class RoleNotFoundException : Exception {
    public RoleNotFoundException(string roleName) : base($"Role {roleName} was not found.") { }
}
