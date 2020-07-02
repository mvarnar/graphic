using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using Point = Common.Primitives.Point;

namespace Lab1
{
    public class Fractal
    {
        private const int NumberOfIterations = 50_000;
        private const int NumberOfVertices = 3;
        private readonly Point[] _points;

        public Fractal(Point[] points)
        {
            this._points = points;
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.Points);

            var random = new Random();
            var p = _points[random.Next(NumberOfVertices)];
            for (var i = 0; i < NumberOfIterations; i++)
            {
                if (i % 2 == 0)
                {
                    GL.Color3(Color.Red);
                }
                else if (i % 3 == 0)
                {
                    GL.Color3(Color.Green);
                }
                else
                {
                    GL.Color3(Color.Blue);
                }
                var T = _points[random.Next(NumberOfVertices)];
                p = Point.FindPointBetween(p, T);
                GL.Vertex2(p.X, p.Y);
            }

            GL.End();
        }
    }
}
