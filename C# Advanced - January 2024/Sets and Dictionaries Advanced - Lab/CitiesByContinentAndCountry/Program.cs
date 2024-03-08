namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> cont = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++) 
            {
                string[] input=Console.ReadLine().Split().ToArray();
                string contintent = input[0];
                string country = input[1];
                string city = input[2];
                
                if (!cont.ContainsKey(contintent))
                {
                    cont.Add(contintent, new Dictionary<string, List<string>>());
                }

                if (!cont[contintent].ContainsKey(country))
                {
                    cont[contintent][country] = new List<string>();
                }

                cont[contintent][country].Add(city);
            }
            foreach (var (contintent, countries) in cont)
            {
                Console.WriteLine(contintent+":");
                foreach (var (country, cities) in countries) 
                {
                Console.WriteLine($"  {country} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
