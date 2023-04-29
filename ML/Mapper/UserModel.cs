using System.ComponentModel.DataAnnotations;

namespace ML.Mapper;

public class UserModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    public int RoleId { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    public string LastName { get; set; }
    [EmailAddress(ErrorMessage = "Неверный формат адреса электронной почты")]
    public string EMail { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    public string Password { get; set; }
}