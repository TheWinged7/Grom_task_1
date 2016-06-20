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
//using "animation.cs";




namespace grom_task_1
{
    public partial class Form1 : Form
    {
        Random seed = new Random();
        animation An;
        Timer timer;
        System.Timers.Timer fliptimer;
        Graphics G;
        int flips;
        int[] results = new int[2] { 0, 0 };
        Image currentFrame;
        Image heads;
        Image tails;
        bool finishFlipping = false;
        bool getNextFrame = true;
        int result;

      
        public Form1()
        {
            InitializeComponent();
        }

       // private void timer1_Tick(object sender, EventArgs e);
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(  ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer |
                            ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor,
                            true);

           
            G = this.CreateGraphics();

            this.Paint += Form1_Paint;

            flips = seed.Next(1, 11);

            timer = this.timer1;
            timer.Interval = 33;
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

            heads = Properties.Resources.Coin_1;
            tails = Properties.Resources.Coin_6;

            currentFrame = An.getNextImage();

            fliptimer = new System.Timers.Timer();
            fliptimer.AutoReset = true;
            fliptimer.Elapsed += fliptimer_elapsed;
            fliptimer.Interval = seed.Next(2, 6)*1000;
            flips = seed.Next(1,11);

            fliptimer.Start();

           
            
        }


        private void finishFlip()
        {         
         
           switch (result)
           {
               case 0:
                   if (An.getCurrentFrame()==0 &&flips>0)
                   {
                       finishFlipping = false;
                       getNextFrame = false;
                       flips--;
                       Invalidate(new Rectangle(90, 120, 30, 30));
                       Invalidate(new Rectangle(380, 250, 30, 30));
                   }
                   break;

               case 1:
                   if (An.getCurrentFrame() == 5 && flips > 0)
                   {
                       finishFlipping = false;
                       getNextFrame = false;
                       flips--;
                       Invalidate(new Rectangle(90, 330, 30, 30));
                       Invalidate(new Rectangle(380, 250, 30, 30));

                   }
                   break;

               default:
                //   Console.WriteLine("got a wrong number...\t"+ result );
                   break;
           }

         

        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs args)
        {
            Graphics g = args.Graphics;

            g.DrawImage(currentFrame, Width / 2 - 45, Height / 2 - 90, 90, 90);

        
            g.DrawImage(heads, 30, 20, 90, 90);
            g.DrawString("Heads:", new Font("Georgia", 16), new SolidBrush(Color.Black), new Point(20, 120));
            g.DrawString(results[0].ToString(), new Font("Georgia", 16), new SolidBrush(Color.Black), new Point(90, 120));

            g.DrawImage(tails, 30, 230, 90, 90);
            g.DrawString("Tails:", new Font("Georgia", 16), new SolidBrush(Color.Black), new Point(20, 330));
            g.DrawString(results[1].ToString(), new Font("Georgia", 16), new SolidBrush(Color.Black), new Point(90, 330));

            g.DrawString("Flips Remaining:", new Font("Georgia", 16), new SolidBrush(Color.Black), new Point(200, 250));
            g.DrawString(flips.ToString(), new Font("Georgia", 16), new SolidBrush(Color.Black), new Point(380, 250));

            
        }
        
         private void fliptimer_elapsed(object sender, EventArgs e)
        {
         //   Console.WriteLine("I Fired!\t" + fliptimer.Interval);

             if (getNextFrame)
             {
                 finishFlipping = true;
                 result = seed.Next(0, 2);
                 results[result]++;
                 finishFlip();
             }
             else
             {
                 getNextFrame = true;
             }
        }
             
             private void timer_Tick(object sender, EventArgs e)
        {
            Invalidate(new Rectangle(Width / 2 - 45, Height / 2 - 90, 90, 90) );

            if (flips > 0) {
                if (getNextFrame)
                {
                    currentFrame = An.getNextImage();
                }
                if (finishFlipping)
                {
                    finishFlip();
                }
            }
          
        }
         



 
    }
}
