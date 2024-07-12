namespace ConsoleApp.MiniLibraryManagementSystem.Features.User;

public class UserManager
{
    private List<UserDto> users = new List<UserDto>();

    public void RegisterUser(string name, string email, string password)
    {
        users.Add(new UserDto { Id = users.Count + 1, Name = name, Email = email, Password = password });
        Console.WriteLine($"User '{name}' registered.");
    }

    public int? AuthenticateUser(string email, string password)
    {
        var user = users.Find(u => u.Email == email && u.Password == password);
        if (user != null)
        {
            Console.WriteLine($"User '{user.Name}' authenticated.");
            return user.Id;
        }
        else
        {
            return null;
        }
    }

    public List<UserDto> GetUsers()
    {
        return users;
    }
}
