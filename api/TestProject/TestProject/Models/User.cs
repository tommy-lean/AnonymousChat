using TestProject.Models.Core;

namespace TestProject.Models;

public class User : Entity<Guid>
{
    public User(Guid id, string login, string password, string name) : base(id)
    {
        Login = login;
        Password = password;
        Name = name;
        
    }

    public string Login { get; private set; }
    public string Password { get; set; }
    public string Gender { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public bool IsAnonymousProfile { get; set; }
    public bool IsJustChatting { get; set; }
}
// " Server=localhost;Database=postgres;Port=5432;User Id=postgres;Password=qwerty229322;"