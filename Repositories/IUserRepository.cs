using Sprint_2.Entities;

namespace Sprint_2.Repositories;

public interface IUserRepository
{
    // Operaciones CRUD Básicas
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(long id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<User> CreateUserAsync(User user);
    Task<User?> UpdateUserAsync(long id, User user);
    Task<bool> DeleteUserByIdAsync(long id);
    Task<bool> DeleteUserByEmailAsync(string email);
    
    // Operaciones de Verificación
    Task<bool> UsernameExistsAsync(string username);
    Task<bool> EmailExistsAsync(string email);
    Task<bool> UpdateUserPasswordAsync(long id, string newPassword);
    
    // Consultas Básicas para Reportes
    Task<int> GetTotalUsersCountAsync();
    Task<Dictionary<string, int>> GetUsersCountByCityAsync();
    Task<Dictionary<string, int>> GetUsersCountByCountryAsync();
}