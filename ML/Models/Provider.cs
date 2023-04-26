using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ML.Models;

public class Provider
{
    [Key]
    public int Id { get; set; }
    public string EMail { get; set; }
    [ForeignKey("Adress")]
    public int AdressId { get; set; }
    public Adress Adress { get; set; }
    public ICollection<Preporate> Preporates { get; set; }

    public Provider()
    {
        Preporates = new List<Preporate>();
    }
}