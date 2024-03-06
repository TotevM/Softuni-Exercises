namespace Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input=Console.ReadLine().Split(new char[] { '\\','.' });
            string name = input[input.Length - 2];
            string extention = input[input.Length - 1];

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extention}");
        }
    }
}