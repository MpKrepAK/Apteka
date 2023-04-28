using System.ComponentModel.DataAnnotations;

namespace ML.Mapper;

public class TypeModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    public string Name { get; set; }
}