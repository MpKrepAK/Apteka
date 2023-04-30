using System.ComponentModel.DataAnnotations;

namespace ML.Mapper;

public class UserModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    public int RoleId { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 20 символов")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 20 символов")]
    public string LastName { get; set; }
    [EmailAddress(ErrorMessage = "Неверный формат адреса электронной почты")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 30 символов")]
    public string EMail { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 20 символов")]
    public string Password { get; set; }
}