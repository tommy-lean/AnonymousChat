using TestProject.Models.Core;

namespace TestProject.Models;

public class User : Entity<Guid>
{
    public User(Guid id, string firstName, string password): base(id)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));

        Password = password ?? throw new ArgumentNullException(nameof(password));
    }


    public string FirstName { get; set; }
    
    public string Password { get; set; }
}
// " Server=localhost;Database=postgres;Port=5432;User Id=postgres;Password=qwerty229322;"