double budget = double.Parse(Console.ReadLine());
string sezon = Console.ReadLine();
string mqsto = string.Empty;
double suma = 0;
if (budget <= 100 && sezon == "summer") { suma = budget * 0.3; Console.WriteLine("Somewhere in Bulgaria"); Console.WriteLine($"Camp - {suma:F2}"); }
else if (budget <= 100 && sezon == "winter") { suma = budget * 0.7; Console.WriteLine("Somewhere in Bulgaria"); Console.WriteLine($"Hotel - {suma:F2}"); }
else if (budget > 100 && budget <= 1000 && sezon == "summer") { suma = budget * 0.4; Console.WriteLine("Somewhere in Balkans"); Console.WriteLine($"Camp - {suma:F2}"); }
else if (budget > 100 && budget <= 1000 && sezon == "winter") { suma = budget * 0.8; Console.WriteLine("Somewhere in Balkans"); Console.WriteLine($"Hotel - {suma:F2}"); }
else if (budget > 1000) { suma = budget * 0.9; Console.WriteLine("Somewhere in Europe"); Console.WriteLine($"Hotel - {suma:F2}"); }