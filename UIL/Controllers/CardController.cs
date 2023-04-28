using System.Security.Claims;
using AutoMapper;
using BLL.Services.Interfaces.EntityAUD;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ML.Mapper;
using ML.Models;

namespace UIL.Controllers;

[Authorize(Roles="Admin")]
public class CardController : Controller
{
    private readonly IPreporateRepository _preporateRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPreporateTypeRepository _preporateTypeRepository;
    private readonly ILogger _logger;
    private readonly IPreporateTypeService _preporateTypeService;
    private readonly IMapper _mapper;
    public CardController(ILogger<CardController> logger,
        IMapper mapper,
        IPreporateRepository preporateRepository, 
        IUserRepository userRepository, 
        IPreporateTypeRepository preporateTypeRepository, 
        IPreporateTypeService preporateTypeService)
    {
        _logger = logger;
        _mapper = mapper;
        _preporateRepository = preporateRepository;
        _userRepository = userRepository;
        _preporateTypeRepository = preporateTypeRepository;
        _preporateTypeService = preporateTypeService;
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
        var type = _preporateTypeRepository.GetById(Id);
        var vm = _mapper.Map<PreporateType, TypeModel>(type);
        return View("Type",vm);
    }
    
    [HttpGet]
    public IActionResult TypeAdd()
    {
        return View("AddType",new TypeModel());
    }
    
    [HttpGet]
    public async Task<IActionResult> TypeDel(int Id)
    {
        var res= await _preporateTypeService.Delete(Id);
        if (res)
            _logger.LogInformation($"Тип препората с Id {Id} удален пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Types","Admin");
    }
    
    [HttpPost]
    public async Task<IActionResult> TypeUpdate(TypeModel type)
    {
        if (!ModelState.IsValid)
            return View("Type", type);
        var res = await _preporateTypeService.Update(type);
        if (!res)
            return View("Type", type);
        _logger.LogInformation($"Тип препората с Id {type.Id} изменен пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Types","Admin");
    }
    
    [HttpPost]
    public async Task<IActionResult> TypeAddSave(TypeModel type)
    {
        if (!ModelState.IsValid)
            return View("AddType", type);
        var res = await _preporateTypeService.Add(type);
        if (!res)
            return View("AddType", type);
        _logger.LogInformation($"Тип препората с добавлен пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Types","Admin");
    }
    #endregion
}