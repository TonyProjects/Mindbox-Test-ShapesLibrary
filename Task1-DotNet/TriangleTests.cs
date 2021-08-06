using System;
using System.Collections.Generic;
using Xunit;
using Mindbox.Test.Shapes;


namespace ShapesTests
{
    public class TriangleTests
    {
        [Fact]
        public void Positive_Side_Triangle_Construction()
        {
            // ARRANGE
            var positiveSidesAreaAssertions = new List<(double, double, double, double)>()
            {
                (2,   4,   3,   2.90474),
                (2.1, 4.2, 3.3, 3.41526),
                (5.5, 2,   4,   3.07142)
            };

            // ACT + ASSERT
            positiveSidesAreaAssertions.ForEach((tuple) =>
            {
                double a = tuple.Item1;
                double b = tuple.Item2;
                double c = tuple.Item3;
                double area = tuple.Item4;

                var t = new Triangle(a, b, c);

                Assert.InRange(t.Area, area - 0.0001, area + 0.0001);
            });
        }

        [Fact]
        public void Negative_Side_Triangle_Construction()
        {
            // ARRANGE
            var negativeSidesThrowAssertions = new List<(double, double, double)>()
            {
                (-1,  2,  4),
                ( 1, -2,  4),
                ( 1,  2, -4),
                (-1, -2,  4),
                (-1,  2, -4),
                ( 1, -2, -4),
                (-1, -2, -4)
            };

            // ACT + ASSERT
            negativeSidesThrowAssertions.ForEach((tuple) =>
            {
                double a = tuple.Item1;
                double b = tuple.Item2;
                double c = tuple.Item3;

                Assert.Throws<NegativeSideException>(() =>
                {
                    new Triangle(a, b, c);
                });
            });
        }

        [Fact]
        public void Imposible_Sides_Triangle_Construction()
        {
            // ARRANGE
            var impossibleSidesThrowAssertions = new List<(double, double, double)>()
            {
                (1,   2, 5),
                (100, 4, 4)
            };

            // ACT + ASSERT
            impossibleSidesThrowAssertions.ForEach((tuple) =>
            {
                double a = tuple.Item1;
                double b = tuple.Item2;
                double c = tuple.Item3;

                Assert.Throws<ImpossibleTriangleException>(() =>
                {
                    new Triangle(a, b, c);
                });
            });
        }

        [Fact]
        public void Is_Triangle_Right_Examination()
        {
            // ARRANGE
            var positiveSidesAreaAssertions = new List<(double, double, double, bool)>()
            {
                (2,   4,   3,   false),
                (2.1, 4.2, 3.3, false),
                (1.414213, 1, 1, true),
                (5,   4,   3,    true)
            };

            // ACT + ASSERT
            positiveSidesAreaAssertions.ForEach((tuple) =>
            {
                double a = tuple.Item1;
                double b = tuple.Item2;
                double c = tuple.Item3;
                bool isRight = tuple.Item4;

                var t = new Triangle(a, b, c);

                Assert.Equal(t.IsRight(), isRight);
            });
        }
    }
}
