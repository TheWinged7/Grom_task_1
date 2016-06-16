using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grom_task_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void Form1_Paint (object sender, System.Windows.Forms.PaintEventArgs args)
        {
            //examples
           // args.Graphics.DrawRectangle(Pens.Black, new Rectangle(0, 0, 100, 100));
          //  args.Graphics.FillEllipse (Brushes.Black, new Rectangle(Width-150, Height-150, 100, 100));
          //  args.Graphics.DrawString("foo", new Font("Calibri", 30), Brushes.HotPink, Width / 2, Height / 2 );
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

    }
}
