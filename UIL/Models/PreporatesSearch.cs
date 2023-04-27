using Microsoft.AspNetCore.Mvc.Rendering;
using ML.Models;

namespace UIL.Models;

public class PreporatesSearch
{
    public List<Provider> Providers { get; set; }
    public string Name { get; set; }
    public string Provider { get; set; }
    public int Type { get; set; }
    public int Appointment { get; set; }
    public DateTime DateUp { get; set; }=DateTime.Now;
    public DateTime DateDown { get; set; } = new DateTime(2022, 1, 1);
}