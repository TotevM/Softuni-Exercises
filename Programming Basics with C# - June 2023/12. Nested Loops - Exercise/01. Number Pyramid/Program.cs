int n = int.Parse(Console.ReadLine());
int br = 1;
bool check = false;

for (int rows = 1; rows <= n; rows++)
{
    for (int cols = 1; cols <= rows; cols++)
    {
        if (br > n) { check = true; break; }
        Console.Write(br + " ");
        br++;
    }
    if (check) { break; }
    Console.WriteLine();
}