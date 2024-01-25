string name = Console.ReadLine();
int br = 0;
string book = Console.ReadLine();

while (book != "No More Books")
{
    if (book == name)
    {
        Console.WriteLine($"You checked {br} books and found it.");
        break;
    }
    br++;
    book = Console.ReadLine();
}
if (book != name)
{
    Console.WriteLine("The book you search is not here!");
    Console.WriteLine($"You checked {br} books.");
}