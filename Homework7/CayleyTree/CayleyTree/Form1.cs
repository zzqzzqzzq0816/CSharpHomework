using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void draw_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            SetAttributes();
            drawCayleyTree(n, 200, 310, leng, -Math.PI / 2);
        }
        private Graphics graphics;
        int n,th11,th22;
        double leng,per1, per2, th1, th2;

        private void clear_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
        }

        Pen pen;
        void SetAttributes()
        {
            try
            {
                n = Convert.ToInt32(textn.Text);
                leng = Convert.ToDouble(textleng.Text);
                per1 = Convert.ToDouble(textper1.Text);
                per2 = Convert.ToDouble(textper2.Text);
                th11 = Convert.ToInt32(textth1.Text);
                th22 = Convert.ToInt32(textth2.Text);
                th1 = th11 * Math.PI / 180;
                th2 = th22 * Math.PI / 180;
                switch (chooseColor.Text)
                {
                    case "blue":pen = Pens.Blue;break;
                    case "green":pen = Pens.Green;break;
                    case "red":pen = Pens.Red;break;
                    default:pen = null;break;
                }
            }
            catch (Exception e)
            {
                this.Dispose();
            }
            if (n <= 0 || leng <= 0 || per1 < 0 || per1 > 1 || per2 < 0 || per2 > 1 || th11 < 0 
                || th22 < 0 || th11 > 90 || th22 > 90 || pen==null)
            {
                this.Dispose();
            }
        }
        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }
    }
}
