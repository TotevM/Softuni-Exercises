namespace Zoo;

class Snake : Reptile
{
    public Snake(string name) : base(name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
