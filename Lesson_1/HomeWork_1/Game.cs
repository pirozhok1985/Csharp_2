using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace AsteroidGame
{
    static class Game
    {
        public static int Height { get; private set; }
        public static int Width { get; private set; }
        public static int __astCount = 10;
        private static int __gameScore = new int();
        public static string __authorName { get; private set; }
        private static SpaceShip __ship = new SpaceShip(new Point(1, 200), new Point(5, 5), new Size(25, 15));
        private static Bullet __bullet;
        public static Timer t = new Timer { Interval = 100 };
        private static int __count = new int();
        private static VisualObject[] __arr;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        public delegate void Logger<T>(T message);
        public static event Logger<string> str_logger;



        public static void Initialize(Form myGameForm)
        {
            Height = myGameForm.ClientSize.Height;
            Width = myGameForm.ClientSize.Width;
            if ((Height | Width) > 1000 | (Height | Width) < 0) { throw new SplashScreenException("Upps! Sorry, this is not allowed!", DateTime.Now); }
            Graphics myGraphics = myGameForm.CreateGraphics();
            __Context = BufferedGraphicsManager.Current;
            __Buffer = __Context.Allocate(myGraphics, new Rectangle(0,0,Width,Height - 60));
            SpaceShip.messageDie += GameOver;
            t.Tick += onTimerTick;
            t.Start();
            Game.Load();
            myGameForm.KeyDown += OnMyGameForm_KeyDown;
            str_logger += on_str_logger;
            str_logger += on_file_logger;
        }

        private static void on_file_logger(string message)
        {
            using(var fc = File.CreateText("log.txt"))
                fc.WriteLine(message);
        }

        private static void on_str_logger(string message)
        {
            AllocConsole();
            Console.WriteLine(message);
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool AllocConsole();
        }

        private static void Game_Logger()
        {
           
        }

        private static void onTimerTick(object sender, EventArgs e)
        {
            Game.Update();
            Game.Draw();
        }

        private static void OnMyGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                __bullet = new Bullet(new Point(__ship.rect.X + 5,__ship.rect.Y), new Point(8, 0), new Size(10,5));
            if(e.KeyCode == Keys.Down)
                __ship.Down();
            if (e.KeyCode == Keys.Up)
                __ship.Up();
        }

        public static void Load() 
        {
            Random rand = new Random();
            List<VisualObject> list = new List<VisualObject>();
            List<asteroid> list_ast = new List<asteroid>();
            //List<Bullet> list_bull = new List<Bullet>();

            for (int i = 0; i < __astCount; i++)
            {
                list_ast.Add(new asteroid
                    (
                       new Point(rand.Next(0, 500), rand.Next(0, 450)),
                       new Point(-(rand.Next(3, 6)), 0),
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
            //for (int i = 0; i < 2; i++)
            //{
            //    list_bull.Add(new Bullet
            //        (
            //           new Point(0, rand.Next(0, 500)),
            //           new Point(7, 0),
            //           new Size(10, 10)
            //        ));
            //}
            list.AddRange(list_ast);
            //list.AddRange(list_bull);
            __arr = list.ToArray();
        }

        public static void GameOver(object sender, EventArgs e)
        {
            str_logger?.Invoke("Вы проиграли!!!");
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Red);
            g.DrawString("Game Over", new Font("Arial", 30), new SolidBrush(Color.Black), new PointF(300, 200));
            __Buffer.Render();
            Game.t.Stop();
        }

        private static void Finish()
        {
            str_logger?.Invoke(string.Format("Конец игры\nКоличество заработанных очков:{0}",__gameScore));
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Blue);
            g.DrawString("You Win!!", new Font("Arial", 30), new SolidBrush(Color.Black), new PointF(300, 200));
            g.DrawString(string.Format("Score is:{0}",__gameScore), new Font("Arial", 30), new SolidBrush(Color.Black), new PointF(300, 240));
            __Buffer.Render();
            Game.t.Stop();
        }

        public static void Draw()
        {
            __authorName = "Анисимов Евгений";
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);
            foreach (var obj in __arr)
            {
                obj?.Draw(g);
            }
            __ship?.Draw(g);
            __bullet?.Draw(g);
            g.DrawString(__authorName, new Font("Arial", 12), new SolidBrush(Color.Gray), new PointF(630, 15));
            if(t.Enabled)
            __Buffer.Render();
        }
        public static void Update()
        {
            __bullet?.Update();
            for (int i = 0; i < __arr.Length; i++)
            {
                if (__arr[i] is asteroid astObj)
                {
                    if (__bullet is Bullet bulObj)
                    {
                        if (astObj.Collision(bulObj) && __count < 10)
                        {
                            __arr[i] = null;
                            __bullet = null;
                            __count++;
                            __gameScore += 10;
                            break;
                        }
                        if(__count == 9) Finish();
                    }

                    if (__ship is SpaceShip shipObj)
                    {
                        if (astObj.Collision(shipObj))
                        {
                            shipObj.EnergyLow(50);
                            __arr[i] = null;
                            if (shipObj.Energy <= 0) shipObj.Die();
                            break;
                        }
                    }
                }
                __arr[i]?.Update();
            }
        }
    }
}
