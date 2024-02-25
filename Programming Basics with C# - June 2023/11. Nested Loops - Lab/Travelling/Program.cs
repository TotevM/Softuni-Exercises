while (true)
{
    string mqsto = Console.ReadLine();
    if (mqsto == "End") { break; }
    double min = double.Parse(Console.ReadLine());

    double saved = 0;

    while (saved < min)
    {
        double currentSaved = double.Parse(Console.ReadLine());

        saved += currentSaved;
    }

    Console.WriteLine($"Going to {mqsto}!");
}