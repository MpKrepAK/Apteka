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
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    
    private readonly IPreporateTypeService _preporateTypeService;
    private readonly IRoleService _roleService;
    private readonly IProviderService _providerService;
    private readonly IUserService _userService;
    private readonly IPreporateService _preporateService;
    
    public CardController(ILogger<CardController> logger,
        IMapper mapper,
        IPreporateTypeService preporateTypeService,
        IRoleService roleService,
        IProviderService providerService,
        IUserService userService,
        IPreporateService preporateService)
    {
        _logger = logger;
        _mapper = mapper;
        
        _preporateTypeService = preporateTypeService;
        _roleService = roleService;
        _providerService = providerService;
        _userService = userService;
        _preporateService = preporateService;
    }
    
    // [HttpGet]
    // public IActionResult Index()
    // {
    //     return View("Preporate");
    // }

    #region Type

    [HttpGet]
    public async Task<IActionResult> TypeCard(int Id)
    {
        var type = _preporateTypeService.GetById(Id);
        await type;
        if (type.Result == null)
            return RedirectToAction("Types", "Admin");
        return View("Type",type.Result);
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
        _logger.LogInformation($"Тип препората добавлен пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Types","Admin");
    }
    #endregion
    
    #region Role

    [HttpGet]
    public async Task<IActionResult> RoleCard(int Id)
    {
        var role = _roleService.GetById(Id);
        await role;
        if (role.Result == null)
            return RedirectToAction("Roles", "Admin");
        return View("Role",role.Result);
    }
    
    [HttpGet]
    public IActionResult RoleAdd()
    {
        return View("AddRole",new RoleModel());
    }
    
    [HttpGet]
    public async Task<IActionResult> RoleDel(int Id)
    {
        var res= await _roleService.Delete(Id);
        if (res)
            _logger.LogInformation($"Роль с Id {Id} удалена пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Roles","Admin");
    }
    
    [HttpPost]
    public async Task<IActionResult> RoleUpdate(RoleModel type)
    {
        if (!ModelState.IsValid)
            return View("Role", type);
        var res = await _roleService.Update(type);
        if (!res)
            return View("Role", type);
        _logger.LogInformation($"Роль с Id {type.Id} изменена пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Roles","Admin");
    }
    
    [HttpPost]
    public async Task<IActionResult> RoleAddSave(RoleModel type)
    {
        if (!ModelState.IsValid)
            return View("AddRole", type);
        var res = await _roleService.Add(type);
        if (!res)
            return View("AddRole", type);
        _logger.LogInformation($"Роль добавлена пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Roles","Admin");
    }
    #endregion
    
    #region Provider

    [HttpGet]
    public async Task<IActionResult> ProviderCard(int Id)
    {
        var provider = _providerService.GetById(Id);
        await provider;
        if (provider.Result == null)
            return RedirectToAction("Types", "Admin");
        return View("Provider",provider.Result);
    }
    
    [HttpGet]
    public IActionResult ProviderAdd()
    {
        return View("AddProvider",new ProviderModel());
    }
    
    [HttpGet]
    public async Task<IActionResult> ProviderDel(int Id)
    {
        var res= await _providerService.Delete(Id);
        if (res)
            _logger.LogInformation($"Поставщик Id {Id} удален пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Providers","Admin");
    }
    
    [HttpPost]
    public async Task<IActionResult> ProviderUpdate(ProviderModel provider)
    {
        if (!ModelState.IsValid)
            return View("Provider", provider);
        var res = await _providerService.Update(provider);
        if (!res)
            return View("Provider", provider);
        _logger.LogInformation($"Поставщик с Id {provider.Id} изменен пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Providers","Admin");
    }
    
    [HttpPost]
    public async Task<IActionResult> ProviderAddSave(ProviderModel provider)
    {
        if (!ModelState.IsValid)
            return View("AddProvider", provider);
        var res = await _providerService.Add(provider);
        if (!res)
            return View("AddProvider", provider);
        _logger.LogInformation($"Поставщик добавлен пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Providers","Admin");
    }
    #endregion
    
    #region User

    [HttpGet]
    public async Task<IActionResult> UserCard(int Id)
    {
        var user = _userService.GetById(Id);
        await user;
        if (user.Result == null)
            return RedirectToAction("Users", "Admin");
        return View("User",user.Result);
    }
    
    [HttpGet]
    public IActionResult UserAdd()
    {
        return View("AddUser",new UserModel());
    }
    
    [HttpGet]
    public async Task<IActionResult> UserDel(int Id)
    {
        var res= await _userService.Delete(Id);
        if (res)
            _logger.LogInformation($"Пользователь с Id {Id} удален пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Users","Admin");
    }
    
    [HttpPost]
    public async Task<IActionResult> UserUpdate(UserModel user)
    {
        if (!ModelState.IsValid)
            return View("User", user);
        var res = await _userService.Update(user);
        if (!res)
            return View("User", user);
        _logger.LogInformation($"Пользователь с Id {user.Id} изменен пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Users","Admin");
    }
    
    [HttpPost]
    public async Task<IActionResult> UserAddSave(UserModel user)
    {
        if (!ModelState.IsValid)
            return View("AddUser", user);
        var res = await _userService.Add(user);
        if (!res)
            return View("AddUser", user);
        _logger.LogInformation($"Пользователь добавлен пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Users","Admin");
    }
    #endregion
    
    #region Preporate

    [HttpGet]
    public async Task<IActionResult> PreporateCard(int Id)
    {
        var preporate = _preporateService.GetById(Id);
        await preporate;
        if (preporate.Result == null)
            return RedirectToAction("Preporates", "Admin");
        return View("Preporate",preporate.Result);
    }
    
    [HttpGet]
    public IActionResult PreporateAdd()
    {
        return View("AddPreporate",new PreporateModel());
    }
    
    [HttpGet]
    public async Task<IActionResult> PreporateDel(int Id)
    {
        var res= await _preporateService.Delete(Id);
        if (res)
            _logger.LogInformation($"Прерорат с Id {Id} удален пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Preporates","Admin");
    }
    
    [HttpPost]
    public async Task<IActionResult> PreporateUpdate(PreporateModel preporate)
    {
        Console.WriteLine(preporate.PreporateTypeId);
        Console.WriteLine(ModelState.IsValid);
        if (!ModelState.IsValid)
            return View("Preporate", preporate);
        var res = await _preporateService.Update(preporate);
        if (!res)
            return View("Preporate", preporate);
        _logger.LogInformation($"Прерорат с Id {preporate.Id} изменен пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Preporates","Admin");
    }
    
    [HttpPost]
    public async Task<IActionResult> PreporateAddSave(PreporateModel preporate)
    {
        if (!ModelState.IsValid)
            return View("AddPreporate", preporate);
        var res = await _preporateService.Add(preporate);
        if (!res)
            return View("AddPreporate", preporate);
        _logger.LogInformation($"Прерорат добавлен пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Preporates","Admin");
    }
    #endregion
}