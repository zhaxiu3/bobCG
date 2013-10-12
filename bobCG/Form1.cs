using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bobCG
{
    public partial class Form1 : Form
    {
        CGPoint2D[] points;
        Pen axisPen = Pens.Purple;
        public Form1()
        {
            initModel();
            InitializeComponent();
        }
        private void initModel() { 
            points = new CGPoint2D[11];
            for (int i = 0; i < points.Length; i++) {
                points[i] = new CGPoint2D(0, 0);
            }
        }
        
        protected override void OnPaint(PaintEventArgs e) 
        {
            Graphics _g =  e.Graphics;
            base.OnPaint(e);

            for (int i = 0; i < points.Length; i++) {
                //draw vertical lines
                _g.DrawLine(axisPen, (int)points[i].X, 0, (int)points[i].X, this.ClientSize.Height);
                //draw horizental lines
                _g.DrawLine(axisPen, 0, (int)points[i].Y, this.ClientSize.Width, (int)points[i].Y);
            }

            this.Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X = (double)this.ClientSize.Width / (double)(points.Length-1) * ((double)i);
                points[i].Y = (double)this.ClientSize.Height / (double)(points.Length - 1) * ((double)i);
            }
        }
    }
}
