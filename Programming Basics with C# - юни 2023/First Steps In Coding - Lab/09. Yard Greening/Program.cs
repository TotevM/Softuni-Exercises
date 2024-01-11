int area = int.Parse(Console.ReadLine());

double areaNoDisc = area * 7.61;
double discount = areaNoDisc * 0.18;
double finalprice = areaNoDisc - discount;

Console.WriteLine($"The final price is: {finalprice} lv.");
Console.WriteLine($"The discount is: {discount} lv.");