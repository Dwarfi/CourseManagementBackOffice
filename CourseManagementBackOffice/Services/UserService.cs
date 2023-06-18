namespace CourseManagementApi.Services;

public class UserService : IUserService
{
    private readonly CourseMgmtContext _context;

    public UserService(CourseMgmtContext context)
    {
        _context = context;
    }

    public IEnumerable<User> Get() => _context.AppUsers.AsEnumerable();

    public User? GetById(int id) => _context.AppUsers.SingleOrDefault(s => s.Id == id);
   
    public void Delete(int id)
    {
        var record = _context.AppUsers.SingleOrDefault(s => s.Id == id);

        if(record is null) return;
        
        _context.AppUsers.Remove(record);
        _context.SaveChanges();
    }

    public void Update(User item)
    {
        var record = _context.AppUsers.SingleOrDefault(s => s.Id == item.Id);

        if(record is null) return;

        record.UpdatedDate = DateTime.Now;
        record.FirstName = item.FirstName;
        record.LastName = item.LastName;
        record.Email = item.Email;
        record.Role = item.Role;

        _context.AppUsers.Update(record);
        _context.SaveChanges();
    }
}