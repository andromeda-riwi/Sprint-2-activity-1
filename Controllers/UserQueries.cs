using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Sprint2activity1;             
using using Sprint2activity1.Entities;   

namespace DefaultNamespace.Controllers
{
    public class UserQueries
    {
        private readonly AppDbContext _context;

        public UserQueries(AppDbContext context)
        {
            _context = context;
        }

        public async Task MenuAsync()
        {
            int option;
            do
            {
                Console.WriteLine("\n--- CONSULTAS AVANZADAS DE USUARIOS ---");
                Console.WriteLine("1.  Listar todos los usuarios registrados");
                Console.WriteLine("2.  Ver detalle de un usuario por Id");
                Console.WriteLine("3.  Ver detalle de un usuario por correo electrónico");
                Console.WriteLine("4.  Listar usuarios por ciudad");
                Console.WriteLine("5.  Listar usuarios por país");
                Console.WriteLine("6.  Listar usuarios mayores de cierta edad");
                Console.WriteLine("7.  Listar usuarios por género");
                Console.WriteLine("8.  Mostrar nombres completos y correos");
                Console.WriteLine("9.  Contar total de usuarios");
                Console.WriteLine("10. Contar usuarios por ciudad");
                Console.WriteLine("11. Contar usuarios por país");
                Console.WriteLine("12. Listar usuarios sin teléfono");
                Console.WriteLine("13. Listar usuarios sin dirección");
                Console.WriteLine("14. Listar últimos usuarios registrados");
                Console.WriteLine("15. Listar usuarios ordenados por apellido");
                Console.WriteLine("0.  Volver");
                Console.Write("Elige una opción: ");

                if (!int.TryParse(Console.ReadLine(), out option)) option = -1;

                switch (option)
                {
                    case 1: await ListAllUsers(); break;
                    case 2: await GetUserById(); break;
                    case 3: await GetUserByEmail(); break;
                    case 4: await GetUsersByCity(); break;
                    case 5: await GetUsersByCountry(); break;
                    case 6: await GetUsersOlderThan(); break;
                    case 7: await GetUsersByGender(); break;
                    case 8: await GetNamesAndEmails(); break;
                    case 9: await CountUsers(); break;
                    case 10: await CountByCity(); break;
                    case 11: await CountByCountry(); break;
                    case 12: await UsersWithoutPhone(); break;
                    case 13: await UsersWithoutAddress(); break;
                    case 14: await LatestUsers(); break;
                    case 15: await UsersOrderedByLastName(); break;
                    case 0: Console.WriteLine("Volviendo..."); break;
                    default: Console.WriteLine("Opción inválida."); break;
                }

            } while (option != 0);
        }
        
        private void PrintUsers(List<UserDTO> users)
        {
            if (users == null || users.Count == 0)
            {
                Console.WriteLine("No se encontraron usuarios.");
                return;
            }

            Console.WriteLine("\nId | FirstName LastName | Username | Email | City | Country | Age");
            Console.WriteLine(new string('-', 80));
            foreach (var u in users)
            {
                Console.WriteLine($"{u.Id} | {u.FirstName} {u.LastName} | {u.Username} | {u.Email} | {u.City ?? "-"} | {u.Country ?? "-"} | {u.Age?.ToString() ?? "-"}");
            }
        }
        
