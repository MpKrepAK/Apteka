using System.ComponentModel.DataAnnotations;

namespace ML.Models;

public class Role
{
    [Key] 
    public int Id { get; set; }

    public string Name { get; set; }
    public ICollection<User> Users { get; set; }

    public Role()
    {
        Users = new List<User>();
    }
}