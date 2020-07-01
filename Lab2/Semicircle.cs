using System;
using OpenTK.Graphics.OpenGL;

namespace Lab2
{
    public class Semicircle
    {
        private readonly double _originX;
        private readonly double _originY;
        private readonly double _radius;
        private readonly int _numSegments;

        public Semicircle(double originX, double originY, double radius, int numSegments = 10000)
        {
            _originX = originX;
            _originY = originY;
            _radius = radius;
            _numSegments = numSegments;
        }
        public void Draw()
        {
            GL.Begin(PrimitiveType.LineStrip);
            for (var i = 0; i < _numSegments; i++)
            {
                var theta = Math.PI * i / _numSegments;

                var x = _radius * Math.Cos(theta);
                var y = _radius * Math.Sin(theta);

                GL.Vertex2(x + _originX, y + _originY);
            }
            GL.End();
        }
    }
}
