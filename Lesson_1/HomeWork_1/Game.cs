using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AsteroidGame
{
    static class Game
    {
        public static int Height { get; private set; }
        public static int Width { get; private set; }
        public static int __astCount = 10;
        public static int __astSpeed = 4;
        private static int __gameScore = new int();
        public static string __authorName { get; private set; }
        public static SpaceShip __ship = new SpaceShip(new Point(1, 200), new Point(5, 5), new Size(25, 15));
        public static Timer t = new Timer { Interval = 100 };
        private static int __count = new int();
        private static VisualObject[] __arr;
        private static List<asteroid> __astList = new List<asteroid>(__astCount);
        private static List<Bullet> __bullet = new List<Bullet>();
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

        public static void Load() 
        {
            List<VisualObject> list = new List<VisualObject>();

            for (int i = 0; i < __astCount; i++)
            {
                __astList.Add(new asteroid
                    (
                       new Point(650 + i*40, __rand.Next(0, Height - 40)),
                       new Point(-__astSpeed, 0),
                       new Size(40, 40)
                    ));
            }
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Star
                    (
                       new Point(__rand.Next(0, Width), __rand.Next(0, Height)),
                       new Point(-(__rand.Next(1, 4)), 0),
                       new Size(5, 5)
                    ));
            }
            for (int i = 0; i < 20; i++)
            {
                list.Add(new Star
                    (
                       new Point(__rand.Next(0, Width), __rand.Next(0, Height)),
                       new Point(-(__rand.Next(1, 2)), 0),
                       new Size(3, 3)
                    ));
            }
            __arr = list.ToArray();
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
                if(ast.Enable == true) ast.Draw(g);
            }
            foreach (var bullet in __bullet)
            {
                if(bullet.Enable == true) bullet.Draw(g);
            }
            __ship?.Draw(g);
            g.DrawString(__authorName, new Font("Arial", 12), new SolidBrush(Color.Gray), new PointF(630, 15));
            if(t.Enabled)
            __Buffer.Render();
        }
        public static void Update()
        {
            foreach (var obj in __arr)
            {
                obj?.Update();
            }

            for (int i = 0; i < __astList.Count; i++)
            {
                foreach (var bullet in __bullet)
                {
                    if (__astList[i].Collision(bullet) && __count < __astCount && bullet.Enable == true && __astList[i].Enable == true)
                    {
                        __astList[i].Enable = false;
                        bullet.Enable = false;
                        __count++;
                        __gameScore += 10;
                        if (__count == __astCount) asteroidLoad();
                        break;
                    }
                }
                if (__astList.Contains(__astList[i]) && __astList[i].Collision(__ship) && __astList[i].Enable == true)
                {
                    __ship.EnergyLow(50);
                    __astList.RemoveAt(i);
                    if (__ship.Energy <= 0) __ship.Die();
                }
                __astList[i]?.Update();
            }

            foreach (var bullet in __bullet)
            {
                bullet.Update();
            }
        }

        private static void asteroidLoad()
        {
            __count = 0;
            //__astSpeed += 1;
            for (int i = 0; i < __astCount; i++)
            {
                __astList[i].Reset();
            }
            __astList.Add(new asteroid
            (
                new Point(650 + __rand.Next(0, __astCount) * 40, __rand.Next(0, Height - 40)),
                new Point(-__astSpeed, 0),
                new Size(40, 40)
            ));
            __astCount += 1;
        }
        private static void on_file_logger(string message)
        {
            using (var fc = File.CreateText("log.txt"))
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

        private static void onTimerTick(object sender, EventArgs e)
        {
            Game.Update();
            Game.Draw();
        }

        private static void OnMyGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                if (__bullet.Count == 0 || __bullet.All(b => b.Enable == true))
                    __bullet.Add(new Bullet(new Point(__ship.rect.X + 5, __ship.rect.Y), new Point(13, 0),
                        new Size(10, 5)));
                else
                   __bullet.First(b => b.Enable == false).Reset();
                    
                
            }
            if (e.KeyCode == Keys.Down)
                __ship.Down();
            if (e.KeyCode == Keys.Up)
                __ship.Up();
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
    }
}
