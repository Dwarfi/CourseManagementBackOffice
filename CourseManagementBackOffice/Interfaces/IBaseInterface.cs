namespace CourseManagementApi.Interfaces;

public interface IBaseInterface<T>
{
    public List<T> Get();
    public T? GetById(int id);
    public HttpStatusCode Delete(int id);
    public HttpStatusCode Update(T item);
    public HttpStatusCode Create(T item);
}