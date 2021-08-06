using System;
using System.Collections.Generic;
using Xunit;
using Mindbox.Test.Shapes;

namespace ShapesTests
{
    public class CircleTests
    {
        [Fact]
        public void Positive_Radius_Circle_Construction()
        {
            // ARRANGE
            var positiveRadiusAreaAssertions = new List<(double, double)>()
            {
                (5,78.539816339744830961566084581988),
                (10,314.15926535897932384626433832795),
                (0.1,0.0314159265358979323846264338328)
            };

            double negativeRadius = -1;

            // ACT + ASSERT
            positiveRadiusAreaAssertions.ForEach((pair) =>
            {
                double r = pair.Item1;
                double a = pair.Item2;

                var c = new Circle(r);

                Assert.InRange(c.Area, a - 0.0001, a + 0.0001);
            });

            Assert.Throws<NegativeOrZeroRadiusException>(() =>
            {
                new Circle(negativeRadius);
            });
        }

        [Fact]
        public void Negative_Or_Zero_Radius_Circle_Construction()
        {
            // ARRANGE
            var negativeAndZeroRadiusThrowAssertions = new List<double>()
            {
                -1,
                -2.52345,
                0
            };

            // ACT + ASSERT
            // ACT + ASSERT
            negativeAndZeroRadiusThrowAssertions.ForEach((r) =>
            {
                Assert.Throws<NegativeOrZeroRadiusException>(() =>
                {
                    new Circle(r);
                });
            });
        }
    }
}
