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
            using (var window = new Window(Width, Height, "LearnOpenTK"))
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
                GL.Color3(Color.Black);
                GL.ClearColor(Color.CornflowerBlue);
                GL.Clear(ClearBufferMask.ColorBufferBit);

                SwapBuffers();

                base.OnLoad(e);
            }
        }
    }
}