using Sprint_2.DTOs;
using Sprint_2.Entities;
using Sprint_2.Repositories;

namespace Sprint_2.Controllers;

public class UsersController
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    // Consultas Funcionales del Módulo de Usuarios
    public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Select(MapToDTO);
    }

    public async Task<UserDTO?> GetUserByIdAsync(long id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        return user != null ? MapToDTO(user) : null;
    }

    public async Task<UserDTO?> GetUserByEmailAsync(string email)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        return user != null ? MapToDTO(user) : null;
    }

    public async Task<IEnumerable<UserDTO>> GetUsersByCityAsync(string city)
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Where(u => u.City == city).Select(MapToDTO);
    }

    public async Task<IEnumerable<UserDTO>> GetUsersByCountryAsync(string country)
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Where(u => u.Country == country).Select(MapToDTO);
    }

    public async Task<IEnumerable<UserDTO>> GetUsersOlderThanAsync(int age)
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Where(u => u.Age.HasValue && u.Age > age).Select(MapToDTO);
    }

    public async Task<IEnumerable<UserDTO>> GetUsersByGenderAsync(string gender)
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Where(u => u.Gender == gender).Select(MapToDTO);
    }

    public async Task<IEnumerable<object>> GetUsersNamesAndEmailsAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Select(u => new { 
            FullName = $"{u.FirstName} {u.LastName}", 
            Email = u.Email 
        });
    }

    public async Task<int> GetTotalUsersCountAsync()
    {
        return await _userRepository.GetTotalUsersCountAsync();
    }

    public async Task<Dictionary<string, int>> GetUsersCountByCityAsync()
    {
        return await _userRepository.GetUsersCountByCityAsync();
    }

    public async Task<Dictionary<string, int>> GetUsersCountByCountryAsync()
    {
        return await _userRepository.GetUsersCountByCountryAsync();
    }

    public async Task<IEnumerable<UserDTO>> GetUsersWithoutPhoneAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Where(u => string.IsNullOrEmpty(u.Cellphone)).Select(MapToDTO);
    }

    public async Task<IEnumerable<UserDTO>> GetUsersWithoutAddressAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Where(u => string.IsNullOrEmpty(u.Address)).Select(MapToDTO);
    }

    public async Task<IEnumerable<UserDTO>> GetLatestUsersAsync(int count = 10)
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.OrderByDescending(u => u.CreatedAt).Take(count).Select(MapToDTO);
    }

    public async Task<IEnumerable<UserDTO>> GetUsersOrderedByLastNameAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.OrderBy(u => u.LastName).Select(MapToDTO);
    }

    // Módulo de Eliminación
    public async Task<bool> DeleteUserByIdAsync(long id)
    {
        return await _userRepository.DeleteUserByIdAsync(id);
    }

    public async Task<bool> DeleteUserByEmailAsync(string email)
    {
        return await _userRepository.DeleteUserByEmailAsync(email);
    }

    // Módulo de Actualización
    public async Task<UserDTO?> UpdateUserAsync(long id, UserUpdateDTO updateDto)
    {
        if (updateDto == null)
            throw new ArgumentNullException(nameof(updateDto));

        var existingUser = await _userRepository.GetUserByIdAsync(id);
        if (existingUser == null) 
            return null;

        // Validar unicidad de username si se está actualizando
        if (!string.IsNullOrEmpty(updateDto.Username) && updateDto.Username != existingUser.Username)
        {
            if (await _userRepository.UsernameExistsAsync(updateDto.Username))
                throw new InvalidOperationException("El nombre de usuario ya existe.");
        }

        // Validar unicidad de email si se está actualizando
        if (!string.IsNullOrEmpty(updateDto.Email) && updateDto.Email != existingUser.Email)
        {
            if (await _userRepository.EmailExistsAsync(updateDto.Email))
                throw new InvalidOperationException("El correo electrónico ya existe.");
        }

        // Actualizar solo los campos proporcionados
        if (!string.IsNullOrEmpty(updateDto.Username))
            existingUser.Username = updateDto.Username;
        if (!string.IsNullOrEmpty(updateDto.Email))
            existingUser.Email = updateDto.Email;
        if (updateDto.Cellphone != null)
            existingUser.Cellphone = updateDto.Cellphone;
        if (updateDto.Address != null)
            existingUser.Address = updateDto.Address;
        if (updateDto.City != null)
            existingUser.City = updateDto.City;
        if (updateDto.State != null)
            existingUser.State = updateDto.State;
        if (updateDto.Zipcode != null)
            existingUser.Zipcode = updateDto.Zipcode;
        if (updateDto.Country != null)
            existingUser.Country = updateDto.Country;
        if (updateDto.Gender != null)
            existingUser.Gender = updateDto.Gender;
        if (updateDto.Age.HasValue)
            existingUser.Age = updateDto.Age;

        var updatedUser = await _userRepository.UpdateUserAsync(id, existingUser);
        return updatedUser != null ? MapToDTO(updatedUser) : null;
    }

    public async Task<bool> UpdateUserPasswordAsync(long id, UserChangePasswordDTO passwordDto)
    {
        return await _userRepository.UpdateUserPasswordAsync(id, passwordDto.NewPassword);
    }

    // Módulo de Inserción
    public async Task<UserResponseDTO> CreateUserAsync(CreateUserDTO createDto)
    {
        if (createDto == null)
            throw new ArgumentNullException(nameof(createDto));

        // Validar campos obligatorios
        ValidateRequiredFields(createDto);

        // Verificar si el username ya existe
        if (await _userRepository.UsernameExistsAsync(createDto.Username))
        {
            throw new InvalidOperationException("El nombre de usuario ya existe.");
        }

        // Verificar si el email ya existe
        if (await _userRepository.EmailExistsAsync(createDto.Email))
        {
            throw new InvalidOperationException("El correo electrónico ya existe.");
        }

        // Validar formato de email
        if (!IsValidEmail(createDto.Email))
        {
            throw new ArgumentException("El formato del correo electrónico no es válido.");
        }

        // Validar edad si se proporciona
        if (createDto.Age.HasValue && (createDto.Age < 0 || createDto.Age > 150))
        {
            throw new ArgumentException("La edad debe estar entre 0 y 150 años.");
        }

        var user = new User
        {
            FirstName = createDto.FirstName.Trim(),
            LastName = createDto.LastName.Trim(),
            Username = createDto.Username.Trim(),
            Email = createDto.Email.Trim().ToLower(),
            Password = createDto.Password,
            Cellphone = createDto.Cellphone?.Trim(),
            Address = createDto.Address?.Trim(),
            City = createDto.City?.Trim(),
            State = createDto.State?.Trim(),
            Zipcode = createDto.Zipcode?.Trim(),
            Country = createDto.Country?.Trim(),
            Gender = createDto.Gender?.Trim(),
            Age = createDto.Age
        };

        var createdUser = await _userRepository.CreateUserAsync(user);
        
        return new UserResponseDTO
        {
            Id = createdUser.Id,
            FirstName = createdUser.FirstName,
            LastName = createdUser.LastName,
            Username = createdUser.Username,
            Email = createdUser.Email
        };
    }

    // Método auxiliar para mapear de User a UserDTO
    private static UserDTO MapToDTO(User user)
    {
        return new UserDTO
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username,
            Email = user.Email,
            Cellphone = user.Cellphone,
            Address = user.Address,
            City = user.City,
            State = user.State,
            Zipcode = user.Zipcode,
            Country = user.Country,
            Gender = user.Gender,
            Age = user.Age,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }

    // Métodos de validación auxiliares
    private static void ValidateRequiredFields(CreateUserDTO createDto)
    {
        if (string.IsNullOrWhiteSpace(createDto.FirstName))
            throw new ArgumentException("El nombre es obligatorio.");
        
        if (string.IsNullOrWhiteSpace(createDto.LastName))
            throw new ArgumentException("El apellido es obligatorio.");
        
        if (string.IsNullOrWhiteSpace(createDto.Username))
            throw new ArgumentException("El nombre de usuario es obligatorio.");
        
        if (string.IsNullOrWhiteSpace(createDto.Email))
            throw new ArgumentException("El correo electrónico es obligatorio.");
        
        if (string.IsNullOrWhiteSpace(createDto.Password))
            throw new ArgumentException("La contraseña es obligatoria.");
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    // Métodos adicionales para operaciones CRUD más específicas
    public async Task<bool> UserExistsAsync(long id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        return user != null;
    }

    public async Task<bool> UserExistsByEmailAsync(string email)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        return user != null;
    }

    public async Task<bool> UserExistsByUsernameAsync(string username)
    {
        return await _userRepository.UsernameExistsAsync(username);
    }

    // Método para obtener estadísticas completas
    public async Task<object> GetUserStatisticsAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        var usersByCity = await _userRepository.GetUsersCountByCityAsync();
        var usersByCountry = await _userRepository.GetUsersCountByCountryAsync();

        return new
        {
            TotalUsers = users.Count(),
            UsersByCity = usersByCity,
            UsersByCountry = usersByCountry,
            UsersWithoutPhone = users.Count(u => string.IsNullOrEmpty(u.Cellphone)),
            UsersWithoutAddress = users.Count(u => string.IsNullOrEmpty(u.Address))
        };
    }

    // Método para búsqueda avanzada
    public async Task<IEnumerable<UserDTO>> SearchUsersAsync(string? searchTerm = null, string? city = null, string? country = null, string? gender = null, int? minAge = null, int? maxAge = null)
    {
        var allUsers = await _userRepository.GetAllUsersAsync();
        var query = allUsers.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var term = searchTerm.ToLower();
            query = query.Where(u => 
                u.FirstName.ToLower().Contains(term) ||
                u.LastName.ToLower().Contains(term) ||
                u.Username.ToLower().Contains(term) ||
                u.Email.ToLower().Contains(term));
        }

        if (!string.IsNullOrWhiteSpace(city))
        {
            query = query.Where(u => u.City == city);
        }

        if (!string.IsNullOrWhiteSpace(country))
        {
            query = query.Where(u => u.Country == country);
        }

        if (!string.IsNullOrWhiteSpace(gender))
        {
            query = query.Where(u => u.Gender == gender);
        }

        if (minAge.HasValue)
        {
            query = query.Where(u => u.Age.HasValue && u.Age >= minAge);
        }

        if (maxAge.HasValue)
        {
            query = query.Where(u => u.Age.HasValue && u.Age <= maxAge);
        }

        return query.Select(MapToDTO);
    }
}