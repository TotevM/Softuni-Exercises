string mesec = Console.ReadLine();
int br = int.Parse(Console.ReadLine());
double cenaStudio = 0;
double cenaApartament = 0;
if (mesec == "May" || mesec == "October")
{
    cenaStudio = 50 * br;
    cenaApartament = 65 * br;
    if (br > 7 && br < 14) { cenaStudio *= 0.95; }
    else if (br > 14) { cenaStudio *= 0.70; cenaApartament *= 0.90; }
    Console.WriteLine($"Apartment: {cenaApartament:F2} lv.");
    Console.WriteLine($"Studio: {cenaStudio:F2} lv.");
}
else if (mesec == "June" || mesec == "September")
{
    cenaStudio = 75.20 * br;
    cenaApartament = 68.70 * br;
    if (br > 14) { cenaStudio *= 0.80; cenaApartament *= 0.90; }
    Console.WriteLine($"Apartment: {cenaApartament:F2} lv.");
    Console.WriteLine($"Studio: {cenaStudio:F2} lv.");
}
else if (mesec == "July" || mesec == "August")
{
    cenaStudio = 76 * br;
    cenaApartament = 77 * br;
    if (br > 14) { cenaApartament *= 0.90; }
    Console.WriteLine($"Apartment: {cenaApartament:F2} lv.");
    Console.WriteLine($"Studio: {cenaStudio:F2} lv.");
}