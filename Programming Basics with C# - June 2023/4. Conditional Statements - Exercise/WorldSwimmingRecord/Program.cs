namespace World_Swimming_Record
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double time = double.Parse(Console.ReadLine());
            double resistance = 0;

            if (distance >= 15)
            {
                resistance = (Math.Floor(distance/15)* 12.5);
            }
            double Ivanrecord = distance * time + resistance;
            if (Ivanrecord < record)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {Ivanrecord:F2} seconds.");
            }
            else { Console.WriteLine($"No, he failed! He was {(Ivanrecord-record):F2} seconds slower."); }
        }
    }
}