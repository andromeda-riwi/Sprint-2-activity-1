using Sprint_2.Controllers;
using Sprint_2.DTOs;

namespace Sprint_2.Menus;

public class MainMenu
{
    private readonly UsersController _usersController;

    public MainMenu(UsersController usersController)
    {
        _usersController = usersController;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE USUARIOS ===");
            Console.WriteLine();
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Consultas de Usuarios");
            Console.WriteLine("2. Gestión de Usuarios (Crear/Actualizar/Eliminar)");
            Console.WriteLine("3. Reportes y Estadísticas");
            Console.WriteLine("0. Salir");
            Console.WriteLine();
            Console.Write("Ingrese su opción: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await ShowConsultationMenuAsync();
                    break;
                case "2":
                    await ShowManagementMenuAsync();
                    break;
                case "3":
                    await ShowReportsMenuAsync();
                    break;
                case "0":
                    Console.WriteLine("¡Hasta luego!");
                    return;
                default:
                    Console.WriteLine("Opción inválida. Presione Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private async Task ShowConsultationMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== CONSULTAS DE USUARIOS ===");
            Console.WriteLine();
            Console.WriteLine("1. Listar todos los usuarios");
            Console.WriteLine("2. Ver usuario por ID");
            Console.WriteLine("3. Ver usuario por correo electrónico");
            Console.WriteLine("4. Usuarios por ciudad");
            Console.WriteLine("5. Usuarios por país");
            Console.WriteLine("6. Usuarios mayores de edad específica");
            Console.WriteLine("7. Usuarios por género");
            Console.WriteLine("8. Nombres completos y correos");
            Console.WriteLine("9. Últimos usuarios registrados");
            Console.WriteLine("10. Usuarios ordenados por apellido");
            Console.WriteLine("11. Usuarios sin teléfono");
            Console.WriteLine("12. Usuarios sin dirección");
            Console.WriteLine("0. Volver al menú principal");
            Console.WriteLine();
            Console.Write("Ingrese su opción: ");

            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        await ShowAllUsersAsync();
                        break;
                    case "2":
                        await ShowUserByIdAsync();
                        break;
                    case "3":
                        await ShowUserByEmailAsync();
                        break;
                    case "4":
                        await ShowUsersByCityAsync();
                        break;
                    case "5":
                        await ShowUsersByCountryAsync();
                        break;
                    case "6":
                        await ShowUsersOlderThanAsync();
                        break;
                    case "7":
                        await ShowUsersByGenderAsync();
                        break;
                    case "8":
                        await ShowUsersNamesAndEmailsAsync();
                        break;
                    case "9":
                        await ShowLatestUsersAsync();
                        break;
                    case "10":
                        await ShowUsersOrderedByLastNameAsync();
                        break;
                    case "11":
                        await ShowUsersWithoutPhoneAsync();
                        break;
                    case "12":
                        await ShowUsersWithoutAddressAsync();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Presione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
            }
        }
    }

    private async Task ShowManagementMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE USUARIOS ===");
            Console.WriteLine();
            Console.WriteLine("1. Crear nuevo usuario");
            Console.WriteLine("2. Actualizar usuario");
            Console.WriteLine("3. Cambiar contraseña");
            Console.WriteLine("4. Eliminar usuario por ID");
            Console.WriteLine("5. Eliminar usuario por correo");
            Console.WriteLine("0. Volver al menú principal");
            Console.WriteLine();
            Console.Write("Ingrese su opción: ");

            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        await CreateUserAsync();
                        break;
                    case "2":
                        await UpdateUserAsync();
                        break;
                    case "3":
                        await ChangePasswordAsync();
                        break;
                    case "4":
                        await DeleteUserByIdAsync();
                        break;
                    case "5":
                        await DeleteUserByEmailAsync();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Presione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
            }
        }
    }

    private async Task ShowReportsMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== REPORTES Y ESTADÍSTICAS ===");
            Console.WriteLine();
            Console.WriteLine("1. Total de usuarios registrados");
            Console.WriteLine("2. Usuarios por ciudad");
            Console.WriteLine("3. Usuarios por país");
            Console.WriteLine("0. Volver al menú principal");
            Console.WriteLine();
            Console.Write("Ingrese su opción: ");

            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        await ShowTotalUsersCountAsync();
                        break;
                    case "2":
                        await ShowUsersCountByCityAsync();
                        break;
                    case "3":
                        await ShowUsersCountByCountryAsync();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Presione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Presione Enter para continuar...");
                Console.ReadLine();
            }
        }
    }

    // Métodos de consulta
    private async Task ShowAllUsersAsync()
    {
        Console.Clear();
        Console.WriteLine("=== TODOS LOS USUARIOS ===");
        Console.WriteLine();

        var users = await _usersController.GetAllUsersAsync();
        if (!users.Any())
        {
            Console.WriteLine("No hay usuarios registrados.");
        }
        else
        {
            foreach (var user in users)
            {
                DisplayUser(user);
                Console.WriteLine();
            }
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task ShowUserByIdAsync()
    {
        Console.Clear();
        Console.WriteLine("=== USUARIO POR ID ===");
        Console.WriteLine();

        Console.Write("Ingrese el ID del usuario: ");
        if (long.TryParse(Console.ReadLine(), out long id))
        {
            var user = await _usersController.GetUserByIdAsync(id);
            if (user != null)
            {
                DisplayUser(user);
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task ShowUserByEmailAsync()
    {
        Console.Clear();
        Console.WriteLine("=== USUARIO POR CORREO ELECTRÓNICO ===");
        Console.WriteLine();

        Console.Write("Ingrese el correo electrónico: ");
        var email = Console.ReadLine();

        if (!string.IsNullOrEmpty(email))
        {
            var user = await _usersController.GetUserByEmailAsync(email);
            if (user != null)
            {
                DisplayUser(user);
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Correo electrónico inválido.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task ShowUsersByCityAsync()
    {
        Console.Clear();
        Console.WriteLine("=== USUARIOS POR CIUDAD ===");
        Console.WriteLine();

        Console.Write("Ingrese la ciudad: ");
        var city = Console.ReadLine();

        if (!string.IsNullOrEmpty(city))
        {
            var users = await _usersController.GetUsersByCityAsync(city);
            if (users.Any())
            {
                foreach (var user in users)
                {
                    DisplayUser(user);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron usuarios en la ciudad: {city}");
            }
        }
        else
        {
            Console.WriteLine("Ciudad inválida.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task ShowUsersByCountryAsync()
    {
        Console.Clear();
        Console.WriteLine("=== USUARIOS POR PAÍS ===");
        Console.WriteLine();

        Console.Write("Ingrese el país: ");
        var country = Console.ReadLine();

        if (!string.IsNullOrEmpty(country))
        {
            var users = await _usersController.GetUsersByCountryAsync(country);
            if (users.Any())
            {
                foreach (var user in users)
                {
                    DisplayUser(user);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron usuarios en el país: {country}");
            }
        }
        else
        {
            Console.WriteLine("País inválido.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task ShowUsersOlderThanAsync()
    {
        Console.Clear();
        Console.WriteLine("=== USUARIOS MAYORES DE EDAD ESPECÍFICA ===");
        Console.WriteLine();

        Console.Write("Ingrese la edad mínima: ");
        if (int.TryParse(Console.ReadLine(), out int age))
        {
            var users = await _usersController.GetUsersOlderThanAsync(age);
            if (users.Any())
            {
                foreach (var user in users)
                {
                    DisplayUser(user);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron usuarios mayores de {age} años.");
            }
        }
        else
        {
            Console.WriteLine("Edad inválida.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task ShowUsersByGenderAsync()
    {
        Console.Clear();
        Console.WriteLine("=== USUARIOS POR GÉNERO ===");
        Console.WriteLine();

        Console.Write("Ingrese el género (masculino/femenino): ");
        var gender = Console.ReadLine();

        if (!string.IsNullOrEmpty(gender))
        {
            var users = await _usersController.GetUsersByGenderAsync(gender);
            if (users.Any())
            {
                foreach (var user in users)
                {
                    DisplayUser(user);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron usuarios con género: {gender}");
            }
        }
        else
        {
            Console.WriteLine("Género inválido.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task ShowUsersNamesAndEmailsAsync()
    {
        Console.Clear();
        Console.WriteLine("=== NOMBRES COMPLETOS Y CORREOS ===");
        Console.WriteLine();

        var users = await _usersController.GetUsersNamesAndEmailsAsync();
        if (users.Any())
        {
            foreach (dynamic user in users)
            {
                Console.WriteLine($"Nombre: {user.FullName}");
                Console.WriteLine($"Correo: {user.Email}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No hay usuarios registrados.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task ShowLatestUsersAsync()
    {
        Console.Clear();
        Console.WriteLine("=== ÚLTIMOS USUARIOS REGISTRADOS ===");
        Console.WriteLine();

        Console.Write("¿Cuántos usuarios desea ver? (por defecto 10): ");
        var countInput = Console.ReadLine();
        var count = string.IsNullOrEmpty(countInput) ? 10 : int.Parse(countInput);

        var users = await _usersController.GetLatestUsersAsync(count);
        if (users.Any())
        {
            foreach (var user in users)
            {
                DisplayUser(user);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No hay usuarios registrados.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task ShowUsersOrderedByLastNameAsync()
    {
        Console.Clear();
        Console.WriteLine("=== USUARIOS ORDENADOS POR APELLIDO ===");
        Console.WriteLine();

        var users = await _usersController.GetUsersOrderedByLastNameAsync();
        if (users.Any())
        {
            foreach (var user in users)
            {
                DisplayUser(user);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No hay usuarios registrados.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task ShowUsersWithoutPhoneAsync()
    {
        Console.Clear();
        Console.WriteLine("=== USUARIOS SIN TELÉFONO ===");
        Console.WriteLine();

        var users = await _usersController.GetUsersWithoutPhoneAsync();
        if (users.Any())
        {
            foreach (var user in users)
            {
                DisplayUser(user);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Todos los usuarios tienen teléfono registrado.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task ShowUsersWithoutAddressAsync()
    {
        Console.Clear();
        Console.WriteLine("=== USUARIOS SIN DIRECCIÓN ===");
        Console.WriteLine();

        var users = await _usersController.GetUsersWithoutAddressAsync();
        if (users.Any())
        {
            foreach (var user in users)
            {
                DisplayUser(user);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Todos los usuarios tienen dirección registrada.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    // Métodos de gestión
    private async Task CreateUserAsync()
    {
        Console.Clear();
        Console.WriteLine("=== CREAR NUEVO USUARIO ===");
        Console.WriteLine();

        var createDto = new CreateUserDTO();

        Console.Write("Nombre: ");
        createDto.FirstName = Console.ReadLine() ?? "";

        Console.Write("Apellido: ");
        createDto.LastName = Console.ReadLine() ?? "";

        Console.Write("Nombre de usuario: ");
        createDto.Username = Console.ReadLine() ?? "";

        Console.Write("Correo electrónico: ");
        createDto.Email = Console.ReadLine() ?? "";

        Console.Write("Contraseña: ");
        createDto.Password = Console.ReadLine() ?? "";

        Console.Write("Teléfono (opcional): ");
        createDto.Cellphone = Console.ReadLine();

        Console.Write("Dirección (opcional): ");
        createDto.Address = Console.ReadLine();

        Console.Write("Ciudad (opcional): ");
        createDto.City = Console.ReadLine();

        Console.Write("Estado (opcional): ");
        createDto.State = Console.ReadLine();

        Console.Write("Código postal (opcional): ");
        createDto.Zipcode = Console.ReadLine();

        Console.Write("País (opcional): ");
        createDto.Country = Console.ReadLine();

        Console.Write("Género (opcional): ");
        createDto.Gender = Console.ReadLine();

        Console.Write("Edad (opcional): ");
        var ageInput = Console.ReadLine();
        if (int.TryParse(ageInput, out int age))
        {
            createDto.Age = age;
        }

        try
        {
            var result = await _usersController.CreateUserAsync(createDto);
            Console.WriteLine();
            Console.WriteLine("¡Usuario creado exitosamente!");
            Console.WriteLine($"ID: {result.Id}");
            Console.WriteLine($"Nombre: {result.FirstName} {result.LastName}");
            Console.WriteLine($"Usuario: {result.Username}");
            Console.WriteLine($"Correo: {result.Email}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear el usuario: {ex.Message}");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task UpdateUserAsync()
    {
        Console.Clear();
        Console.WriteLine("=== ACTUALIZAR USUARIO ===");
        Console.WriteLine();

        Console.Write("Ingrese el ID del usuario a actualizar: ");
        if (long.TryParse(Console.ReadLine(), out long id))
        {
            var existingUser = await _usersController.GetUserByIdAsync(id);
            if (existingUser != null)
            {
                Console.WriteLine("Usuario encontrado:");
                DisplayUser(existingUser);
                Console.WriteLine();

                var updateDto = new UserUpdateDTO();

                Console.Write("Nuevo nombre de usuario (Enter para mantener actual): ");
                var username = Console.ReadLine();
                if (!string.IsNullOrEmpty(username))
                    updateDto.Username = username;

                Console.Write("Nuevo correo electrónico (Enter para mantener actual): ");
                var email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email))
                    updateDto.Email = email;

                Console.Write("Nuevo teléfono (Enter para mantener actual): ");
                var cellphone = Console.ReadLine();
                if (!string.IsNullOrEmpty(cellphone))
                    updateDto.Cellphone = cellphone;

                Console.Write("Nueva dirección (Enter para mantener actual): ");
                var address = Console.ReadLine();
                if (!string.IsNullOrEmpty(address))
                    updateDto.Address = address;

                Console.Write("Nueva ciudad (Enter para mantener actual): ");
                var city = Console.ReadLine();
                if (!string.IsNullOrEmpty(city))
                    updateDto.City = city;

                Console.Write("Nuevo estado (Enter para mantener actual): ");
                var state = Console.ReadLine();
                if (!string.IsNullOrEmpty(state))
                    updateDto.State = state;

                Console.Write("Nuevo código postal (Enter para mantener actual): ");
                var zipcode = Console.ReadLine();
                if (!string.IsNullOrEmpty(zipcode))
                    updateDto.Zipcode = zipcode;

                Console.Write("Nuevo país (Enter para mantener actual): ");
                var country = Console.ReadLine();
                if (!string.IsNullOrEmpty(country))
                    updateDto.Country = country;

                Console.Write("Nuevo género (Enter para mantener actual): ");
                var gender = Console.ReadLine();
                if (!string.IsNullOrEmpty(gender))
                    updateDto.Gender = gender;

                Console.Write("Nueva edad (Enter para mantener actual): ");
                var ageInput = Console.ReadLine();
                if (int.TryParse(ageInput, out int age))
                    updateDto.Age = age;

                try
                {
                    var updatedUser = await _usersController.UpdateUserAsync(id, updateDto);
                    if (updatedUser != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("¡Usuario actualizado exitosamente!");
                        DisplayUser(updatedUser);
                    }
                    else
                    {
                        Console.WriteLine("Error al actualizar el usuario.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar el usuario: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task ChangePasswordAsync()
    {
        Console.Clear();
        Console.WriteLine("=== CAMBIAR CONTRASEÑA ===");
        Console.WriteLine();

        Console.Write("Ingrese el ID del usuario: ");
        if (long.TryParse(Console.ReadLine(), out long id))
        {
            var existingUser = await _usersController.GetUserByIdAsync(id);
            if (existingUser != null)
            {
                Console.WriteLine($"Usuario: {existingUser.FirstName} {existingUser.LastName}");
                Console.WriteLine();

                var passwordDto = new UserChangePasswordDTO();

                Console.Write("Nueva contraseña: ");
                passwordDto.NewPassword = Console.ReadLine() ?? "";

                Console.Write("Confirmar nueva contraseña: ");
                var confirmPassword = Console.ReadLine();

                if (passwordDto.NewPassword == confirmPassword)
                {
                    try
                    {
                        var success = await _usersController.UpdateUserPasswordAsync(id, passwordDto);
                        if (success)
                        {
                            Console.WriteLine();
                            Console.WriteLine("¡Contraseña actualizada exitosamente!");
                        }
                        else
                        {
                            Console.WriteLine("Error al actualizar la contraseña.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al actualizar la contraseña: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Las contraseñas no coinciden.");
                }
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task DeleteUserByIdAsync()
    {
        Console.Clear();
        Console.WriteLine("=== ELIMINAR USUARIO POR ID ===");
        Console.WriteLine();

        Console.Write("Ingrese el ID del usuario a eliminar: ");
        if (long.TryParse(Console.ReadLine(), out long id))
        {
            var existingUser = await _usersController.GetUserByIdAsync(id);
            if (existingUser != null)
            {
                Console.WriteLine("Usuario encontrado:");
                DisplayUser(existingUser);
                Console.WriteLine();

                Console.Write("¿Está seguro de eliminar este usuario? (S/N): ");
                var confirmation = Console.ReadLine()?.ToUpper();

                if (confirmation == "S")
                {
                    try
                    {
                        var success = await _usersController.DeleteUserByIdAsync(id);
                        if (success)
                        {
                            Console.WriteLine();
                            Console.WriteLine("¡Usuario eliminado exitosamente!");
                        }
                        else
                        {
                            Console.WriteLine("Error al eliminar el usuario.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al eliminar el usuario: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Operación cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task DeleteUserByEmailAsync()
    {
        Console.Clear();
        Console.WriteLine("=== ELIMINAR USUARIO POR CORREO ===");
        Console.WriteLine();

        Console.Write("Ingrese el correo electrónico del usuario a eliminar: ");
        var email = Console.ReadLine();

        if (!string.IsNullOrEmpty(email))
        {
            var existingUser = await _usersController.GetUserByEmailAsync(email);
            if (existingUser != null)
            {
                Console.WriteLine("Usuario encontrado:");
                DisplayUser(existingUser);
                Console.WriteLine();

                Console.Write("¿Está seguro de eliminar este usuario? (S/N): ");
                var confirmation = Console.ReadLine()?.ToUpper();

                if (confirmation == "S")
                {
                    try
                    {
                        var success = await _usersController.DeleteUserByEmailAsync(email);
                        if (success)
                        {
                            Console.WriteLine();
                            Console.WriteLine("¡Usuario eliminado exitosamente!");
                        }
                        else
                        {
                            Console.WriteLine("Error al eliminar el usuario.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al eliminar el usuario: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Operación cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Correo electrónico inválido.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    // Métodos de reportes
    private async Task ShowTotalUsersCountAsync()
    {
        Console.Clear();
        Console.WriteLine("=== TOTAL DE USUARIOS REGISTRADOS ===");
        Console.WriteLine();

        var count = await _usersController.GetTotalUsersCountAsync();
        Console.WriteLine($"Total de usuarios registrados: {count}");

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task ShowUsersCountByCityAsync()
    {
        Console.Clear();
        Console.WriteLine("=== USUARIOS POR CIUDAD ===");
        Console.WriteLine();

        var counts = await _usersController.GetUsersCountByCityAsync();
        if (counts.Any())
        {
            foreach (var kvp in counts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} usuarios");
            }
        }
        else
        {
            Console.WriteLine("No hay datos disponibles.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    private async Task ShowUsersCountByCountryAsync()
    {
        Console.Clear();
        Console.WriteLine("=== USUARIOS POR PAÍS ===");
        Console.WriteLine();

        var counts = await _usersController.GetUsersCountByCountryAsync();
        if (counts.Any())
        {
            foreach (var kvp in counts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} usuarios");
            }
        }
        else
        {
            Console.WriteLine("No hay datos disponibles.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    // Método auxiliar para mostrar información del usuario
    private static void DisplayUser(UserDTO user)
    {
        Console.WriteLine($"ID: {user.Id}");
        Console.WriteLine($"Nombre: {user.FirstName} {user.LastName}");
        Console.WriteLine($"Usuario: {user.Username}");
        Console.WriteLine($"Correo: {user.Email}");
        if (!string.IsNullOrEmpty(user.Cellphone))
            Console.WriteLine($"Teléfono: {user.Cellphone}");
        if (!string.IsNullOrEmpty(user.Address))
            Console.WriteLine($"Dirección: {user.Address}");
        if (!string.IsNullOrEmpty(user.City))
            Console.WriteLine($"Ciudad: {user.City}");
        if (!string.IsNullOrEmpty(user.State))
            Console.WriteLine($"Estado: {user.State}");
        if (!string.IsNullOrEmpty(user.Zipcode))
            Console.WriteLine($"Código Postal: {user.Zipcode}");
        if (!string.IsNullOrEmpty(user.Country))
            Console.WriteLine($"País: {user.Country}");
        if (!string.IsNullOrEmpty(user.Gender))
            Console.WriteLine($"Género: {user.Gender}");
        if (user.Age.HasValue)
            Console.WriteLine($"Edad: {user.Age} años");
        Console.WriteLine($"Creado: {user.CreatedAt:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"Actualizado: {user.UpdatedAt:dd/MM/yyyy HH:mm}");
    }
}
