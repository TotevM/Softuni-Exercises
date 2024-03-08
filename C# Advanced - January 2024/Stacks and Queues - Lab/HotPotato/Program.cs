namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> players = new Queue<string>(Console.ReadLine().Split());
            int n = int.Parse(Console.ReadLine());
            int tosses = 1;

            while (players.Count != 1)
            {
                string person = players.Dequeue();

                if (tosses < n)
                {
                    players.Enqueue(person);
                    tosses++;
                }
                else
                {
                    tosses = 1;
                    Console.WriteLine($"Removed {person}");
                }
            }
            Console.WriteLine("Last is "+players.Dequeue());
        }
    }
}