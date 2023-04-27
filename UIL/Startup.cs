using AutoMapper;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using DAL.Context;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ML;
using ML.Mapper;

namespace UIL;

public class Startup
{
    private IConfiguration ConfigRoot { get; set; }

    public Startup(IConfiguration config)
    {
        ConfigRoot = config;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => //CookieAuthenticationOptions
            {
                options.LoginPath = new PathString("/AccountVerification/Autentification");
                options.Cookie.Name = "LoginInfo";
            });

        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MapperImpl());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
        
        services.AddDbContext<AptecaContext>(options =>
        {
            var connectionString = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json")
                .Build()
                .GetSection("ConnectionString")
                .Value;
            
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IRegistrationService, RegistrationService>();
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPreporateRepository, PreporateRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IProviderRepository, ProviderRepository>();
        services.AddScoped<IPreporateTypeRepository, PreporateTypeRepository>();

        services.AddControllersWithViews();


    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddFile("Logs/mylog-{Date}.txt");

        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCookiePolicy();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}