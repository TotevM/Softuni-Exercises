namespace Person;

public class Person
{
    private string name;
    private uint age;


    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public uint Age
    {
        get { return age; }
        set { age = value; }
    }

    public Person(string name, uint age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }
}
