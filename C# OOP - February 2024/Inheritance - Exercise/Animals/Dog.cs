namespace Animals;

internal class Dog : Animal
{
    public Dog(string name, int age, string gender) : base(name, age, gender)
    {

    }

    public override string ProduceSound() => "Woof!";

    public override string ToString() => base.ToString();
}
