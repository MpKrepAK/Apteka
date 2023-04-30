using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ML.Models;

public class Provider
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    [MaxLength(30)]
    public string EMail { get; set; }
    [MaxLength(100)]
    public string Adress { get; set; }
    public ICollection<Preporate> Preporates { get; set; }

    public Provider()
    {
        Preporates = new List<Preporate>();
    }
}