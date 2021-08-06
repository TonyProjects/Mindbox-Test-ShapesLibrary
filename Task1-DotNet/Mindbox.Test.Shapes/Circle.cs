using System;

namespace Mindbox.Test.Shapes
{
    public sealed class Circle : Shape
    {
        private double r;

        public Circle(double radius)
        {
            if (radius <= 0) throw new NegativeOrZeroRadiusException();

            r = radius;
        }

        public override double Area { get => Math.PI * r * r; }
    }

    
    // EXCEPTIONS
    public sealed class NegativeOrZeroRadiusException : ArgumentException
    {
        public NegativeOrZeroRadiusException() : base("Circle radius must be greater than zero") { }
    }
}
