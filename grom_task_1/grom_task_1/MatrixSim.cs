using System;
using System.Drawing;

public class MatrixSim
{
    private int width;
    private int height;

    private string characterPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789\\?.,!@#$%^&*()_+=-~`;:|[{]}\"/><";
    private String[] columns;
    private int[] colunmHeight;

    private Random seed = new Random();
    public MatrixSim(int w, int h)
	{
        width = w;
        height = h;
        columns = new String[width / 10];
        colunmHeight = new int[width/10];


        for (int i=0; i<columns.Length; i++)
        {
            colunmHeight[i] = seed.Next(1, height/10);

            columns[i] = generateString( colunmHeight[i]);
        }

	}

     public void  drawFrame(Graphics g)
    {
         g.Clear(Color.Black);
         for (int i=0; i<columns.Length; i++)
         {
             g.DrawString(columns[i], new Font("Georgia", 10), new SolidBrush(Color.Green),
                        new Point(i*10, 0 )   );
             
         }
    }

    public void onTick()
     {
        for (int i=0; i<columns.Length; i++)
        {
            columns[i] = generateString( colunmHeight[i]);
        }
     }

    private string generateString(int length)
    {
        string output="";
        Array charArray = characterPool.ToCharArray();

        for (int i = 0; i < length; i++ )
        {
            output += charArray.GetValue(seed.Next(charArray.Length) );
            output += "\n";

        }
            return output;
    }
}
