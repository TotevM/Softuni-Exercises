int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
double suma = 0.0;
string operation = Console.ReadLine();

if (operation == "+")
{
    suma = a + b;
    if (suma % 2 == 0) { Console.WriteLine($"{a} + {b} = {suma} - even"); }
    else { Console.WriteLine($"{a} + {b} = {suma} - odd"); }
}
if (operation == "-")
{
    suma = a - b;
    if (suma % 2 == 0) { Console.WriteLine($"{a} - {b} = {suma} - even"); }
    else { Console.WriteLine($"{a} - {b} = {suma} - odd"); }
}
if (operation == "*")
{
    suma = a * b;
    if (suma % 2 == 0) { Console.WriteLine($"{a} * {b} = {suma} - even"); }
    else { Console.WriteLine($"{a} * {b} = {suma} - odd"); }
}
if (operation == "/")
{
    if (b == 0) { Console.WriteLine($"Cannot divide {a} by zero"); }
    else if (b != 0)
    {
        suma = (double)a / (double)b;
        Console.WriteLine($"{a} / {b} = {suma:F2}");
    }
}
if (operation == "%")
{
    if (b == 0) { Console.WriteLine($"Cannot divide {a} by zero"); }
    else if (b != 0)
    {
        suma = (double)a % (double)b;
        Console.WriteLine($"{a} % {b} = {suma}");
    }
}