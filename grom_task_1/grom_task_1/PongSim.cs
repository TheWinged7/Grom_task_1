using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace grom_task_1
{
    class PongSim
    {

        private Rectangle leftPaddle;
        private Rectangle rightPaddle;
        private Rectangle ball;

        int leftY;
        int rightY;
        int [] ballPos;
        public PongSim(int w, int h)
        {
            leftY = h / 2;
            rightY = h / 2;
            ballPos = new int[2] { w / 2 - 10, h / 2 - 5 };

            ball = new Rectangle(ballPos[0], ballPos[1] , 10,10 );
            leftPaddle = new Rectangle(20, h/2 -25, 10, 50 );
            rightPaddle = new Rectangle(w - 50, h / 2 - 25, 10, 50);

        }

        public void  drawFrame(Graphics g, int width, int height)
        {
            g.Clear(Color.Black);
            g.FillEllipse(new SolidBrush(Color.White), ball);
            g.FillRectangle(new SolidBrush(Color.White), leftPaddle);
            g.FillRectangle(new SolidBrush(Color.White), rightPaddle);

        }

        public void onTick()
        {

        }
    }
}
