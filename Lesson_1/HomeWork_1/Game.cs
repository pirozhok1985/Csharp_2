using System;
using System.Collections;
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
        private static List<asteroid> __astList = new List<asteroid>(__astCount);
        private static Random __rand = new Random();

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
            __Buffer = __Context.Allocate(myGraphics, new Rectangle(0,0,Width,Height));
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
                __bullet = new Bullet(new Point(__ship.rect.X + 5,__ship.rect.Y), new Point(13, 0), new Size(10,5));
            if(e.KeyCode == Keys.Down)
                __ship.Down();
            if (e.KeyCode == Keys.Up)
                __ship.Up();
        }

        public static void Load() 
        {
            List<VisualObject> list = new List<VisualObject>();

            for (int i = 0; i < __astCount; i++)
            {
                __astList.Add(new asteroid
                    (
                       new Point(__rand.Next(650, 730), __rand.Next(-10, 450)),
                       new Point(-(__rand.Next(3, 6)), 0),
                       new Size(40, 40)
                    ));
            }
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Star
                    (
                       new Point(__rand.Next(0, 600), __rand.Next(0, 700)),
                       new Point(-(__rand.Next(1, 4)), 0),
                       new Size(5, 5)
                    ));
            }
            for (int i = 0; i < 20; i++)
            {
                list.Add(new Star
                    (
                       new Point(__rand.Next(0, 600), __rand.Next(0, 700)),
                       new Point(-(__rand.Next(1, 2)), 0),
                       new Size(3, 3)
                    ));
            }
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

        private static void asteroidLoad()
        {
            __astCount += 1;
            for (int i = 0; i < __astCount; i++)
            {
                __astList.Add(new asteroid
                (
                    new Point(__rand.Next(650, 730), __rand.Next(-10, 450)),
                    new Point(-(__rand.Next(3, 6)), 0),
                    new Size(40, 40)
                ));
            }
        }

        public static void Draw()
        {
            __authorName = "Анисимов Евгений";
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);
            foreach (var obj in __arr)
            {
                obj.Draw(g);
            }
            foreach (var ast in __astList)
            {
                ast?.Draw(g);
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
            foreach (var obj in __arr)
            {
                obj?.Update();
            }

            for (int i = 0; i < __astList.Count; i++)
            {
                if (__bullet is Bullet)
                {
                    if (__astList[i].Collision(__bullet) && __count < __astCount)
                    {
                        __astList.RemoveAt(i);
                        __bullet = null;
                        __count++;
                        __gameScore += 10;
                        if (__count == __astCount) asteroidLoad();
                        break;
                    }
                }

                if (__astList[i].Collision(__ship))
                {
                    __ship.EnergyLow(50);
                    __astList.RemoveAt(i);
                    if (__ship.Energy <= 0) __ship.Die();
                }
                __astList[i]?.Update();
            }
        }
    }
}
