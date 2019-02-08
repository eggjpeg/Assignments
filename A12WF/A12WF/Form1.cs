using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A12WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Graph();
        }
        private void Graph()
        {
            //Pen p = new Pen(Color.Red, 10);
            Graphics g = CreateGraphics();
            // this.Invalidate();
            ExpEval exp = new ExpEval();
            var list = exp.Evaluate(txtEq.Text, -100, 100, 5);
            for (int i = 0; i < list.Count - 1; i++)
            {
                var t1 = list[i];
                var t2 = list[i + 1];
                DrawLine(g, Color.Red, (float)t1.Item1, (float)t1.Item2, (float)t2.Item1, (float)t2.Item2);
            }
            g.Dispose();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            DrawAxis(g);
            

            g.Dispose();
            //DrawLine(Color.Red, 0, 0, -300, -300);
            //DrawLine(Color.Plum, 0, 0, 300, -300);
 
        }


        private void DrawAxis(Graphics g)
        {

            DrawLine(g, Color.Blue, 0, -Size.Height/2, 0, Size.Height/2);
            DrawLine(g, Color.Blue, -Size.Width/2, 0, Size.Width/2, 0);

        }

        private void DrawLine(Graphics g, Color c, float x1, float y1, float x2, float y2)
        {
            float w = this.Size.Width;
            float h = this.Size.Height;
            g.DrawLine(new Pen(c), x1 + w/2, h/2- y1, x2 + w/2, h / 2 - y2);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Graph();
        }

        private void txtEq_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
        
