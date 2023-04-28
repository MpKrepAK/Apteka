using ML.Mapper;

namespace UIL.Models;

public class TypesSearch
{
    public string Name { get; set; }
    public List<TypeModel> Types { get; set; } = new List<TypeModel>();
}