int num1 = int.Parse(Console.ReadLine());
int num2 = int.Parse(Console.ReadLine());

for (int i = num1; i <= num2; i++)
{
    string current = i.ToString();
    int evenSum = 0, oddSum = 0;
    for (int j = 0; j < current.Length; j++)
    {
        int currentNum = int.Parse(current[j].ToString());
        if (j % 2 == 0) { evenSum += currentNum; }
        else { oddSum += currentNum; }
    }
    if (evenSum == oddSum) { Console.Write(i + " "); }
}