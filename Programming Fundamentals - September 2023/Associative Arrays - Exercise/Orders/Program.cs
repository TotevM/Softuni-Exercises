namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, Product> productsMap = new Dictionary<string, Product>();

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] productInfo = input.Split();
                string name = productInfo[0];
                decimal price = decimal.Parse(productInfo[1]);
                decimal quantity = decimal.Parse(productInfo[2]);

                Product product = new Product(name, price, quantity);

                if (!productsMap.ContainsKey(name))
                {
                    productsMap.Add(product.Name, product);
                }
                else
                {
                    productsMap[name].Update(product.Price, product.Quantity);
                }
            }

            foreach (KeyValuePair<string, Product> productPair in productsMap)
            {
                Console.WriteLine(productPair.Value);
            }
        }
    }
    class Product
    {
        public Product(string name, decimal price, decimal quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public decimal TotalPrice => Price * Quantity;

        public void Update(decimal price, decimal quantity)
        {
            Price = price;
            Quantity += quantity;
        }

        public override string ToString()
        {
            return $"{Name} -> {TotalPrice:f2}";
        }
    }
}