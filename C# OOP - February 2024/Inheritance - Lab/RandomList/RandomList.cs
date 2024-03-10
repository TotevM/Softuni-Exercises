namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random = new Random();
        public string RandomString()
        {
            string remove = random.Next(0, this.Count).ToString();
            this.Remove(remove);
            return remove;
        }
    }
}
