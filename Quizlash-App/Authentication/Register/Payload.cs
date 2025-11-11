using System.ComponentModel.DataAnnotations;

namespace Quizlash_App.Authentication.Register;

public class Payload
{
    [Required]
    [MaxLength(50)]
    [RegularExpression(@"^\S+$", ErrorMessage = "Username must not contain spaces.")]
    public string Username { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string MiddleName { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public string Gender { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(320)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public string Address1 { get; set; } = string.Empty;

    [Required]
    public string Address2 { get; set; } = string.Empty;

    [Required]
    public string PhoneCountryCode { get; set; } = string.Empty;

    [Required]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public string CountryCode { get; set; } = string.Empty;

    [Required]
    public string ZipCode { get; set; } = string.Empty;
}
