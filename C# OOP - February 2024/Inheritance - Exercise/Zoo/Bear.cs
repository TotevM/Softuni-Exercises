namespace Zoo;

class Bear : Mammal
{
    public Bear(string name) : base(name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
