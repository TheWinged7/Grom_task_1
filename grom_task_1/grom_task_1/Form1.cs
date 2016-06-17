using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using "animation.cs";



namespace grom_task_1
{
    public partial class Form1 : Form
    {
        animation An;
        Timer timer;
        Graphics G;
        public Form1()
        {
            InitializeComponent();
        }

       // private void timer1_Tick(object sender, EventArgs e);
        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            this.Paint += new PaintEventHandler(Form1_Paint);
            G = this.CreateGraphics();

            timer = this.timer1;
            timer.Interval = 64;
            timer.Tick += new EventHandler(timer_Tick);

            An = new animation(new Image[] {
                Properties.Resources.Coin_1,
                Properties.Resources.Coin_2,
                Properties.Resources.Coin_3,
                Properties.Resources.Coin_4,
                Properties.Resources.Coin_5,
                Properties.Resources.Coin_6,
                Properties.Resources.Coin_7,
                Properties.Resources.Coin_8,
                Properties.Resources.Coin_9,
                Properties.Resources.Coin_10,
                Properties.Resources.Coin_11
                }
            );


            timer.Start();
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs args)
        {
        }
        
        private void timer_Tick(object sender, EventArgs e)
        {
            G.Clear(Color.LightGray);
            G.DrawImage(An.getNextImage(), Width / 2 -45, Height / 2 -45, 90, 90);

        }
         

    }
}
