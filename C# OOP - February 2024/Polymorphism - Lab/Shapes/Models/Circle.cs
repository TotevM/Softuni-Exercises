namespace Shapes.Models
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get { return radius; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Enter a possitive number!");
                }
                radius = value;
            }
        }

        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * radius * Math.PI;
        }

        public override string Draw()
        {
            return base.Draw();
        }
    }
}
