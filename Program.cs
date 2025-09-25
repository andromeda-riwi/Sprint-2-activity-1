using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sprint_2.Data;
using Sprint_2.Menus;
using Sprint_2.Repositories;
using Sprint_2.Controllers;

namespace Sprint_2;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Configurar servicios
            var services = ConfigureServices();
            
            // Crear instancia del menú principal
            var mainMenu = services.GetRequiredService<MainMenu>();
            
            // Ejecutar la aplicación
            await mainMenu.RunAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fatal: {ex.Message}");
            Console.WriteLine("Presione Enter para salir...");
            Console.ReadLine();
        }
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Configurar DbContext
        services.AddDbContext<UserDbContext>(options =>
        {
            options.UseMySql(
                "Server=168.119.183.3;Database=tren_andromeda;User=root;Password=g0tIFJEQsKHm5$34Pxu1;Port=3307",
                new MySqlServerVersion(new Version(8, 0, 0)));
        });

        // Registrar repositorios
        services.AddScoped<IUserRepository, UserRepository>();

        // Registrar controladores
        services.AddScoped<UsersController>();
        services.AddScoped<UserQueries>();

        // Registrar menús
        services.AddScoped<MainMenu>(provider => 
            new MainMenu(
                provider.GetRequiredService<UsersController>(),
                provider.GetRequiredService<UserQueries>()
            ));

        return services.BuildServiceProvider();
    }
}
