using System.ComponentModel.DataAnnotations;

namespace ML.Mapper;

public class ProviderModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 30 символов")]
    public string Name { get; set; }
    [EmailAddress(ErrorMessage = "Неверный формат адреса электронной почты")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 30 символов")]
    public string EMail { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 100 символов")]
    public string Adress { get; set; }
}