namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection col1 = new AddCollection();
            AddRemoveCollection col2 = new AddRemoveCollection();
            MyList col3 = new MyList();

            string[] arguments = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (string arg in arguments)
            {
            Console.Write(col1.Add(arg)+" ");
            }
            Console.WriteLine();

            foreach (string arg in arguments)
            {
                Console.Write(col2.Add(arg) + " ");
            }
            Console.WriteLine();

            foreach (string arg in arguments)
            {
                Console.Write(col3.Add(arg) + " ");
            }
            Console.WriteLine();

            int removeElements = int.Parse(Console.ReadLine());

            for (int i = 0; i < removeElements; i++)
            {
                Console.Write(col2.Remove() + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < removeElements; i++)
            {
                Console.Write(col3.Remove() + " ");
            }
        }
    }
}
