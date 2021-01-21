using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HomeWork_1
{
    static class SplashScreen
    {
        public static int Heigth { get; private set; }
        public static int Width { get; private set; }
        public static string AuthorName { get; private set; }

        private static myVisualObject[] __arr;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        public static void Initialize(Form myGameForm)
        {
            Heigth = myGameForm.ClientSize.Height;
            Width = myGameForm.ClientSize.Width;
            Graphics myGraphics = myGameForm.CreateGraphics();
            __Context = BufferedGraphicsManager.Current;
            __Buffer = __Context.Allocate(myGraphics, new Rectangle(0,0,Width,Heigth - 60));
        }



        public static void Load() 
        {
            Random rand = new Random();
            const int size = 60;
            __arr = new myVisualObject[size];
            for(int i = 0; i < __arr.Length / 4; i++)
            {
                __arr[i] = new myVisualObject
                    (
                       new Point(600, i * 20),
                       new Point(15 - i, 20 - i),
                       new Size(20, 20)
                    );
            }
            for (int i = __arr.Length / 4, j = 1; i < __arr.Length / 2; i++, j++)
            {
                __arr[i] = new Star
                    (
                       new Point(rand.Next(0, 600), rand.Next(0, 800)),
                       new Point(-(rand.Next(1, 4)), 0),
                       new Size(5, 5)
                    );
            }
            for (int i = __arr.Length / 2, j = 1; i < __arr.Length; i++, j++)
            {
                __arr[i] = new Star
                    (
                       new Point(rand.Next(0, 600), rand.Next(0, 800)),
                       new Point(-(rand.Next(1, 2)), 0),
                       new Size(3, 3)
                    );
            }
        }

        public static void Draw()
        {
            AuthorName = "Анисимов Евгений";
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);
            foreach (var obj in __arr)
            {
                obj.Draw(g);
            }
            g.DrawString(AuthorName, new Font("Arial", 12), new SolidBrush(Color.Gray), new PointF(630, 15));
            __Buffer.Render();
        }
        public static void Update()
        {
            foreach (var obj in __arr)
            {
                obj.Update();
            }
        }
    }
}
