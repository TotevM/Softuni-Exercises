namespace _07._Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = default;
            List<Person> people = new List<Person>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] personToken = command.Split();
                string name = personToken[0];
                int id = int.Parse(personToken[1]);
                int age = int.Parse(personToken[2]);

                Person renamed = people.Find(x => x.ID == id);

                if (renamed != null)
                {
                    renamed.Name = name;
                    renamed.Age = age;
                }
                else
                {
                    Person person = new Person(name, id, age);
                    people.Add(person);
                }
            }

            people = people.OrderBy(x => x.Age).ToList();

            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
    public class Person
    {
        public Person(string name, int id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }
        public string Name { get; set; }
        public int ID { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}