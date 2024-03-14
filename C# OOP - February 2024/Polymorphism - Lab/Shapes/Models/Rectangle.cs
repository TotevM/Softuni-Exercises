namespace Shapes.Models
{

    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height
        {
            get { return height; }
            private set 
            {
                if (value<=0)
                {
                    throw new ArgumentException("Enter a possitive number!");
                }
                height = value; 
            }
        }

        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Enter a possitive number!");
                }
                width = value;
            }
        }


        public override double CalculateArea()
        {
            return width*height;
        }

        public override double CalculatePerimeter()
        {
            return 2*(width + height);
        }

        public override string Draw()
        {
            return base.Draw();
        }
    }
}
