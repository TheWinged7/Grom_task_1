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

    public Image getNextImage()
    {
        currentFrame++;
        if (currentFrame>=11)
        {
            currentFrame = 0;
        }
        return frames[currentFrame]; //replace later with actual return
    }
}
