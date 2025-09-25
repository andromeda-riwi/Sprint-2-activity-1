namespace Sprint_2.DTOs;

public class UserDTO
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Cellphone { get; set; }
    public string? Address  { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zipcode { get; set; }
    public string? Country { get; set; }
    public string? Gender  { get; set; }
    public int? Age  { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class CreateUserDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password {  get; set; } = string.Empty;
    public string? Cellphone { get; set; }
    public string? Address  { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zipcode { get; set; }
    public string? Country { get; set; }
    public string? Gender  { get; set; }
    public int? Age  { get; set; }

}


public class UserResponseDTO
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class UserUpdateDTO
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Cellphone { get; set; }
    public string? Address  { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zipcode { get; set; }
    public string? Country { get; set; }
    public string? Gender  { get; set; }
    public int? Age  { get; set; }
}

public class UserChangePasswordDTO
{
    public string Password { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}

