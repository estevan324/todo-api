using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Domain.Entities;

namespace ToDo.Infrastructure.Data.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<ToDoEntity> ToDo { get; set;  }
    public DbSet<OwnerEntity> Owners { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
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