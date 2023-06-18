namespace CourseManagementApi.Interfaces;

public interface IBaseInterface<out T>
{
    public IEnumerable<T> Get();
    public T? GetById(int id);
    public void Delete(int id);
}