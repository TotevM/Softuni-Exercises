namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> list = new List<double>(Console.ReadLine().Split().Select(double.Parse).ToArray());
            Dictionary<double,int> dic= new Dictionary<double,int>();

            foreach (var item in list) 
            {
                if (!dic.ContainsKey(item))
                {
                    dic[item]=0;
                }
                dic[item]++;
            }

            foreach (var key in dic)
            {
                Console.WriteLine($"{string.Join(", ", key.Key)} - {key.Value} times");
            }
        }
    }
}
