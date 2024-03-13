namespace CollectionHierarchy
{
    public interface ICollection
    {
        List<string> Collection { get; set; }
        int Add(string element);
    }
}
