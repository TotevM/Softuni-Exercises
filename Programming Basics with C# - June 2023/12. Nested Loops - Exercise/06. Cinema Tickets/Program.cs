int judges = int.Parse(Console.ReadLine());
string input = Console.ReadLine();
int counter = 0;
double sum = 0;
string prezeteishenname;

while (input != "Finish") 
{
    double prezentationEV = 0;
    prezeteishenname = input;
    for (int i = 1; i <= judges; i++)
    {
        prezentationEV += double.Parse(Console.ReadLine());
    }
    prezentationEV = prezentationEV / judges;
    sum += prezentationEV;

    Console.WriteLine($"{prezeteishenname} - {prezentationEV:F2}.");
    counter++;
    input = Console.ReadLine();

}

Console.WriteLine($"Student's final assessment is {sum / counter:F2}.");