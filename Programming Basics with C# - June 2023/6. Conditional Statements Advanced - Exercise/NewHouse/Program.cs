string cveke = Console.ReadLine();
int br = int.Parse(Console.ReadLine());
int budget = int.Parse(Console.ReadLine());
double cena = 0;
if (cveke == "Roses")
{
    cena = br * 5;
    if (br > 80) { cena *= 0.9; }
}
else if (cveke == "Dahlias")
{
    cena = br * 3.80;
    if (br > 90) { cena *= 0.85; }
}
else if (cveke == "Tulips")
{
    cena = br * 2.80;
    if (br > 80) { cena *= 0.85; }
}
else if (cveke == "Narcissus")
{
    cena = br * 3;
    if (br < 120)
    {
        cena *= 1.15;
    }
}
else if (cveke == "Gladiolus")
{
    cena = br * 2.50;
    if (br < 80) { cena *= 1.2; }
}
if (cena <= budget) { Console.WriteLine($"Hey, you have a great garden with {br} {cveke} and {(budget - cena):F2} leva left."); }
else if (cena > budget) { Console.WriteLine($"Not enough money, you need {(cena - budget):F2} leva more."); }