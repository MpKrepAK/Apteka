using System.ComponentModel.DataAnnotations;

namespace ML.Mapper;

public class RoleModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    public string Name { get; set; }
}