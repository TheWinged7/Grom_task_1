using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace grom_task_1
{
    class PongSim
    {

        private Rectangle leftPaddle;
        private Rectangle rightPaddle;
        private Rectangle ball;

        private int leftY;
        private int rightY;
        private int[] ballPos;
        private int[] scores;
        private int width;
        private int height;
        private int xVelocity ;
        private int yVelocity ;
        private Random seed = new Random();
        private bool alerted = false;

        public PongSim(int w, int h)
        {
            leftY = h / 2;
            rightY = h / 2;
            width = w;
            height = h;
            ballPos = new int[2] { w / 2 - 5, h / 2 - 5 };
            scores = new int[2] { 0, 0 };

            setVelocity();


            ball = new Rectangle(ballPos[0], ballPos[1] , 10,10 );
            leftPaddle = new Rectangle(20, h/2 -25, 10, 50 );
            //rightPaddle = new Rectangle(w - 50, h / 2 +7, 10, 50);

            rightPaddle = new Rectangle(w - 50, h / 2 - 25, 10, 50);

        }

        public void  drawFrame(Graphics g)
        {
            g.Clear(Color.Black);
           




            for (int i = 0; i < height - 10; i+=20 )
            {
                g.DrawLine(new Pen(Color.White, 2), new Point(width / 2, i), new Point(width / 2, i+10));
            }

            g.DrawString(scores[0].ToString(), new Font("Georgia", 15), new SolidBrush(Color.White),
                        new Point(width / 2 - 30, 5));

            g.DrawString(scores[1].ToString(), new Font("Georgia", 15), new SolidBrush(Color.White),
                        new Point(width / 2 + 15, 5));

            g.FillEllipse(new SolidBrush(Color.White), ball);
            g.FillRectangle(new SolidBrush(Color.White), leftPaddle);
            g.FillRectangle(new SolidBrush(Color.White), rightPaddle);



                if (scores[0] == 10)
                {
                    xVelocity = 0;
                    yVelocity = 0;

                    g.DrawString("Player 1 Wins!", new Font("Georgia", 30), new SolidBrush(Color.White),
                        new Point(width / 2 - 130, height / 2 - 100));

                }
            if (scores[1] == 1)
            {
                xVelocity = 0;
                yVelocity = 0;

                g.DrawString("Player 2 Wins!", new Font("Georgia", 30), new SolidBrush(Color.White),
                   new Point(width / 2 - 130, height / 2 - 100));

               
            }
        }

        public void onTick()
        {
            ball.X += xVelocity;
            ball.Y += yVelocity;

            checkBounce();

            rightPaddle.Y = ball.Y - 25;

            if (rightPaddle.Y > height - 80)
            {
                rightPaddle.Y = height - 80;
            }
            if (rightPaddle.Y < 0)
            {
                rightPaddle.Y = 0;
            }

            leftPaddle.Y = rightPaddle.Y +50;
            if (leftPaddle.Y >height -80)
            {
                leftPaddle.Y = height-80;
            }

            if (scores[1] ==1 && !alerted)
            {
                alerted = true;
                
                    MessageBox.Show("I can't win, the other guy cheats :(", "Player 1",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               
            }
           
        }

        private void checkBounce()
        {
            if (ball.X >= width-25)
            {
                setVelocity();
                ball.X = ballPos[0];
                ball.Y = ballPos[1];
                scores[0]++;

            }
            if ( ball.X <=5)
            {
                setVelocity();

                ball.X = ballPos[0];
                ball.Y = ballPos[1];
                scores[1]++;

            }

            if (ball.Y >= height -50 || ball.Y <= 0 )
            {
                yVelocity *= -1;
            }


            if (
                (rightPaddle.X - ball.X <= 10 && (ball.Y - rightPaddle.Y <= 50 && ball.Y - rightPaddle.Y >= -10))
                ||  
                (ball.X - leftPaddle.X <=9  && (ball.Y - leftPaddle.Y <=50 && ball.Y - leftPaddle.Y >=-10 ) )
                )

            {
                xVelocity *= -1;
            }
        }

        private void setVelocity()
        {
            xVelocity = seed.Next(-1,2);
            if (xVelocity == 0)
            {
                while (xVelocity == 0)
                {
                    xVelocity = seed.Next(-1, 2);
                }
                
            }
            xVelocity *= seed.Next(3,6);
            
            yVelocity = seed.Next(-1, 2);
            if (yVelocity == 0 || yVelocity==xVelocity)
            {
                while (yVelocity == 0 || yVelocity == xVelocity)
                {
                    yVelocity = seed.Next(-1, 2);
                }
               

            }
            yVelocity *= seed.Next(3, 6);
           
        }







    }
}
