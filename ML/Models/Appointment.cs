using System.ComponentModel.DataAnnotations;

namespace ML.Models;

public class Appointment
{
    [Key] 
    public int Id { get; set; }

    public string Name { get; set; }
    public ICollection<Preporate> Preporates { get; set; }

    public Appointment()
    {
        Preporates = new List<Preporate>();
    }
}