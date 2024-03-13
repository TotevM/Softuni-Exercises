namespace BirthdayCelebrations.Models.Interfaces;

public interface IBirthable
{
    string GetBirthday();
    public void GetYearFromBirthday(string birthday, string year);
}
