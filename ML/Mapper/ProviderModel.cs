using System.ComponentModel.DataAnnotations;

namespace ML.Mapper;

public class ProviderModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    public string Name { get; set; }
    [EmailAddress(ErrorMessage = "Неверный формат адреса электронной почты")]
    public string EMail { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    public string Adress { get; set; }
}