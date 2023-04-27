using Microsoft.AspNetCore.Mvc;

namespace UIL.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View("AdminNav");
    }
    public IActionResult Preporates()
    {
        return View();
    }
    public IActionResult Types()
    {
        return View();
    }
    public IActionResult Providers()
    {
        return View("AdminNav");
    }
    public IActionResult Roles()
    {
        return View("AdminNav");
    }
    public IActionResult Users()
    {
        return View("AdminNav");
    }
}