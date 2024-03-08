namespace GenericScale
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<double> check = new EqualityScale<double>(2.32, 23.4);
            Console.WriteLine(check.AreEqual()); ;
        }
    }
}
