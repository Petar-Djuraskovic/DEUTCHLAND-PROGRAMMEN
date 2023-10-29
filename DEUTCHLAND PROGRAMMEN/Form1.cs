using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEUTCHLAND_PROGRAMMEN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x, y, a;
        Pen olovka = new Pen(Color.Aqua, 3);
        Random rand = new Random();
        int remaining = 0;
        Point incrementPoint = new Point(0, 0);

        private Point randomizeLabelPosition(Label label, int remaining)
        {
            int targetY = rand.Next(0, 800);
            int targetX = rand.Next(0, 620);
            //Console.WriteLine($"targetX: {targetX}, targetY: {targetY}");

            int incrementX = (label.Left - targetX) / remaining;
            int incrementY = (label.Top - targetY) / remaining;

            return new Point(incrementX, incrementY);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remaining != 0)
            {
                label1.Top += incrementPoint.Y;
                label1.Left += incrementPoint.X;
                remaining--;
            }
            else
            {
                remaining = 100;
                incrementPoint = randomizeLabelPosition(label1, remaining);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;
            Console.WriteLine(e.X + "   " + e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            g.DrawLine(olovka, x, y, e.X, e.Y);
        }
    }
}
