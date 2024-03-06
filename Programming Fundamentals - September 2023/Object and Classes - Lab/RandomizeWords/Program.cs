using System;
using System.Linq;
namespace ObjectsAndClasses
{
    class MainClass
    {
        public static void Main()
        {
            var rnd = new Random();
            var words = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < words.Length; i++)
            {
                var randomIndex = rnd.Next(0, words.Length);


                var a = words[randomIndex];
                var b = words[i];

                words[randomIndex] = b;
                words[i] = a;
            }

            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}