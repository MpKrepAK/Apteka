using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ML.Models;

public class Provider
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string EMail { get; set; }
    public string Adress { get; set; }
    public ICollection<Preporate> Preporates { get; set; }

    public Provider()
    {
        Preporates = new List<Preporate>();
    }
}