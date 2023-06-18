namespace CourseManagementApi.Interfaces;

public interface IBaseInterface<T>
{
    public IEnumerable<T> Get();
    public T? GetById(int id);
    public void Delete(int id);
}