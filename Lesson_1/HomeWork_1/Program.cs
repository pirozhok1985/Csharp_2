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

            Button StartButton = new Button();
            StartButton.Size = new Size(80, 40);
            StartButton.Location = new Point(20, 510);
            StartButton.Text = "������ ����";
            StartButton.Click += StartButton_Click;

            Button ExitButton = new Button();
            ExitButton.Size = new Size(80, 40);
            ExitButton.Location = new Point(680, 510);
            ExitButton.Text = "�����";
            ExitButton.Click += ExitButton_Click;

            Button RecordsButton = new Button();
            RecordsButton.Size = new Size(80, 40);
            RecordsButton.Location = new Point(580, 510);
            RecordsButton.Text = "�������";
            RecordsButton.Click += RecordsButton_Click;

            //Label AuthorName = new Label();
            //AuthorName.Text = "�������� �������";
            //AuthorName.Font = new Font("Arial", 40);
            //AuthorName.BackColor = Color.Transparent;
            //AuthorName.ForeColor = Color.Aqua;
            //AuthorName.Size = new Size(500, 60);
            //AuthorName.Location = new Point(150, 250);

            myGameForm.Controls.Add(StartButton);
            myGameForm.Controls.Add(ExitButton);
            myGameForm.Controls.Add(RecordsButton);
            myGameForm.Show();

            Game.Initialize(myGameForm);

            Application.Run(myGameForm);
        }

        private static void RecordsButton_Click(object sender, EventArgs e)
        {
            Button ClickedRecordsButton = (Button)sender;
            ClickedRecordsButton.Enabled = false;
            Records myRecords = new Records();
            myRecords.Show();
        }

        private static void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static void StartButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.Enabled = false;
            Timer t = new Timer { Interval = 100 };
            t.Tick += onTimerTick;
            t.Start();
            Game.Load();
        }
        private static void onTimerTick(object sender, EventArgs e)
        {
            Game.Update();
            Game.Draw();
        }
    }
}
