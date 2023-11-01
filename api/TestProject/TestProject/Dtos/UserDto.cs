namespace TestProject.Dtos;

public record UserDto(string Login, string Password, string Gender, string Name, string LastName,
    int DayOfBirth, int MonthOfBirth, int YearOfBirth, bool IsAnonymousProfile, bool IsJustChatting);
