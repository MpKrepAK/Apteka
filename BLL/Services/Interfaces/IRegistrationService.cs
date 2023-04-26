using ML.Mapper;

namespace BLL.Services.Interfaces;

public interface IRegistrationService
{
    Task<bool> RegisterUser(UserRegistration user);
}