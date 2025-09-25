using Sprint-2-activity-1.Controllers;

UserController User = new UserController();
foreach (var user in User.Index())
{
    Console.WriteLine($"{user.Id} - {user.Name} - {user.Email}");
}