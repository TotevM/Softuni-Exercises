int naylon = int.Parse(Console.ReadLine()) + 2;
int paint1 = int.Parse(Console.ReadLine());
double paint = paint1 * 1.1;
int razreditel = int.Parse(Console.ReadLine());
int hours = int.Parse(Console.ReadLine());
double bags = 0.40;

double naylonprice = 1.5;
double paintprice = 14.5;
double razreditelprice = 5.0;

double fullprice = naylon * naylonprice + paint * paintprice + razreditel * razreditelprice + bags;
double maistoriprice = hours * (fullprice * 0.3);
double suma = maistoriprice + fullprice;

Console.Write(suma);