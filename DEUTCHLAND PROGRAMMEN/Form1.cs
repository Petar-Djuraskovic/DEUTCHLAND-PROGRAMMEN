using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DEUTCHLAND_PROGRAMMEN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x, y, a;
        Pen olovka = new Pen(Color.Black, 3);
        Random rand = new Random();
        int remaining = 0;
        (float X, float Y) incrementPoint;
        bool crtanje = false;
        bool landscaping = false;
        bool radialing = false;

        private (float X, float Y) randomizeLabelPosition(Label label, int remaining)
        {
            float targetY = rand.Next(0, 700);
            float targetX = rand.Next(0, 620);
            //Console.WriteLine($"targetX: {targetX}, targetY: {targetY}");

            float incrementX = (targetX - label.Left) / remaining;
            float incrementY = (targetY - label.Top) / remaining;

                (float X, float Y) returnTuple = (incrementX, incrementY);

            return returnTuple;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remaining != 0)
            {
                label1.Top += (int)incrementPoint.Y;
                label1.Left += (int)incrementPoint.X;
                remaining--;
            }
            else
            {
                remaining = 100;
                incrementPoint = randomizeLabelPosition(label1, remaining);
                Console.WriteLine(incrementPoint.ToString());
            }

            if (richTextBox1.Visible)
            {
                richTextBox1.Top = Form1.MousePosition.Y - this.Location.Y;
                richTextBox1.Left = Form1.MousePosition.X - this.Location.X;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            olovka.Color = colorDialog1.Color;
            pictureBox3.BackColor = colorDialog1.Color;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            Graphics g = pictureBox4.CreateGraphics();
            Brush cetka = new SolidBrush(colorDialog2.Color);
            g.FillRectangle(cetka, 0, 0, 699, 408);
            pictureBox5.BackColor = colorDialog2.Color;
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;
            Console.WriteLine(e.X + "   " + e.Y);

            if (radioButton2.Checked) { crtanje = true; }
            if (radioButton4.Checked) { landscaping = true; }
            if (radioButton5.Checked) { radialing = true; }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked) { richTextBox1.Visible = true; }
            else { richTextBox1.Visible = false; }
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            if (crtanje)
            {
                Graphics g = pictureBox4.CreateGraphics();
                int x2 = e.X, y2 = e.Y;

                g.DrawLine(olovka, x, y ,x2 , y2);

                x = x2; y = y2;
            }

            if (radialing)
            {
                Graphics g = pictureBox4.CreateGraphics();
                int x2 = e.X, y2 = e.Y;

                g.DrawLine(olovka, x2, y2, (float)numericUpDown1.Value, (float)numericUpDown1.Value);

                x = x2; y = y2;
            }

            if (landscaping)
            {
                Graphics g = pictureBox4.CreateGraphics();
                int x2 = e.X, y2 = e.Y;

                Brush cetka = new SolidBrush(colorDialog1.Color);

                g.FillRectangle(cetka, x, y, x2, y2);

                x = x2; y = y2;
            }
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked)
            {
                Graphics g = pictureBox4.CreateGraphics();
                g.DrawLine(olovka, x, y, e.X, e.Y);
            }

            crtanje = false;
            landscaping = false;
            radialing = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            olovka.Width = (float)numericUpDown1.Value;
        }
    }
}
