namespace Telephony;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] phoneNumbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] websites = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        foreach (string phoneNumber in phoneNumbers)                            
        {
            if(phoneNumber.Length == 10)
            {
                Smartphone calling = new();
                calling.Call(phoneNumber);
            }
            else if(phoneNumber.Length == 7)
            {
                StationaryPhone calling = new();
                calling.Call(phoneNumber);
            }
        }

        foreach (string website in websites)
        {
            Smartphone browser = new();
            browser.Browse(website);
        }
    }
}
