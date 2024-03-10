namespace Zoo;

class Reptile : Animal
{
    public Reptile(string name) : base(name)
    {
        this.Name = name;
    }

    public string Name { get; set; }
}
