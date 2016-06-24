using System;
using System.Drawing;


namespace grom_task_1
{
    public class CoinFlipper
    {
        private Random seed = new Random();
        animation anim;
        System.Timers.Timer fliptimer;

        int flips;
        int[] results = new int[2] { 0, 0 };

        Image currentFrame;

        bool finishFlipping = false;
        bool retrieveNextFrame = true;
        int result;

        int headsGlowAlpha = 0;
        Color headsGlow;

        int tailsGlowAlpha = 0;
        Color tailsGlow;

        int headsFadeAlpha = 0;
        Color headsFade;

        int tailsFadeAlpha = 0;
        Color tailsFade;

       

        public CoinFlipper()
        {
            headsGlow = Color.FromArgb(headsGlowAlpha, 74, 234, 0);
            tailsGlow = Color.FromArgb(tailsGlowAlpha, 74, 234, 0);

            headsFade = Color.FromArgb(headsFadeAlpha, 30, 30, 30);
            tailsFade = Color.FromArgb(tailsFadeAlpha, 30, 30, 30);

            flips = seed.Next(1, 11);

            anim = new animation(new Image[] {
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


           

            currentFrame = anim.getNextImage();

            fliptimer = new System.Timers.Timer();
            fliptimer.AutoReset = true;
            fliptimer.Elapsed += fliptimer_elapsed;
            fliptimer.Interval = seed.Next(2, 6) * 1000;
            flips = seed.Next(1, 11);

            fliptimer.Start();

            Console.WriteLine("i flip coins");

        }

        public void onTick()
        {
            if (results[0] > results[1])
            {
                tailsFadeAlpha = 150;
                headsFadeAlpha = 0;

            }
            else if (results[1] > results[0])
            {
                tailsFadeAlpha = 0;
                headsFadeAlpha = 150;
            }
            else if (results[1]==results[0])
            {
                tailsFadeAlpha = 0;
                headsFadeAlpha = 0;
            }


            if (headsGlowAlpha > 0)
            {
                headsGlowAlpha -= 5;
                headsGlow = Color.FromArgb(headsGlowAlpha, 74, 234, 0);
            }

            if (tailsGlowAlpha > 0)
            {
                tailsGlowAlpha -= 5;
                tailsGlow = Color.FromArgb(tailsGlowAlpha, 74, 234, 0);

            }

            if (flips > 0)
            {
                if (retrieveNextFrame)
                {
                    currentFrame = anim.getNextImage();
                }
                if (finishFlipping)
                {
                    finishFlip();
                }
            }
            else
            {
                if (results[0]==results[1])
                {
                    flips = 1;
                }
                else 
                {
                    retrieveNextFrame = false;
                }
            }

            headsFade = Color.FromArgb(headsFadeAlpha, 30, 30, 30);
            tailsFade = Color.FromArgb(tailsFadeAlpha, 30, 30, 30);


        }


        private void fliptimer_elapsed(object sender, EventArgs e)
        {
            //   Console.WriteLine("I Fired!\t" + fliptimer.Interval);

            if (retrieveNextFrame)
            {
                finishFlipping = true;
                result = seed.Next(0, 2);
                results[result]++;
                finishFlip();
            }
            else
            {
                retrieveNextFrame = true;
            }
        }

        private void finishFlip()
        {

            switch (result)
            {
                case 0:
                    if (anim.getCurrentFrame() == 0 && flips > 0)
                    {
                        finishFlipping = false;
                        retrieveNextFrame = false;
                        flips--;
                        headsGlowAlpha = 250;
                    }
                    break;

                case 1:
                    if (anim.getCurrentFrame() == 5 && flips > 0)
                    {
                        finishFlipping = false;
                        retrieveNextFrame = false;
                        flips--;
                        tailsGlowAlpha = 250;
                    }
                    break;
            }
        }

        public Image getCurrentFrame()
        {
            return currentFrame;
        }

        public Color getTailsGlow()
        {
            return tailsGlow;
        }

        public Color getHeadsGlow()
        {
            return headsGlow;
        }

        public Color getTailsFade()
        {
            return tailsFade;
        }

        public Color getHeadsFade()
        {
            return headsFade;
        }

        public string getHeads()
        {
            return results[0].ToString();
        }

        public string getTails()
        {
            return results[1].ToString();
        }

        public string getFlipsLeft()
        {
            return flips.ToString();
        }
      
        public int getNumberFlips()
        {
            return flips;
        }

    
    }
}
