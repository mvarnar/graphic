using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Point = Common.Primitives.Point;

namespace Lab3
{
    public class Program
    {
        private const int Width = 600;
        private const int Height = 800;


        public static void Main()
        {
            using (var window = new Window(Width, Height, "Lab3"))
            {
                window.Run(60.0);
            }
        }

        private class Window : GameWindow
        {
            private readonly int _width;
            private readonly int _height;
            private readonly Vector _vector;
            private readonly HashSet<char> _allowedKeys = new HashSet<char> {'q', 'w', 'e', 'a', 's', 'd', 'z', 'x'};
            private const double Speed = 10;
            private readonly Vector _up = Vector.Up;
            private readonly Vector _right = Vector.Right;
            private readonly Vector _down = Vector.Down;
            private readonly Vector _left = Vector.Left;
            private const double AngleSpeed = Math.PI / 20;
            private const double GrowSpeed = 1.1;

            public Window(int width, int height, string title) : base(width, height,
                GraphicsMode.Default, title)
            {
                this._width = width;
                this._height = height;
                _vector = new Vector(new Point {X = 300, Y = 300}, new Point {X = 0, Y = 100});
                _up.Multiply(Speed);
                _right.Multiply(Speed);
                _down.Multiply(Speed);
                _left.Multiply(Speed);
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
                GL.LineWidth(4);
                _vector.Draw();
            }

            private void OnKeyPress(object obj, KeyPressEventArgs args)
            {
                if (!_allowedKeys.Contains(args.KeyChar)) return;

                switch (args.KeyChar)
                {
                    case 'w':
                        _vector.Move(_up);
                        break;
                    case 'd':
                        _vector.Move(_right);
                        break;
                    case 's':
                        _vector.Move(_down);
                        break;
                    case 'a':
                        _vector.Move(_left);
                        break;
                    case 'q':
                        _vector.Rotate(AngleSpeed);
                        break;
                    case 'e':
                        _vector.Rotate(-AngleSpeed);
                        break;
                    case 'z':
                        _vector.Multiply(GrowSpeed);
                        break;
                    case 'x':
                        _vector.Multiply(1 / GrowSpeed);
                        break;
                }

                DrawPicture();
                SwapBuffers();
            }
        }
    }
}