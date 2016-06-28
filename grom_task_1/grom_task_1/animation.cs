using System;
using System.Drawing;

public class animation
{
    private Image[] frames;
    private int currentFrame;
    public animation(Image [] f)
	{
        frames = f;
        currentFrame = 0;
	}


  public int getCurrentFrame ()
    { return currentFrame; }

    public Image getNextImage()
    {
        currentFrame++;
        if (currentFrame>=11)
        {
            currentFrame = 0;
        }
        return frames[currentFrame]; 
    }
}
