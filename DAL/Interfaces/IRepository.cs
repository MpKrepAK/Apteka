namespace DAL.Interfaces;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T GetById(int Id);
}