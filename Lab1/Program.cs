using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Point = Common.Primitives.Point;

namespace Lab1
{
    public class Program
    {
        private const int Width = 600;
        private const int Height = 800;

        public static void Main()
        {
            var points = new[]
            {
                Point.GenerateRandomPoint(Width, Height),
                Point.GenerateRandomPoint(Width, Height),
                Point.GenerateRandomPoint(Width, Height)
            };

            using (var window = new Window(Width, Height, "Lab1", points))
            {
                window.Run(60.0);
            }
        }

        private class Window : GameWindow
        {
            private readonly int _width;
            private readonly int _height;
            private readonly Point[] _points;

            public Window(int width, int height, string title, Point[] points) : base(width, height,
                GraphicsMode.Default, title)
            {
                this._width = width;
                this._height = height;
                this._points = points;
            }

            protected override void OnLoad(EventArgs e)
            {
                GL.Ortho(0, _width, 0, _height, -1, 1);
                
                GL.ClearColor(Color.CornflowerBlue);
                GL.Clear(ClearBufferMask.ColorBufferBit);
                new Fractal(_points).Draw();
                SwapBuffers();

                base.OnLoad(e);
            }
        }
    }
}