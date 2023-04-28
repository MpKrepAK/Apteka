using ML.Mapper;

namespace UIL.Models;

public class RolesSearch
{
    public string Name { get; set; }
    public List<RoleModel> Roles { get; set; } = new List<RoleModel>();
}