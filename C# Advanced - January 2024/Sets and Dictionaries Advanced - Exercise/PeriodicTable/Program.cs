namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            SortedSet<string> elements= new SortedSet<string>();
            
            for (int i = 0; i < count; i++)
            {
                string[] input=Console.ReadLine().Split().ToArray();
                for (int k = 0; k < input.Length; k++)
                {
                    elements.Add(input[k]);
                }
            }
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
