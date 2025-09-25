using Sprint-2-activity-1.Data;
using Sprint-2-activity-1.DTOs;

namespace Sprint2.Controllers;

public class UserController
{
    
    // 🔹 READ (todos)
    public List<User> Index()
    {
        using (var db = new MysqlDbContext())
        {
            return db.users.ToList();
        }
    }
}