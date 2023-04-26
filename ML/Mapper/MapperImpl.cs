using AutoMapper;
using ML.Models;

namespace ML.Mapper;

public class MapperImpl : Profile
{
    public MapperImpl()
    {
        CreateMap<UserRegistration, User>();
        CreateMap<UserCard, User>();
    }
}