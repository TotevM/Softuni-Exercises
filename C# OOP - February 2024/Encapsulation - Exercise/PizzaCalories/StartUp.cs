namespace PizzaCalories;

internal class StartUp
{
    static void Main(string[] args)
    {
        try
        {
            string[] pizzaTokens = Console.ReadLine().Split(' ');
            string pizzaName = pizzaTokens[1];
            Pizza pizza = new(pizzaName);

            string[] doughTokens = ReadStringArr();
            string flourType = doughTokens[1];
            string bakingTechnique = doughTokens[2];
            double doughWeight = double.Parse(doughTokens[3]);
            Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
            pizza.Dough = dough;

            string input;
            while ((input = Console.ReadLine()) is not "END")
            {
                string[] toppingTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string toppingType = toppingTokens[1];
                double toppingWeight = double.Parse(toppingTokens[2]);

                Topping topping = new Topping(toppingType, toppingWeight);
                pizza.AddToping(topping);
            }
            Console.WriteLine(pizza);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static string[] ReadStringArr()
    {
        return Console.ReadLine()
           .Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }
}
