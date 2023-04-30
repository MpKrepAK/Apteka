using System.ComponentModel.DataAnnotations;

namespace ML.Mapper;

public class UserRegistration
{
    [EmailAddress(ErrorMessage = "Неверный формат адреса электронной почты")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 30 символов")]
    public string EMail { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "Длина должна быть от 6 до 20 символов")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 20 символов")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 20 символов")]
    public string LastName { get; set; }
}