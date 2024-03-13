namespace CollectionHierarchy
{
    public class AddCollection : ICollection
    {
        public List<string> Collection { get; set; }
        public AddCollection()
        {
            Collection = new List<string>();
        }

        public int Add(string element)
        {
            Collection.Add(element);
            return Collection.Count - 1;
        }
    }
}
