using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ML.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Role")]
    public int RoleId { get; set; }
    public Role Role { get; set; }
    [MaxLength(20)]
    public string FirstName { get; set; }
    [MaxLength(20)]
    public string LastName { get; set; }
    [MaxLength(30)]
    public string EMail { get; set; }
    [MaxLength(20)]
    public string Password { get; set; }
}