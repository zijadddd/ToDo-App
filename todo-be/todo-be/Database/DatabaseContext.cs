using Microsoft.EntityFrameworkCore;
using todo_be.Models.DAOs;

namespace todo_be.Database;
public class DatabaseContext : DbContext {

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserAuth> UsersAuths { get; set; }
    public DbSet<ToDo> ToDos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {

        modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "User" }, new Role { Id = 2, Name = "Admin" });
        modelBuilder.Entity<User>().HasData(new User { Id = 1, FirstName = "Admin", LastName = "Admin", Email = "example@gmail.com", DateOfBirth = new DateOnly(2001, 9, 23), DateTimeOfRegistration = new DateTime() });
        modelBuilder.Entity<UserAuth>().HasData(new UserAuth { Id = 1, UserName="admin", Password= "$2a$11$UDvvHAu4eyase8IqmXkS4eb2A4YAGKqk3E8e8J.qhwbv315XRnts.", UserId=1, RoleId=2 });
    }
}

