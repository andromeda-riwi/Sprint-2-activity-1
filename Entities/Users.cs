using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint_2_activity_1.Entities;

// El atributo [Table("...")] le dice a EF Core el nombre exacto de la tabla en la BD.
// Si tu tabla se llama "users", úsalo. Si no, ajústalo o quítalo si el nombre coincide con el DbSet.
[Table("users")] 
public class User
{
    [Key] // Marca 'Id' como la clave primaria.
    [Column("id")] // Mapea la propiedad 'Id' a la columna 'id' en la BD.
    public long Id { get; set; }

    [Required]
    [Column("first_name")]
    public string FirstName { get; set; }

    [Required]
    [Column("last_name")]
    public string LastName { get; set; }

    [Required]
    [Column("username")]
    public string Username { get; set; }

    [Required]
    [Column("email")]
    public string Email { get; set; }

    // En la BD es 'password', pero en la entidad es buena práctica llamarlo PasswordHash
    // para recordar que nunca debe contener texto plano.
    [Required]
    [Column("password")]
    public string PasswordHash { get; set; }

    // A partir de aquí, usamos tipos nullable (con '?') porque en la BD la columna "Nulo" es "Sí".
    
    [Column("phone")]
    public string? Phone { get; set; } // Añadí este campo que estaba en tu BD.

    [Column("cellphone")]
    public string? Cellphone { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("city")]
    public string? City { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("zipcode")]
    public string? Zipcode { get; set; }

    [Column("country")]
    public string? Country { get; set; }

    [Column("gender")]
    public string? Gender { get; set; }

    [Column("age")]
    public int? Age { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}