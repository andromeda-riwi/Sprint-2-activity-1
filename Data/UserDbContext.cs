using Microsoft.EntityFrameworkCore;
using Sprint-2-activity-1.Entities;

namespace Sprint2.Data;

public class MysqlDbContext : DbContext
{
    public DbSet<User> users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySql(
            "Server=168.119.183.3;Database=tren_andromeda;User=root;Password=g0tIFJEQsKHm5$34Pxu1;Port=3307",
            new MySqlServerVersion(new Version(8, 0, 0)));
}