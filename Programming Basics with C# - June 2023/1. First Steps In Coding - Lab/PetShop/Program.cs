int dogfood = int.Parse(Console.ReadLine());
int catfood = int.Parse(Console.ReadLine());

double catfoodprice = catfood * 4;
double dogfoodprice = dogfood * 2.5;
double price =dogfoodprice + catfoodprice;

Console.WriteLine(price+" lv.");