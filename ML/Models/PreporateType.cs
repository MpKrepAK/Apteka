using System.ComponentModel.DataAnnotations;

namespace ML.Models;

public class PreporateType
{
    [Key] 
    public int Id { get; set; }
    [MaxLength(20)]
    public string Name { get; set; }
}