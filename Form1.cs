using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5_31
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        public int Degree1 { get; set; }//分支角度
        public int Degree2 { get; set; }//分支角度
        public double Per1 { get; set; }//分支长度比1
        public double Per2 { get; set; }//分支长度比2
        public double Length { get; set; } //主干高度
        public int N { get; set; }//迭代次数
        public Pen DrawPen { get; set; }//画笔
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen[] pens = { Pens.Red, Pens.Green, Pens.Yellow };
            DrawPen = pens[comboBox1.SelectedIndex];
            Degree1 = Convert.ToInt32(textBox1.Text);
            Degree2 = Convert.ToInt32(textBox2.Text);
            Per1 = Convert.ToDouble(textBox3.Text);
            Per2 = Convert.ToDouble(textBox4.Text);
            Length = Convert.ToDouble(textBox5.Text);
            N = Convert.ToInt32(textBox6.Text);
            graphics = this.panel1.CreateGraphics();
            graphics.Clear(panel1.BackColor);
            drawCayleyTree(this.N, panel1.Width / 2, panel1.Height - 20, this.Length, -Math.PI / 2);
        }
        void drawCayleyTree(int n, double x0, double y0, double len, double th)
        {
            if (n == 0) return;
            double x1 = x0 + len * Math.Cos(th);
            double y1 = y0 + len * Math.Sin(th);
            graphics.DrawLine(DrawPen,
               (int)x0, (int)y0, (int)x1, (int)y1);
            drawCayleyTree(n - 1, x1, y1, this.Per1 * len, th + this.Degree1 * Math.PI / 180);
            drawCayleyTree(n - 1, x1, y1, this.Per2 * len, th - this.Degree2 * Math.PI / 180);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedItem = 0;
        }
    }
}
