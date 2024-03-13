namespace Telephony;

public class StationaryPhone : ICall
{
    public void Call(string phoneNumber)
    {
        foreach (char ch in phoneNumber)
        {
            if (!Char.IsDigit(ch))
            {
                Console.WriteLine("Invalid number!");
                return;
            }
        }

        Console.WriteLine($"Dialing... {phoneNumber}");
    }
}
