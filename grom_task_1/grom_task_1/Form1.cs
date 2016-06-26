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

        private CoinFlipper cf;
        private PongSim ps;

        Timer timer;

        Graphics G;

        Image heads;
        Image tails;

        bool coin = false;
        bool pong = false;
        bool matrix = false;

        Random seed = new Random();
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
           // coin = true;
            int game = seed.Next(0, 3);

            switch( game)
            {
                case 0:
                    coin = true;
                    break;
                case 1:
                    pong = true;
                    break;
                default:
                    Console.WriteLine("well fuck");
                    break;
            }

            if (coin)
            { 
                cf = new CoinFlipper();
            }
            else if (pong)
            {
                ps = new PongSim(Width, Height);
            }
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs args)
        {
            Graphics g = args.Graphics;

            Color background = Color.FromArgb(193, 176, 150);
            g.Clear(background);

            if (coin)
            {
                cf.drawFrame(g, Width, Height);
            }
            else if (pong)
            {
                ps.drawFrame(g);
            }
            

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (coin)
            {
                cf.onTick();
                Invalidate(new Rectangle(0, 0, Width, Height) );

            }
            if (pong)
            {
                ps.onTick();
                Invalidate(new Rectangle(0, 0, Width, Height));
            }

        }


       
    }
}
