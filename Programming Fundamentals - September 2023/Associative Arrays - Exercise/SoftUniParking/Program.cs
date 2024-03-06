namespace SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandCount = int.Parse(Console.ReadLine());
            Dictionary<string, User> users = new Dictionary<string, User>();

            for (int i = 0; i < commandCount; i++)
            {
                string[] commandInfo = Console.ReadLine().Split();
                string command = commandInfo[0];
                string username = commandInfo[1];

                switch (command)
                {
                    case "register":
                        string licencePlate = commandInfo[2];
                        User newUser = new User(username, licencePlate);

                        if (users.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {newUser.LicensePlate}");
                        }
                        else
                        {
                            users.Add(username, newUser);
                            Console.WriteLine($"{newUser.UserName} registered {newUser.LicensePlate} successfully");
                        }

                        break;

                    case "unregister":

                        if (users.ContainsKey(username))
                        {
                            users.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }

                        break;
                }
            }

            foreach (KeyValuePair<string, User> userPair in users)
            {
                Console.WriteLine(userPair.Value);
            }
        }
    }
    public class User
    {
        public User(string userName, string licensePlate)
        {
            UserName = userName;
            LicensePlate = licensePlate;
        }

        public string UserName { get; set; }

        public string LicensePlate { get; set; }

        public override string ToString()
        {
            return $"{UserName} => {LicensePlate}";
        }
    }
}