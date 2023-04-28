using System.Security.Claims;
using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ML.Mapper;
using ML.Models;

namespace UIL.Controllers;

public class CardController : Controller
{
    private readonly IPreporateRepository _preporateRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPreporateTypeRepository _preporateTypeRepository;
    private readonly ILogger _logger;
    public CardController(ILogger<CardController> logger,
        IPreporateRepository preporateRepository, 
        IUserRepository userRepository, 
        IPreporateTypeRepository preporateTypeRepository)
    {
        _logger = logger;
        _preporateRepository = preporateRepository;
        _userRepository = userRepository;
        _preporateTypeRepository = preporateTypeRepository;
    }
    [HttpGet]
    public IActionResult Index(int Id)
    {
        var prep = _preporateRepository.GetById(Id);
        return View("Preporate",prep);
    }
    [HttpGet]
    public IActionResult UserCard()
    {
        var id= Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
        User u = _userRepository.GetById(id);
        return View("User",u);
    }
    [HttpPost]
    public IActionResult UpdateUser(User u)
    {
        _userRepository.UpdateById(u.Id,u);
        return RedirectToAction("Index", "Home");
    }
    
    
    #region Type

    [HttpGet]
    public IActionResult TypeCard(int Id)
    {
        var vm = _preporateTypeRepository.GetById(Id);
        return View("Type",vm);
    }
    [HttpPost]
    public IActionResult TypeSave(PreporateType type)
    {
        _preporateTypeRepository.UpdateById(type.Id, type);
        return RedirectToAction("Types","Admin");
    }
    
    [HttpGet]
    public IActionResult TypeDel(int Id)
    {
        _preporateTypeRepository.DeleteById(Id);
        return RedirectToAction("Types","Admin");
    }
    [HttpGet]
    public IActionResult TypeAdd()
    {
        return View("Type",new PreporateType());
    }
    [HttpPost]
    public IActionResult TypeAddSave(PreporateType type)
    {
        _preporateTypeRepository.UpdateById(type.Id, type);
        return RedirectToAction("Types","Admin");
    }
    #endregion
}