namespace DefaultNamespace;

public class UserDTO
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
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
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password {  get; set; }
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
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}

public class UserUpdateDTO
{
    public string Username { get; set; }
    public string Email { get; set; }
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
    public string Password { get; set; }
    public string NewPassword { get; set; }
}

