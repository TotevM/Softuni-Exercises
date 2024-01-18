int chas = int.Parse(Console.ReadLine());
string den = Console.ReadLine();
if (den == "Monday" || den == "Tuesday" || den == "Wednesday" || den == "Thursday" || den == "Friday" || den == "Saturday")
{
    if (chas >= 10 && chas <= 18)
    {
        Console.WriteLine("open");
    }
    else
    {
        Console.WriteLine("closed");
    }
}
else
{
    Console.WriteLine("closed");
}