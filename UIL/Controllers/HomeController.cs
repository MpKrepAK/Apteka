using System.Diagnostics;
using System.Security.Claims;
using AutoMapper;
using BLL.Services.Interfaces.EntityAUD;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using ML.Mapper;
using ML.Models;
using UIL.Models;

namespace UIL.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProviderRepository _providerRepository;
    private readonly IMapper _mapper;
    private readonly IPreporateRepository _preporateRepository;
    private readonly IPreporateTypeRepository _preporateTypeRepository;
    private readonly IPreporateService _preporateService;
    private readonly IUserService _userService;
    public HomeController(IProviderRepository providerRepository, 
        IMapper mapper,
        ILogger<HomeController> logger,
        IPreporateRepository preporateRepository,
        IPreporateTypeRepository preporateTypeRepository,
        IPreporateService preporateService,
        IUserService userService)
    {
        _mapper = mapper;
        _logger = logger;
        _providerRepository = providerRepository;
        _preporateRepository = preporateRepository;
        _preporateTypeRepository = preporateTypeRepository;
        _preporateService = preporateService;
        _userService = userService;
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> UserCard()
    {
        var user = _userService
            .GetById(Convert.ToInt32(
                User.Claims.FirstOrDefault(
                    x => x.Type == ClaimTypes.NameIdentifier).Value));
        await user;
        return View("User",user.Result);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> UserUpdate(UserModel user)
    {
        if (!ModelState.IsValid)
            return View("User", user);
        if (User.IsInRole("User"))
            user.RoleId = 1;
        var res = await _userService.Update(user);
        if (!res)
            return View("User", user);
        
        _logger.LogInformation($"Пользователь с Id {user.Id} изменен пользователем с Id {User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value}");
        return RedirectToAction("Index");
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> PreporateCard(int Id)
    {
        var preporate = _preporateService.GetById(Id);
        await preporate;
        if (preporate.Result == null)
            return RedirectToAction("Preporates", "Admin");
        return View("UserPreporate",preporate.Result);
    }
    public IActionResult Index(PreporatesSearch model)
    {
        PreporatesSearch vm;
        if (model==null)
            vm = new PreporatesSearch();
        else
            vm = model;
        
        vm.Providers = _providerRepository
            .GetAll()
            .Select(x=>_mapper.Map<Provider,ProviderModel>(x))
            .ToList();
        vm.Types = _preporateTypeRepository
            .GetAll()
            .Select(x=>_mapper.Map<PreporateType,TypeModel>(x))
            .ToList();
        vm.Preporates = _preporateRepository
            .GetAll()
            .Select(x=>_mapper.Map<Preporate,PreporateModel>(x))
            .ToList();
        
        if (!vm.Name.IsNullOrEmpty())
        {
            vm.Preporates=vm.Preporates
                .Where(x => x.Name.ToLower().Contains(vm.Name.ToLower()))
                .ToList();
        }
        vm.Preporates=vm.Preporates
            .Where(x=>x.DateOfProduction>=model.DateOfProductionDown&&x.DateOfProduction<=model.DateOfProductionUp)
            .ToList();

        if (model.SelctedProviders!=null)
        {
            vm.Preporates = vm.Preporates.Where(x => model.SelctedProviders.Contains(x.ProviderId)).ToList();
        }
        if (model.SelctedTypes!=null)
        {
            vm.Preporates = vm.Preporates.Where(x => model.SelctedTypes.Contains(x.PreporateTypeId)).ToList();
        }
        
        return View(vm);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}