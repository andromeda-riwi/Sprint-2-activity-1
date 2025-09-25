using Microsoft.EntityFrameworkCore;
using Sprint_2.Entities;

namespace Sprint_2.Data;

public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseMySql(
                "Server=168.119.183.3;Database=tren_andromeda;User=root;Password=g0tIFJEQsKHm5$34Pxu1;Port=3307",
                new MySqlServerVersion(new Version(8, 0, 0)));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar índices únicos
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // Configurar nombres de tabla y columnas
        modelBuilder.Entity<User>()
            .ToTable("Users");

        modelBuilder.Entity<User>()
            .Property(u => u.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<User>()
            .Property(u => u.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");
    }
}