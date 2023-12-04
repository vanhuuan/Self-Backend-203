using Microsoft.EntityFrameworkCore;
using SelfBackEnd.Models;
using Task = SelfBackEnd.Models.Task;

namespace SelfBackEnd.Context;

public class DashBoardContext : DbContext
{
    public DashBoardContext() { }
    public DashBoardContext(DbContextOptions<DashBoardContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Task> Tasks { get; set; }

    public DbSet<Dashboard> Dashboards { get; set; }

    public DbSet<Contact> Contacts { get; set; }

    public DbSet<Widget> Widgets { get; set; }

    public DbSet<AppVersion> AppVersions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users");
    }

}
