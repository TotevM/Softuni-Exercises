namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regulars = new HashSet<string>();
            HashSet<string> VIPs = new HashSet<string>();

            string guest;
            while ((guest = Console.ReadLine()) != "PARTY")
            {
                char resNumStart = guest[0];
                if (Char.IsDigit(resNumStart))
                {
                    VIPs.Add(guest);
                }
                else
                {
                    regulars.Add(guest);
                }
            }

            while ((guest = Console.ReadLine()) != "END")
            {
                if (VIPs.Contains(guest))
                {
                    VIPs.Remove(guest);
                }
                else if (regulars.Contains(guest))
                {
                    regulars.Remove(guest);
                }
            }
            int abscentGuests = VIPs.Count + regulars.Count;

            Console.WriteLine(abscentGuests);

            if (VIPs.Count > 0)
            {
                Console.WriteLine(string.Join('\n', VIPs));
            }

            Console.WriteLine(string.Join('\n', regulars));
        }
    }
}