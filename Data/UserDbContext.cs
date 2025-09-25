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
                new MySqlServerVersion(new Version(8, 0, 0)),
                options => options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null));
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
            .ToTable("users")
            .HasCharSet("utf8mb4")
            .UseCollation("utf8mb4_unicode_ci");

        // Mapear propiedades a columnas de la base de datos
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);
            
        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<User>()
            .Property(u => u.FirstName)
            .HasColumnName("first_name");

        modelBuilder.Entity<User>()
            .Property(u => u.LastName)
            .HasColumnName("last_name");

        modelBuilder.Entity<User>()
            .Property(u => u.Username)
            .HasColumnName("username");

        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .HasColumnName("email");

        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .HasColumnName("password");

        modelBuilder.Entity<User>()
            .Property(u => u.Cellphone)
            .HasColumnName("cellphone");

        modelBuilder.Entity<User>()
            .Property(u => u.Address)
            .HasColumnName("address");

        modelBuilder.Entity<User>()
            .Property(u => u.City)
            .HasColumnName("city");

        modelBuilder.Entity<User>()
            .Property(u => u.State)
            .HasColumnName("state");

        modelBuilder.Entity<User>()
            .Property(u => u.Zipcode)
            .HasColumnName("zipcode");

        modelBuilder.Entity<User>()
            .Property(u => u.Country)
            .HasColumnName("country");

        modelBuilder.Entity<User>()
            .Property(u => u.Gender)
            .HasColumnName("gender")
            .HasConversion<string>()
            .HasMaxLength(20);

        modelBuilder.Entity<User>()
            .Property(u => u.Age)
            .HasColumnName("age");

        modelBuilder.Entity<User>()
            .Property(u => u.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false);

        modelBuilder.Entity<User>()
            .Property(u => u.UpdatedAt)
            .HasColumnName("updated_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
            .IsRequired(false);
    }
}