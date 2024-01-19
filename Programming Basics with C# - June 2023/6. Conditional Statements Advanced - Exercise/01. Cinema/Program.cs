string prozhekciq = Console.ReadLine();
int rows = int.Parse(Console.ReadLine());
int cols = int.Parse(Console.ReadLine());
double cena = 0;
if (prozhekciq == "Premiere") { cena = 12.00 * rows * cols; }
else if (prozhekciq == "Normal") { cena = 7.50 * rows * cols; }
else if (prozhekciq == "Discount") { cena = 5.00 * rows * cols; }
Console.WriteLine($"{cena:F2} leva");