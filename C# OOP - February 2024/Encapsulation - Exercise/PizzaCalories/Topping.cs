namespace PizzaCalories;

internal class Topping
{
	private const double BaseCalories = 2.0;
	private readonly string toppingType;
	private readonly double weight;

    public Topping(string toppingType, double weight)
    {
        ToppingType = toppingType;
        Weight = weight;
    }

    public string ToppingType
    {
		get => toppingType; 
		init
		{
			if(value.ToLower() is not ("meat" or "veggies" or "cheese" or "sauce"))
			{
				throw new ArgumentException($"Cannot place {value} on top of your pizza.");
			}
			toppingType = value;
		}
	}
	public double Weight
	{
		get => weight;
        init
        {
            if (value is <1 or >50)
            {
                throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
            }
			weight = value;
        }
    }

    public double GetToppingCals()
    {
        double calsPerGram = BaseCalories * weight;
        switch (toppingType.ToLower())
        {
            case "meat":
                calsPerGram *= 1.2;
                break;
            case "veggies":
                calsPerGram *= 0.8;
                break;
            case "cheese":
                calsPerGram *= 1.1;
                break;
            case "sauce":
                calsPerGram *= 0.9;
                break;
        }
        return calsPerGram;
    }

}
