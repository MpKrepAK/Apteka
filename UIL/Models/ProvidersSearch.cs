using ML.Mapper;

namespace UIL.Models;

public class ProvidersSearch
{
    public string Name { get; set; }
    public string EMail { get; set; }
    public string Adress { get; set; }
    public List<ProviderModel> Providers { get; set; } = new List<ProviderModel>();
}