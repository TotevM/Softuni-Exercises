namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> evens = new Queue<int>();

            while (numbers.Count != 0) 
            {
            int peek=numbers.Peek();
                if (peek%2==0)
                {
                    evens.Enqueue(numbers.Dequeue());
                }
                else {numbers.Dequeue(); }
            }

            Console.Write(evens.Dequeue());
            while (evens.Count!=0)
            {
                Console.Write($", {evens.Dequeue()}");
            }
        }
    }
}