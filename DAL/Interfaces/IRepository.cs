namespace DAL.Interfaces;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T GetById(int Id);
    T Add(T Entity);
    T UpdateById(int Id, T Entity);
    void DeleteById(int Id);
}