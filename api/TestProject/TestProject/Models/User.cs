using TestProject.Models.Core;

namespace TestProject.Models;

public class User : Entity<Guid>
{
    public User(Guid id, string login, string password, string gender, string name, string lastName, int dayOfBirth, int monthOfBirth, int yearOfBirth, bool isAnonymousProfile, bool isJustChatting) : base(id)
    {
        Login = login;
        Password = password;
        Gender = gender;
        Name = name;
        LastName = lastName;
        DayOfBirth = dayOfBirth;
        MonthOfBirth = monthOfBirth;
        YearOfBirth = yearOfBirth;
        IsAnonymousProfile = isAnonymousProfile;
        IsJustChatting = isJustChatting;
    }

    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public string Gender { get; set; }
    
    public string Name { get; set; }
    
    public string LastName { get; set; }
    
    public int DayOfBirth { get; set; }
    
    public int MonthOfBirth { get; set; }
    
    public int YearOfBirth { get; set; }
    
    public bool IsAnonymousProfile { get; set; }
    
    public bool IsJustChatting { get; set; }
    
    




}
// " Server=localhost;Database=postgres;Port=5432;User Id=postgres;Password=qwerty229322;"