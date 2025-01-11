using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Domain.Entities;

namespace ToDo.Infrastructure.Data.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<ToDoEntity> ToDo { get; }
    public DbSet<OwnerEntity> Owners { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ToDoEntity>()
            .HasOne(t => t.Owner)
            .WithMany(o => o.ToDos);

        modelBuilder.Entity<OwnerEntity>()
            .HasMany(o => o.ToDos)
            .WithOne(t => t.Owner);
    }
}