using System;
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
            using (var window = new Window(Width, Height, "Lab2"))
            {
                window.Run(60.0);
            }
        }

        private class Window : GameWindow
        {
            private readonly int _width;
            private readonly int _height;

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
                GL.Color3(Color.Black);
                GL.LineWidth(4);
                new Vector(new Point {X = 100, Y = 100}, new Point {X=0, Y=300}).Draw();
                new Vector(new Point { X = 300, Y = 300 }, new Point { X = 100, Y = 100 }).Draw();
            }

            private void OnKeyPress(object obj, KeyPressEventArgs args)
            {
                DrawPicture();
                SwapBuffers();
            }
        }
    }
}