namespace Zoo;

class Lizard : Reptile
{
    public Lizard(string name) : base(name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
