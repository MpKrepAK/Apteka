using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ML.Mapper;

public class PreporateModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 50 символов")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    public int ProviderId { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    public int PreporateTypeId { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    public DateTime DateOfProduction { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    [Range(1, 1000, ErrorMessage = "Недопустимая цена")]
    public double Cost { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    [Range(1, 1000, ErrorMessage = "Недопустимое количество")]
    public int Count { get; set; }
    public IFormFile? ImageFile { get; set; }
    public byte[]? Image { get; set; }
}