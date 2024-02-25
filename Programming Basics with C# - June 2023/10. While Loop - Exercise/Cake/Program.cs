


int width = int.Parse(Console.ReadLine());
int lenght = int.Parse(Console.ReadLine());
int piecesCount=width*lenght;

while (true)
{
string command=Console.ReadLine();
    if (command == "STOP")
    {
        Console.WriteLine($"{piecesCount} pieces are left.");
        break;
    }
    int piecesToTake=int.Parse(command);
    if (piecesToTake > piecesCount)
    {
        Console.WriteLine($"No more cake left! You need {piecesToTake-piecesCount} pieces more.");
        break;
    }
    piecesCount -= piecesToTake;
}