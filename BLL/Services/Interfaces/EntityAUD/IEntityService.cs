using ML.Mapper;

namespace BLL.Services.Interfaces;

public interface IEntityService
{
    Task<bool> Add(TypeModel model);
    Task<bool> Update(TypeModel model);
    Task<bool> Delete(int Id);
}