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
        public static int __AstCount = 10;
        public static int __AstSpeed = 4;
        private static int __GameScore = new int();
        public static string __AuthorName { get; private set; }
        public static SpaceShip __Ship = new SpaceShip(new Point(1, 200), new Point(5, 5), new Size(25, 15));
        public static Timer __T = new Timer { Interval = 100 };
        private static int __Count = new int();
        private static VisualObject[] __Arr;
        private static List<asteroid> __AstList = new List<asteroid>(__AstCount);
        private static List<Bullet> __Bullet = new List<Bullet>();
        private static Random __Rand = new Random();

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        public delegate void Logger<T>(T message);
        public static event Logger<string> str_logger;



        public static void Initialize(Form myGameForm)
        {
            Height = myGameForm.ClientSize.Height;
            Width = myGameForm.ClientSize.Width;
            if (Height > 1000 | Width > 1000 | Height < 0 | Width < 0) { throw new SplashScreenException("Upps! Sorry, this is not allowed!", DateTime.Now); }
            Graphics myGraphics = myGameForm.CreateGraphics();
            __Context = BufferedGraphicsManager.Current;
            __Buffer = __Context.Allocate(myGraphics, new Rectangle(0,0,Width,Height));
            SpaceShip.messageDie += GameOver;
            __T.Tick += onTimerTick;
            __T.Start();
            Game.Load();
            myGameForm.KeyDown += OnMyGameForm_KeyDown;
            str_logger += on_str_logger;
            str_logger += on_file_logger;
        }

        public static void Load() 
        {
            List<VisualObject> list = new List<VisualObject>();

            for (int i = 0; i < __AstCount; i++)
            {
                __AstList.Add(new asteroid
                    (
                       new Point(650 + i*40, __Rand.Next(0, Height - 40)),
                       new Point(-__AstSpeed, 0),
                       new Size(40, 40)
                    ));
            }
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Star
                    (
                       new Point(__Rand.Next(0, Width), __Rand.Next(0, Height)),
                       new Point(-(__Rand.Next(1, 4)), 0),
                       new Size(5, 5)
                    ));
            }
            for (int i = 0; i < 20; i++)
            {
                list.Add(new Star
                    (
                       new Point(__Rand.Next(0, Width), __Rand.Next(0, Height)),
                       new Point(-(__Rand.Next(1, 2)), 0),
                       new Size(3, 3)
                    ));
            }
            __Arr = list.ToArray();
        }

        public static void Draw()
        {
            __AuthorName = "Анисимов Евгений";
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);
            foreach (var obj in __Arr)
            {
                obj.Draw(g);
            }
            foreach (var ast in __AstList)
            {
                if(ast.Enable == true) ast.Draw(g);
            }
            foreach (var bullet in __Bullet)
            {
                if(bullet.Enable == true) bullet.Draw(g);
            }
            __Ship?.Draw(g);
            g.DrawString(__AuthorName, new Font("Arial", 12), new SolidBrush(Color.Gray), new PointF(630, 15));
            if(__T.Enabled)
            __Buffer.Render();
        }
        public static void Update()
        {
            foreach (var obj in __Arr)
            {
                obj?.Update();
            }

            for (int i = 0; i < __AstList.Count; i++)
            {
                foreach (var bullet in __Bullet)
                {
                    if (__AstList[i].Collision(bullet) && __Count < __AstCount && bullet.Enable == true && __AstList[i].Enable == true)
                    {
                        __AstList[i].Enable = false;
                        bullet.Enable = false;
                        __Count++;
                        __GameScore += 10;
                        if (__Count == __AstCount) asteroidLoad();
                        break;
                    }
                }
                if (__AstList.Contains(__AstList[i]) && __AstList[i].Collision(__Ship) && __AstList[i].Enable == true)
                {
                    __Ship.EnergyLow(50);
                    __AstList.RemoveAt(i);
                    if (__Ship.Energy <= 0) __Ship.Die();
                }
                __AstList[i]?.Update();
            }

            foreach (var bullet in __Bullet)
            {
                bullet.Update();
            }
        }

        private static void asteroidLoad()
        {
            __Count = 0;
            //__AstSpeed += 1;
            for (int i = 0; i < __AstCount; i++)
            {
                __AstList[i].Reset();
            }
            __AstList.Add(new asteroid
            (
                new Point(650 + __Rand.Next(0, __AstCount) * 40, __Rand.Next(0, Height - 40)),
                new Point(-__AstSpeed, 0),
                new Size(40, 40)
            ));
            __AstCount += 1;
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
                if (__Bullet.Count == 0 || __Bullet.All(b => b.Enable == true))
                    __Bullet.Add(new Bullet(new Point(__Ship.rect.X + 5, __Ship.rect.Y), new Point(13, 0),
                        new Size(10, 5)));
                else
                   __Bullet.First(b => b.Enable == false).Reset();
                    
                
            }
            if (e.KeyCode == Keys.Down)
                __Ship.Down();
            if (e.KeyCode == Keys.Up)
                __Ship.Up();
        }


        public static void GameOver(object sender, EventArgs e)
        {
            str_logger?.Invoke("Вы проиграли!!!");
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Red);
            g.DrawString("Game Over", new Font("Arial", 30), new SolidBrush(Color.Black), new PointF(300, 200));
            __Buffer.Render();
            Game.__T.Stop();
        }
    }
}
