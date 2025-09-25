using Microsoft.EntityFrameworkCore;
using Sprint_2.Data;
using Sprint_2.Entities;

namespace Sprint_2.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }

    // Operaciones CRUD Básicas
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(long id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        user.CreatedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;
        
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> UpdateUserAsync(long id, User user)
    {
        var existingUser = await _context.Users.FindAsync(id);
        if (existingUser == null) return null;

        // Actualizar campos
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Username = user.Username;
        existingUser.Email = user.Email;
        existingUser.Cellphone = user.Cellphone;
        existingUser.Address = user.Address;
        existingUser.City = user.City;
        existingUser.State = user.State;
        existingUser.Zipcode = user.Zipcode;
        existingUser.Country = user.Country;
        existingUser.Gender = user.Gender;
        existingUser.Age = user.Age;
        existingUser.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return existingUser;
    }

    public async Task<bool> DeleteUserByIdAsync(long id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUserByEmailAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    // Operaciones de Verificación
    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _context.Users.AnyAsync(u => u.Username == username);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<bool> UpdateUserPasswordAsync(long id, string newPassword)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        user.Password = newPassword;
        user.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }

    // Consultas Básicas para Reportes
    public async Task<int> GetTotalUsersCountAsync()
    {
        return await _context.Users.CountAsync();
    }

    public async Task<Dictionary<string, int>> GetUsersCountByCityAsync()
    {
        return await _context.Users
            .Where(u => !string.IsNullOrEmpty(u.City))
            .GroupBy(u => u.City!)
            .ToDictionaryAsync(g => g.Key, g => g.Count());
    }

    public async Task<Dictionary<string, int>> GetUsersCountByCountryAsync()
    {
        return await _context.Users
            .Where(u => !string.IsNullOrEmpty(u.Country))
            .GroupBy(u => u.Country!)
            .ToDictionaryAsync(g => g.Key, g => g.Count());
    }
}