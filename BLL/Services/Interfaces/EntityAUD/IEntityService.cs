using ML.Mapper;

namespace BLL.Services.Interfaces;

public interface IEntityService<T>
{
    Task<bool> Add(T model);
    Task<bool> Update(T model);
    Task<bool> Delete(int Id);
    Task<T> GetById(int Id);
}