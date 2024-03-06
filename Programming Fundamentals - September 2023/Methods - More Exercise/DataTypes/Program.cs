using System.Drawing;

namespace Data_Types
{
//If the data type is int, multiply the number by 2.
//If the data type is real, multiply the number by 1.5 and format it to the second decimal point.
// If the data type is a string, surround the input with '$'.

    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string command = Console.ReadLine();

            Convert(type, command);
        }

        private static void Convert(string type, string command)
        {
            if (type == "int")
            {
                int num = int.Parse(command) * 2;
                Console.WriteLine(num);
            }
            if (type == "real")
            {
                double num = double.Parse(command) * 1.5;
                Console.WriteLine($"{num:f2}");
            }
            if (type == "string")
            {
                Console.WriteLine($"${command}$");
            }
        }
    }
}