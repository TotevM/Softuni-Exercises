int dni = int.Parse(Console.ReadLine());
string vid = Console.ReadLine();
string ocenka = Console.ReadLine();
double cena = 0;
if (vid == "room for one person")
{
    cena = 18 * (dni - 1);
    if (ocenka == "positive") { cena *= 1.25; }
    else if (ocenka == "negative") { cena *= 0.9; }
}
else if (vid == "apartment")
{
    cena = 25 * (dni - 1);
    if (dni < 10) { cena *= 0.7; }
    else if (dni < 15 && dni > 10) { cena *= 0.65; }
    else if (dni > 15) { cena *= 0.50; }
    if (ocenka == "positive") { cena *= 1.25; }
    else if (ocenka == "negative") { cena *= 0.9; }
}
else if (vid == "president apartment")
{
    cena = 35 * (dni - 1);
    if (dni < 10) { cena *= 0.9; }
    else if (dni < 15 && dni > 10) { cena *= 0.85; }
    else if (dni > 15) { cena *= 0.80; }
    if (ocenka == "positive") { cena *= 1.25; }
    else if (ocenka == "negative") { cena *= 0.9; }
}
Console.WriteLine($"{cena:F2}");