using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Lab2
{
    public class Program
    {
        private const int Width = 600;
        private const int Height = 800;

        public static void Main()
        {
            using (var window = new Window(Width, Height, "Lab2"))
            {
                window.Run(60.0);
            }
        }

        private class Window : GameWindow
        {
            private readonly int _width;
            private readonly int _height;
            private double _lineAngle = Math.PI / 2;
            private const double LineAngleSpeed = 0.1;

            public Window(int width, int height, string title) : base(width, height,
                GraphicsMode.Default, title)
            {
                this._width = width;
                this._height = height;
            }

            protected override void OnLoad(EventArgs e)
            {
                GL.Ortho(0, _width, 0, _height, -1, 1);
                GL.ClearColor(Color.Wheat);
                GL.Clear(ClearBufferMask.ColorBufferBit);
                DrawPicture();
                SwapBuffers();
                KeyPress += OnKeyPress;

                base.OnLoad(e);
            }

            private void DrawPicture()
            {
                GL.Clear(ClearBufferMask.ColorBufferBit);
                GL.Color3(Color.Black);
                new Semicircle(_width / 2d, _height / 2d, _height / 4d).Draw();
                new DashSeries(_width / 2d, _height / 2d, _height / 4d).Draw();
                GL.Color3(Color.Red);
                new Line(_width / 2d, _height / 2d, 0.8 * _height / 4d, _lineAngle).Draw();
            }

            private void OnKeyPress(object obj, KeyPressEventArgs args)
            {
                if (args.KeyChar != 'w' && args.KeyChar != 's') return;

                switch (args.KeyChar)
                {
                    case 'w':
                        _lineAngle -= LineAngleSpeed;
                        break;
                    case 's':
                        _lineAngle += LineAngleSpeed;
                        break;
                }

                DrawPicture();
                SwapBuffers();
            }
        }
    }
}