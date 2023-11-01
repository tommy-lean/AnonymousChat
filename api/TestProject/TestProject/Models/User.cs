using TestProject.Models.Core;

namespace TestProject.Models;

public class User : Entity<Guid>
{
    public User(Guid id, string login, string password, string gender, string name, string lastName, DateTimeOffset dateOfBirth, bool isAnonymousProfile, bool isJustChatting) : base(id)
    {
        Login = login;
        Password = password;
        Gender = gender;
        Name = name;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        IsAnonymousProfile = isAnonymousProfile;
        IsJustChatting = isJustChatting;
    }

    public string Login { get; set; }
    public string Password { get; set; }
    public string Gender { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public bool IsAnonymousProfile { get; set; }
    public bool IsJustChatting { get; set; }
    
    




}
// " Server=localhost;Database=postgres;Port=5432;User Id=postgres;Password=qwerty229322;"