        private async Task ListAllUsers()
        {
            var users = await _context.Users
                .Select(u => new UserDTO {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    Email = u.Email,
                    Cellphone = u.Cellphone,
                    Address = u.Address,
                    City = u.City,
                    State = u.State,
                    Zipcode = u.Zipcode,
                    Country = u.Country,
                    Gender = u.Gender,
                    Age = u.Age,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .ToListAsync();

            PrintUsers(users);
        }
        
        private async Task GetUserById()
        {
            Console.Write("Ingrese Id: ");
            if (!long.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            var user = await _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UserDTO {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    Email = u.Email,
                    Cellphone = u.Cellphone,
                    Address = u.Address,
                    City = u.City,
                    State = u.State,
                    Zipcode = u.Zipcode,
                    Country = u.Country,
                    Gender = u.Gender,
                    Age = u.Age,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .FirstOrDefaultAsync();

            if (user == null) Console.WriteLine("Usuario no encontrado.");
            else PrintUsers(new List<UserDTO> { user });
        }
        private async Task GetUserByEmail()
        {
            Console.Write("Ingrese email: ");
            var email = (Console.ReadLine() ?? "").Trim();
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Email inválido.");
                return;
            }

            var user = await _context.Users
                .Where(u => u.Email.ToLower() == email.ToLower())
                .Select(u => new UserDTO {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    Email = u.Email,
                    Cellphone = u.Cellphone,
                    Address = u.Address,
                    City = u.City,
                    State = u.State,
                    Zipcode = u.Zipcode,
                    Country = u.Country,
                    Gender = u.Gender,
                    Age = u.Age,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .FirstOrDefaultAsync();

            if (user == null) Console.WriteLine("Usuario no encontrado por ese correo.");
            else PrintUsers(new List<UserDTO> { user });
        }
        private async Task GetUsersByCity()
        {
            Console.Write("Ingrese nombre de la ciudad: ");
            var city = (Console.ReadLine() ?? "").Trim();
            var users = await _context.Users
                .Where(u => u.City == city)
                .Select(u => new UserDTO {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    Email = u.Email,
                    Cellphone = u.Cellphone,
                    Address = u.Address,
                    City = u.City,
                    State = u.State,
                    Zipcode = u.Zipcode,
                    Country = u.Country,
                    Gender = u.Gender,
                    Age = u.Age,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .ToListAsync();

            PrintUsers(users);
        }
        private async Task GetUsersByCountry()
        {
            Console.Write("Ingrese nombre del país: ");
            var country = (Console.ReadLine() ?? "").Trim();
            var users = await _context.Users
                .Where(u => u.Country == country)
                .Select(u => new UserDTO {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    Email = u.Email,
                    Cellphone = u.Cellphone,
                    Address = u.Address,
                    City = u.City,
                    State = u.State,
                    Zipcode = u.Zipcode,
                    Country = u.Country,
                    Gender = u.Gender,
                    Age = u.Age,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .ToListAsync();

            PrintUsers(users);
        }
        private async Task GetUsersOlderThan()
        {
            Console.Write("Ingrese edad mínima (ej: 18): ");
            if (!int.TryParse(Console.ReadLine(), out var age))
            {
                Console.WriteLine("Edad inválida.");
                return;
            }

            var users = await _context.Users
                .Where(u => u.Age.HasValue && u.Age >= age)
                .Select(u => new UserDTO {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    Email = u.Email,
                    Cellphone = u.Cellphone,
                    Address = u.Address,
                    City = u.City,
                    State = u.State,
                    Zipcode = u.Zipcode,
                    Country = u.Country,
                    Gender = u.Gender,
                    Age = u.Age,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .ToListAsync();

            PrintUsers(users);
        }
        private async Task GetUsersByGender()
        {
            Console.Write("Ingrese género (ej: Masculino / Femenino): ");
            var gender = (Console.ReadLine() ?? "").Trim();
            var users = await _context.Users
                .Where(u => u.Gender == gender)
                .Select(u => new UserDTO {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    Email = u.Email,
                    Cellphone = u.Cellphone,
                    Address = u.Address,
                    City = u.City,
                    State = u.State,
                    Zipcode = u.Zipcode,
                    Country = u.Country,
                    Gender = u.Gender,
                    Age = u.Age,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .ToListAsync();

            PrintUsers(users);
        }
        private async Task GetNamesAndEmails()
        {
            var list = await _context.Users
                .Select(u => new {
                    FullName = (u.FirstName ?? "") + " " + (u.LastName ?? ""),
                    u.Email
                })
                .ToListAsync();

            if (list == null || list.Count == 0)
            {
                Console.WriteLine("No hay usuarios.");
                return;
            }

            Console.WriteLine("\nFullName | Email");
            Console.WriteLine(new string('-', 60));
            foreach (var x in list)
                Console.WriteLine($"{x.FullName.Trim()} | {x.Email}");
        }
        
        private async Task CountUsers()
        {
            var total = await _context.Users.CountAsync();
            Console.WriteLine($"\nTotal de usuarios registrados: {total}");
        }

        private async Task CountByCity()
        {
            var groups = await _context.Users
                .GroupBy(u => u.City)
                .Select(g => new { City = g.Key, Count = g.Count() })
                .ToListAsync();

            Console.WriteLine("\nCiudad | Cantidad");
            Console.WriteLine(new string('-', 40));
            foreach (var g in groups)
            {
                var city = string.IsNullOrEmpty(g.City) ? "(Sin ciudad)" : g.City;
                Console.WriteLine($"{city} | {g.Count}");
            }
        }
        private async Task CountByCountry()
        {
            var groups = await _context.Users
                .GroupBy(u => u.Country)
                .Select(g => new { Country = g.Key, Count = g.Count() })
                .ToListAsync();

            Console.WriteLine("\nPaís | Cantidad");
            Console.WriteLine(new string('-', 40));
            foreach (var g in groups)
            {
                var country = string.IsNullOrEmpty(g.Country) ? "(Sin país)" : g.Country;
                Console.WriteLine($"{country} | {g.Count}");
            }
        }
        private async Task UsersWithoutPhone()
        {
            var users = await _context.Users
                .Where(u => u.Cellphone == null || u.Cellphone == "")
                .Select(u => new UserDTO {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    Email = u.Email,
                    Cellphone = u.Cellphone,
                    Address = u.Address,
                    City = u.City,
                    State = u.State,
                    Zipcode = u.Zipcode,
                    Country = u.Country,
                    Gender = u.Gender,
                    Age = u.Age,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .ToListAsync();

            PrintUsers(users);
        }
        private async Task UsersWithoutAddress()
        {
            var users = await _context.Users
                .Where(u => u.Address == null || u.Address == "")
                .Select(u => new UserDTO {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    Email = u.Email,
                    Cellphone = u.Cellphone,
                    Address = u.Address,
                    City = u.City,
                    State = u.State,
                    Zipcode = u.Zipcode,
                    Country = u.Country,
                    Gender = u.Gender,
                    Age = u.Age,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .ToListAsync();

            PrintUsers(users);
        }
        private async Task LatestUsers()
        {
            Console.Write("¿Cuántos últimos usuarios mostrar? (ej: 10): ");
            if (!int.TryParse(Console.ReadLine(), out var n)) n = 10;

            var users = await _context.Users
                .OrderByDescending(u => u.CreatedAt)
                .Take(n)
                .Select(u => new UserDTO {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    Email = u.Email,
                    Cellphone = u.Cellphone,
                    Address = u.Address,
                    City = u.City,
                    State = u.State,
                    Zipcode = u.Zipcode,
                    Country = u.Country,
                    Gender = u.Gender,
                    Age = u.Age,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .ToListAsync();

            PrintUsers(users);
        }
        private async Task UsersOrderedByLastName()
        {
            var users = await _context.Users
                .OrderBy(u => u.LastName)
                .Select(u => new UserDTO {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    Email = u.Email,
                    Cellphone = u.Cellphone,
                    Address = u.Address,
                    City = u.City,
                    State = u.State,
                    Zipcode = u.Zipcode,
                    Country = u.Country,
                    Gender = u.Gender,
                    Age = u.Age,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .ToListAsync();

            PrintUsers(users);
        }
    }
}
