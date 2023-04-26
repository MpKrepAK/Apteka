using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ML.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Role")]
    public int? RoleId { get; set; }
    public Role Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EMail { get; set; }
    public string Password { get; set; }
    public byte[]? Image { get; set; }
}