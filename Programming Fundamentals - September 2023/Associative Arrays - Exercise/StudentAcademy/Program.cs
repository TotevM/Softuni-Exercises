namespace Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var studentAndGrade = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentAndGrade.ContainsKey(student))
                {
                    studentAndGrade.Add(student, new List<double>());
                    studentAndGrade[student].Add(grade);
                }
                else
                {
                    studentAndGrade[student].Add(grade);
                }
            }

            foreach (var pair in studentAndGrade)
            {
                if (pair.Value.Average() >= 4.5)
                {
                Console.WriteLine($"{pair.Key} -> {pair.Value.Average():f2}");
                }
            }
        }
    }
}