namespace CourseManagementApi.Services;

public class UserService : IUserService
{
    private readonly CourseMgmtContext _context;

    public UserService(CourseMgmtContext context)
    {
        _context = context;
    }

    public List<User> Get() => _context.AppUsers.ToList();

    public User? GetById(int id) => _context.AppUsers.SingleOrDefault(s => s.Id == id);
   
    public HttpStatusCode Delete(int id)
    {
        var record = _context.AppUsers.SingleOrDefault(s => s.Id == id);

        if(record is null) return HttpStatusCode.NotFound;
        
        _context.AppUsers.Remove(record);
        _context.SaveChanges();

        return HttpStatusCode.OK;
    }

    public HttpStatusCode Update(User item)
    {
        var record = _context.AppUsers.SingleOrDefault(s => s.Id == item.Id);

        if(record is null) return HttpStatusCode.NotFound;

        record.UpdatedDate = DateTime.UtcNow;
        record.FirstName = item.FirstName;
        record.LastName = item.LastName;
        record.Email = item.Email;
        record.Role = item.Role;

        _context.AppUsers.Update(record);
        _context.SaveChanges();

        return HttpStatusCode.OK;
    }

    public HttpStatusCode Create(User item)
    {
        _context.AppUsers.Add(item);
        _context.SaveChanges();

        return HttpStatusCode.Created;
    }
}