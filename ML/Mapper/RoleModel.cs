using System.ComponentModel.DataAnnotations;

namespace ML.Mapper;

public class RoleModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 20 символов")]
    public string Name { get; set; }
}