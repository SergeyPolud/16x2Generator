using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _16x2Generator
{
    class Translator
    {


        public string[] bitArray = new string[8];

        public void SetBits(int[,] flagArray)
        {
            for(int i=0;i<8;i++)
            {
                for(int j =0;j<5;j++)
                {
                    bitArray[i] += flagArray[i, j].ToString();
                }
            }
        }

        
        public void SetFlags(List<Control> newMatrix, int[,] flagArray)
        {
            int j = 0;

            for (int i = 0; i < 40; i++)
            {
                if (newMatrix[i].BackColor == Color.Red)
                {
                    if (i % 5 == 0 && i > 0)
                    {
                        j++;
                        flagArray[j, i % 5] = 1;
                    }
                    else
                    {
                        flagArray[j, i % 5] = 1;
                    }
                }
                else
                {
                    if (i % 5 == 0 && i > 0)
                    {
                        j++;
                        flagArray[j, i % 5] = 0;
                    }
                    else
                    {
                        flagArray[j, i % 5] = 0;
                    }
                }
            }
        }
    }
}
