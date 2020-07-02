using System;
using Common.Primitives;
using OpenTK.Graphics.OpenGL;

namespace Lab3
{
    public class Vector
    {
        private readonly Point _origin;
        private readonly Point _vector;
        public static Vector Up => new Vector(new Point{X=0, Y=0}, new Point{X=0, Y=1});
        public static Vector Right => new Vector(new Point { X = 0, Y = 0 }, new Point { X = 1, Y = 0 });
        public static Vector Down => new Vector(new Point { X = 0, Y = 0 }, new Point { X = 0, Y = -1 });
        public static Vector Left => new Vector(new Point { X = 0, Y = 0 }, new Point { X = -1, Y = 0 });

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
        private double Angle => X >= 0 ? Math.Asin(Y / Length) : Math.PI - Math.Asin(Y / Length);
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
            X *= value;
            Y *= value;
        }

        public void Move(Vector moveVector)
        {
            _origin.X += moveVector.X;
            _origin.Y += moveVector.Y;
        }

        public void Rotate(double angle)
        {
            var centerX = (_origin.X + (_origin.X + X)) / 2;
            var centerY = (_origin.Y + (_origin.Y + Y)) / 2;

            _origin.X = centerX;
            _origin.Y = centerY;


            var oldX = X;
            var oldY = Y;
            X = Math.Cos(angle) * oldX - Math.Sin(angle) * oldY;
            Y = Math.Sin(angle) * oldX + Math.Cos(angle) * oldY;

            _origin.X = (2 * _origin.X - X) / 2;
            _origin.Y = (2 * _origin.Y - Y) / 2;
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
