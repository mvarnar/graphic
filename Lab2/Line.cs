using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace Lab2
{
    public class Line
    {
        private readonly double _originX;
        private readonly double _originY;
        private readonly double _radius;
        private readonly double _theta;

        public Line(double originX, double originY, double radius, double theta)
        {
            _originX = originX;
            _originY = originY;
            _radius = radius;
            _theta = theta;
        }
        public void Draw()
        {
            GL.Begin(PrimitiveType.Lines);
            var x = _radius * Math.Cos(_theta);
            var y = _radius * Math.Sin(_theta);
            GL.Vertex2(_originX, _originY);
            GL.Vertex2(_originX + x, _originY + y);
            GL.End();
        }
    }
}
