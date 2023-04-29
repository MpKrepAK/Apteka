using ML.Mapper;

namespace UIL.Models;

public class UsersSearch
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EMail { get; set; }
    public string Password { get; set; }
    public List<UserModel> Users { get; set; }
    public List<RoleModel> Roles { get; set; }
    public List<int> SelectedRoles { get; set; }
}