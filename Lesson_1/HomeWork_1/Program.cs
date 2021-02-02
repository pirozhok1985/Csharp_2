using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidGame
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();

            Form myGameForm = new Form();
            myGameForm.Height = 600;
            myGameForm.Width = 800;

            //Button StartButton = new Button();
            //StartButton.Size = new Size(80, 40);
            //StartButton.Location = new Point(20, 510);
            //StartButton.Text = "Начало Игры";
            //StartButton.Click += StartButton_Click;

            //Button ExitButton = new Button();
            //ExitButton.Size = new Size(80, 40);
            //ExitButton.Location = new Point(680, 510);
            //ExitButton.Text = "Выход";
            //ExitButton.Click += ExitButton_Click;

            //Button RecordsButton = new Button();
            //RecordsButton.Size = new Size(80, 40);
            //RecordsButton.Location = new Point(580, 510);
            //RecordsButton.Text = "Рекорды";
            //RecordsButton.Click += RecordsButton_Click;

            //Label __AuthorName = new Label();
            //__AuthorName.Text = "Анисимов Евгений";
            //__AuthorName.Font = new Font("Arial", 40);
            //__AuthorName.BackColor = Color.Transparent;
            //__AuthorName.ForeColor = Color.Aqua;
            //__AuthorName.Size = new Size(500, 60);
            //__AuthorName.Location = new Point(150, 250);

            //myGameForm.Controls.Add(StartButton);
            //myGameForm.Controls.Add(ExitButton);
            //myGameForm.Controls.Add(RecordsButton);
            //myGameForm.Show();

            Game.Initialize(myGameForm);

            Application.Run(myGameForm);
        }


        //private static void RecordsButton_Click(object sender, EventArgs e)
        //{
        //    Button ClickedRecordsButton = (Button)sender;
        //    ClickedRecordsButton.Enabled = false;
        //    Records myRecords = new Records();
        //    myRecords.Show();
        //}

        //private static void ExitButton_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        //private static void StartButton_Click(object sender, EventArgs e)
        //{
        //    Button clickedButton = (Button)sender;
        //    clickedButton.Enabled = false;
        //    Timer __T = new Timer { Interval = 100 };
        //    __T.Tick += onTimerTick;
        //    __T.Start();
        //    Game.Load();
        //}
        //private static void onTimerTick(object sender, EventArgs e)
        //{
        //    Game.Update();
        //    Game.Draw();
        //}
    }
}
