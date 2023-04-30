using AutoMapper;
using ML.Models;

namespace ML.Mapper;

public class MapperImpl : Profile
{
    public MapperImpl()
    {
        CreateMap<UserRegistration, User>();
        CreateMap<TypeModel, PreporateType>();
        CreateMap<PreporateType, TypeModel>();
        CreateMap<RoleModel, Role>();
        CreateMap<Role, RoleModel>();
        CreateMap<ProviderModel, Provider>();
        CreateMap<Provider, ProviderModel>();
        CreateMap<UserModel, User>();
        CreateMap<User, UserModel>();
        CreateMap<PreporateModel, Preporate>();
        CreateMap<Preporate, PreporateModel>();
    }
}