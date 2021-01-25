using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidGame
{
    static class Game
    {
        public static int Height { get; private set; }
        public static int Width { get; private set; }
        public static string AuthorName { get; private set; }
        private static SpaceShip __ship = new SpaceShip(new Point(1, 200), new Point(0, 0), new Size(10, 10));

        private static VisualObject[] __arr;
        //private static asteroid[] __arr_ast;
        //private static Bullet[] __arr_bull;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        public static void Initialize(Form myGameForm)
        {
            Height = myGameForm.ClientSize.Height;
            Width = myGameForm.ClientSize.Width;
            if ((Height | Width) > 1000 | (Height | Width) < 0) { throw new SplashScreenException("Upps! Sorry, this is not allowed!", DateTime.Now); }
            Graphics myGraphics = myGameForm.CreateGraphics();
            __Context = BufferedGraphicsManager.Current;
            __Buffer = __Context.Allocate(myGraphics, new Rectangle(0,0,Width,Height - 60));
        }

        public static void Load() 
        {
            Random rand = new Random();
            List<VisualObject> list = new List<VisualObject>();
            List<asteroid> list_ast = new List<asteroid>();
            List<Bullet> list_bull = new List<Bullet>();

            for (int i = 0; i < 7; i++)
            {
                list_ast.Add(new asteroid
                    (
                       new Point(600, i * 20),
                       new Point(15 - i, 20 - i),
                       new Size(40, 40)
                    ));
            }
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Star
                    (
                       new Point(rand.Next(0, 600), rand.Next(0, 700)),
                       new Point(-(rand.Next(1, 4)), 0),
                       new Size(5, 5)
                    ));
            }
            for (int i = 0; i < 20; i++)
            {
                list.Add(new Star
                    (
                       new Point(rand.Next(0, 600), rand.Next(0, 700)),
                       new Point(-(rand.Next(1, 2)), 0),
                       new Size(3, 3)
                    ));
            }
            for (int i = 0; i < 2; i++)
            {
                list_bull.Add(new Bullet
                    (
                       new Point(0, rand.Next(0, 500)),
                       new Point(7, 0),
                       new Size(10, 10)
                    ));
            }
            list.AddRange(list_ast);
            list.AddRange(list_bull);
            __arr = list.ToArray();
            //__arr_ast = list_ast.ToArray();
            //__arr_bull = list_bull.ToArray();
        }

        public static void Draw()
        {
            AuthorName = "Анисимов Евгений";
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);
            foreach (var obj in __arr)
            {
                obj?.Draw(g);
            }
            __ship.Draw(g);
            g.DrawString(AuthorName, new Font("Arial", 12), new SolidBrush(Color.Gray), new PointF(630, 15));
            __Buffer.Render();
        }
        public static void Update()
        {
            //foreach (var obj in __arr)
            //{
            //    obj.Update();
            //}
            for (int i = 0; i < __arr.Length; i++)
            {
                if (__arr[i] is asteroid astObj)
                {
                    for (int j = 0; j < __arr.Length; j++)
                    {
                        if (__arr[j] is Bullet bulObj)
                        {
                            if (astObj.Collision(bulObj))
                            {
                                __arr[i] = null;
                                __arr[j] = null;
                                break;
                            }
                        }
                    }//внутренний цикл
                }
                __arr[i]?.Update();
            }//внешний циклы
        }
    }
}
