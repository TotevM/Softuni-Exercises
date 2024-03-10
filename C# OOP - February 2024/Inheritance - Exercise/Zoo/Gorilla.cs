namespace Zoo;

class Gorilla : Mammal
{
    public Gorilla(string name) : base(name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
