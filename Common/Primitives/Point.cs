using System;

namespace Common.Primitives
{
    public class Point
    {
        private static readonly Random Random = new Random();
        public double X { get; set; }
        public double Y { get; set; }

        public static Point FindPointBetween(Point a, Point b)
        {
            return new Point { X = (a.X + b.X) / 2, Y = (a.Y + b.Y) / 2 };
        }

        public static Point GenerateRandomPoint(int maxX, int maxY)
        {
            
            return new Point {X = Random.Next(maxX), Y = Random.Next(maxY)};
        }
    }
}
