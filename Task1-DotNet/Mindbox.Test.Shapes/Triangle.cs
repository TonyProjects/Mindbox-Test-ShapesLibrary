using System;

namespace Mindbox.Test.Shapes
{
    public sealed class Triangle : Shape
    {
        private double[] s; // sides 

        private bool HasNegativeSide() => s[0] < 0 || s[1] < 0 || s[2] < 0;
        private bool IsTriangleImpossible() => (s[0] + s[1] - s[2]) < 0;


        public Triangle(double a, double b, double c)
        {
            s = new double[] { a, b, c };

            Array.Sort(s);

            if (HasNegativeSide()) throw new NegativeSideException();

            if (IsTriangleImpossible()) throw new ImpossibleTriangleException(s);
        }

        public bool IsRight()
        {
            double pythagoreanDifference = s[0] * s[0] + s[1] * s[1] - s[2] * s[2];
            return pythagoreanDifference > -0.0001d && pythagoreanDifference < 0.0001d;
        }

        public override double Area
        {
            get
            {
                double p = 0.5 * (s[0] + s[1] + s[2]);
                return Math.Sqrt(p * (p - s[0]) * (p - s[1]) * (p - s[2]));
            }
        }
    }

    // EXCEPTIONS
    public sealed class NegativeSideException : ArgumentException
    {
        public NegativeSideException() : base("Sides of treangle musts be positive") { }
    }

    public sealed class ImpossibleTriangleException : ArgumentException
    {
        public ImpossibleTriangleException(double[] s) : base($"Triangle with given sides ({s[0]}, {s[1]}, {s[2]}) is impossible") { }
    }
}
