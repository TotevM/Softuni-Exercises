namespace Zoo;

class Mammal : Animal
{
    public Mammal(string name) : base(name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
