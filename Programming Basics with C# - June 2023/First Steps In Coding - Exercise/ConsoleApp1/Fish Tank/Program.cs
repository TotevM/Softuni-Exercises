int shirina = int.Parse(Console.ReadLine());
int duljina = int.Parse(Console.ReadLine());
int visochina = int.Parse(Console.ReadLine());
double extra=double.Parse(Console.ReadLine());

double bigv = shirina * visochina * duljina;
double V = bigv - bigv * extra / 100;
Console.WriteLine(V/1000);