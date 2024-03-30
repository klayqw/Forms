using System.ComponentModel.DataAnnotations;

namespace Steam.Core.Dto;
public class RegistrationDto
{
    [EmailAddress]
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
