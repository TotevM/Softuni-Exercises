namespace Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            
            string command;
            while ((command=Console.ReadLine().ToLower())!="end")
            {
                string[] arguments = command.Split();

                switch (arguments[0].ToLower()) 
                {
                    case "add":
                        numbers.Push(int.Parse(arguments[1]));
                        numbers.Push(int.Parse(arguments[2]));
                        break;
                    
                    case "remove":
                        if (numbers.Count> int.Parse(arguments[1]))
                        {
                        for (int i = 0; i < int.Parse(arguments[1]); i++)
                        {
                            numbers.Pop();
                        }
                        }
                        else { continue; }

                        break;
                }
            }
                Console.WriteLine($"Sum: {numbers.Sum()}");

        }
    }
}
/*
3 5 8 4 1 9
add 19 32
remove 10
add 89 22
remove 4
remove 3
end

 */