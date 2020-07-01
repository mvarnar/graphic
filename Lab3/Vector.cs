using System;
using Common.Primitives;
using OpenTK.Graphics.OpenGL;

namespace Lab3
{
    public class Vector
    {
        private readonly Point _origin;
        private readonly Point _vector;
        public double X
        {
            private set => _vector.X = value;
            get => _vector.X;
        }
        public double Y
        {
            private set => _vector.Y = value;
            get => _vector.Y;
        }

        private double Length => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        private double Angle => Math.Asin(Y / Length);
        private double WingsLength => 0.1 * Length;

        public Vector(Point origin, Point vector)
        {
            _origin = origin;
            _vector = vector;
        }

        public void Add(Vector addedVector)
        {
            X += addedVector.X;
            Y += addedVector.Y;
        }

        public void Multiply(double value)
        {
            _vector.X *= value;
            _vector.Y *= value;
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.Lines);
                GL.Vertex2(_origin.X, _origin.Y);
                GL.Vertex2(_origin.X + X, _origin.Y + Y);

                var x = WingsLength * Math.Cos(Angle - 3 * Math.PI / 4);
                var y = WingsLength * Math.Sin(Angle - 3 * Math.PI / 4);
                GL.Vertex2(_origin.X + X, _origin.Y + Y);
                GL.Vertex2(_origin.X + X + x, _origin.Y + Y + y);

                x = WingsLength * Math.Cos(Angle + 3 * Math.PI / 4);
                y = WingsLength * Math.Sin(Angle + 3 * Math.PI / 4);
                GL.Vertex2(_origin.X + X, _origin.Y + Y);
                GL.Vertex2(_origin.X + X + x, _origin.Y + Y + y);
            GL.End();
        }
    }
}
