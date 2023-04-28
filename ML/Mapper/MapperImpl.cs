using AutoMapper;
using ML.Models;

namespace ML.Mapper;

public class MapperImpl : Profile
{
    public MapperImpl()
    {
        CreateMap<UserRegistration, User>();
        CreateMap<UserCard, User>();
        CreateMap<TypeModel, PreporateType>();
        CreateMap<PreporateType, TypeModel>();
        CreateMap<RoleModel, Role>();
        CreateMap<Role, RoleModel>();
        CreateMap<ProviderModel, Provider>();
        CreateMap<Provider, ProviderModel>();
    }
}