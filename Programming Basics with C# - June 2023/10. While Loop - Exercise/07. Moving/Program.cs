int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());
int V = a * b * c;

while (true)
{
    string command = Console.ReadLine();
    if (command == "Done")
    {
        Console.WriteLine($"{V} Cubic meters left.");
        break;
    }
    int boxesCount = int.Parse(command);
    if (boxesCount > V)
    {
        Console.WriteLine($"No more free space! You need {boxesCount - V} Cubic meters more.");
        break;
    }
    V -= boxesCount;
}