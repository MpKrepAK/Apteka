using System.Diagnostics;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UIL.Models;

namespace UIL.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProviderRepository _providerRepository;
    public HomeController(ILogger<HomeController> logger, IProviderRepository providerRepository)
    {
        _logger = logger;
        _providerRepository = providerRepository;
    }

    public IActionResult Index()
    {
        var vm = new PreporatesSearch()
        {
            //Providers = _providerRepository.GetAll().ToList()
        };
        
        return View("Index",vm);
    }
    
    [HttpPost]
    public IActionResult Filtered(PreporatesSearch preporatesSearch)
    {
        //Console.WriteLine(preporatesSearch.Providers);
        return View("Index",preporatesSearch);
    }
    
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}