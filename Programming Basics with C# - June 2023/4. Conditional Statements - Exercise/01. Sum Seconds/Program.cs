int Firsttime = int.Parse(Console.ReadLine());
int Secondtime = int.Parse(Console.ReadLine());
int Thirdtime = int.Parse(Console.ReadLine());

int Totaltime = Firsttime + Secondtime + Thirdtime;
int minutes = Totaltime / 60;
int seconds = Totaltime % 60;

if (seconds < 10)
{
    Console.WriteLine($"{minutes}:0{seconds}");
}
else
{
    Console.WriteLine($"{minutes}:{seconds}");
}