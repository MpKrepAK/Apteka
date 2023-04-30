using Microsoft.AspNetCore.Mvc.Rendering;
using ML.Mapper;
using ML.Models;

namespace UIL.Models;

public class PreporatesSearch
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<int> SelctedProviders { get; set; }
    public List<int> SelctedTypes { get; set; }
    public List<ProviderModel> Providers { get; set; }
    public List<TypeModel> Types { get; set; }
    public List<PreporateModel> Preporates { get; set; }
    public DateTime DateOfProductionUp { get; set; }
    public DateTime DateOfProductionDown { get; set; }

    public PreporatesSearch()
    {
        DateOfProductionUp=DateTime.Now;
        DateOfProductionDown = new DateTime(2000, 1, 1);
    }
}