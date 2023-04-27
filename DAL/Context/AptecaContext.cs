using Microsoft.EntityFrameworkCore;
using ML.Models;

namespace DAL.Context;

public class AptecaContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Preporate> Preporates { get; set; } = null!;
    public DbSet<Provider> Providers { get; set; } = null!;
    public DbSet<PreporateType> Types { get; set; } = null!;
    public AptecaContext(DbContextOptions<AptecaContext> options):base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
        //Create();
    }

    private void Create()
    {
        Roles.AddRange(
            new List<Role>()
            {
                new Role() { Name = "User" },
                new Role() { Name = "Admin" }
            });
        Users.AddRange(
            new List<User>()
            {
                new User() { RoleId = 1, FirstName = "Петр", LastName = "Петров", Password = "1", EMail = "1@mail.ru"},
                new User() { RoleId = 2, FirstName = "Василий", LastName = "Васильев", Password = "2", EMail = "2@mail.ru"}
            });
        Providers.AddRange(
            new List<Provider>()
            {
                new Provider(){EMail = "123@mail.ru", Adress = "Россия, Пермь"},
                new Provider(){EMail = "123@mail.ru", Adress = "Беларусь, Пинск"}
            });
        Types.AddRange(
            new List<PreporateType>()
            {
                new PreporateType(){Name = "Таблетки"},
                new PreporateType(){Name = "Сироп"}
            });
        SaveChanges();
        Preporates.AddRange(
            new List<Preporate>()
            {
                new Preporate(){Name = "Ацикловир", PreporateTypeId = 1, ProviderId = 1, Cost = 3, DateOfProduction = DateTime.Now, Count = 34},
                new Preporate(){Name = "Амепрозол", PreporateTypeId = 2, ProviderId = 2, Cost = 3, DateOfProduction = DateTime.Now, Count = 4534}
            });
        SaveChanges();
    }
}