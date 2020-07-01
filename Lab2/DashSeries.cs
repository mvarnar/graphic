using System;
using System.Linq;
using OpenTK.Graphics.OpenGL;

namespace Lab2
{
    public class DashSeries
    {
        private readonly double _originX;
        private readonly double _originY;
        private readonly double _radius;
        private readonly int _numSegments;
        private readonly int _numDashes;
        private const double CoefficintOfLength = 1.1;

        public DashSeries(double originX, double originY, double radius, int numSegments = 10000,
            int numDashes = 5)
        {
            _originX = originX;
            _originY = originY;
            _radius = radius;
            _numSegments = numSegments;
            _numDashes = numDashes;
        }
        public void Draw()
        {
            GL.Begin(PrimitiveType.Lines);
            var lengthBetweenDashes = _numSegments / (_numDashes - 1);
            var dashesPosition = Enumerable.Range(0, _numDashes).Select(num => num * lengthBetweenDashes);
            
            foreach (var position in dashesPosition)
            {
                var theta = Math.PI * position / _numSegments;

                var x = _radius * Math.Cos(theta);
                var y = _radius * Math.Sin(theta);

                GL.Vertex2(CoefficintOfLength * x + _originX, CoefficintOfLength * y + _originY);
                GL.Vertex2(1 / CoefficintOfLength * x + _originX, 1 / CoefficintOfLength * y + _originY);
            }

            GL.End();
        }
    }
}
