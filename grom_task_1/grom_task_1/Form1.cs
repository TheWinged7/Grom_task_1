using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace grom_task_1
{
    public partial class Form1 : Form
    {

        private CoinFlipper cf = new CoinFlipper();

        Timer timer;

        Graphics G;

        Image heads;
        Image tails;

        bool coin;
        bool pong;
        bool matrix;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor,
                true);

            G = this.CreateGraphics();

            this.Paint += Form1_Paint;

            heads = Properties.Resources.Coin_1;
            tails = Properties.Resources.Coin_6;

            timer = this.timer1;
            timer.Interval = 33;
            timer.Tick += new EventHandler(timer_Tick);

            //replace this with the random selecting of task resulting in coin, matrix, or pong being true
            coin = true;
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs args)
        {
            Graphics g = args.Graphics;

            Color background = Color.FromArgb(193, 176, 150);
            g.Clear(background);

            if (coin)
            { 
                drawCoin(g); 
            }
            

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            cf.onTick();

            Invalidate(new Rectangle(Width / 2 - 45, Height / 2 - 90, 90, 90));

            Invalidate(new Rectangle(0, Height / 2 - 20, 150, Height));
            Invalidate(new Rectangle(0, 0, 150, Height / 2 - 20));
            Invalidate(new Rectangle(380, 250, 30, 30));
            

        }


        private void drawCoin(Graphics g)
        {

            g.DrawImage(cf.getCurrentFrame(), Width / 2 - 45, Height / 2 - 90, 90, 90);

            g.FillRectangle(new SolidBrush(cf.getHeadsGlow()), new Rectangle(0, 0, 150, Height / 2 - 20));
            g.FillRectangle(new SolidBrush(cf.getTailsGlow()), new Rectangle(0, Height / 2 - 20, 150, Height));

            g.DrawImage(heads, 30, 20, 90, 90);
            g.DrawString("Heads:", new Font("Georgia", 16), new SolidBrush(Color.Black), new Point(20, 120));
            g.DrawString(cf.getHeads(), new Font("Georgia", 16), new SolidBrush(Color.Black), new Point(90, 120));

            g.DrawImage(tails, 30, Height / 2, 90, 90);
            g.DrawString("Tails:", new Font("Georgia", 16), new SolidBrush(Color.Black), new Point(20, Height / 2 + 100));
            g.DrawString(cf.getTails(), new Font("Georgia", 16), new SolidBrush(Color.Black), new Point(90, Height / 2 + 100));

            g.DrawString("Flips Remaining:", new Font("Georgia", 16), new SolidBrush(Color.Black), new Point(200, 250));
            g.DrawString(cf.getFlipsLeft(), new Font("Georgia", 16), new SolidBrush(Color.Black), new Point(380, 250));

            g.FillRectangle(new SolidBrush(cf.getHeadsFade()), new Rectangle(0, 0, 150, Height / 2 - 20));
            g.FillRectangle(new SolidBrush(cf.getTailsFade()), new Rectangle(0, Height / 2 - 20, 150, Height));

            g.DrawLine(new Pen(Color.Black, 4), 150, 0, 150, Height);
            g.DrawLine(new Pen(Color.Black, 4), 0, Height / 2 - 20, 150, Height / 2 - 20);
        }
    }
}
