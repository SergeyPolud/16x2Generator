using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16x2Generator
{
    public partial class Form1 : Form
    {
        List<Control> matrix = new List<Control>();
        Translator translator = new Translator();
        List<Control> newMatrix = new List<Control>();

        int[,] flagArray = new int[8,5];
        private void Init()
        {
            
            foreach (Control control in panel1.Controls)
            {
                matrix.Add(control);
            }
            
        }
        public Form1()
        {
            InitializeComponent();
            Init();
            for (int i=0;i<40;i++)
            {
                matrix[i].Click += new EventHandler(Button_Click);
            }

        }

        
        private void Button_Click(object sender, EventArgs e)
        {
            var sorted = matrix.OrderBy(x => Convert.ToInt32(x.Name.Substring(6))); //
            newMatrix.AddRange(sorted);
            var button = sender as Button;
            string name = "button";
            for(int i=0;i<=40;i++)
            {
               if(button.Name == (name + i))
                {
                    newMatrix[i-1].BackColor = Color.Red;
                }
            }
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
           


        }
       
        private void Button41_Click(object sender, EventArgs e)
        {
            translator.SetFlags(newMatrix, flagArray);
            translator.SetBits(flagArray);

            for(int i=0;i<8;i++)
            {
               richTextBox1.AppendText(translator.bitArray[i]);
                richTextBox1.AppendText("\n");
            }
        }
    }
}
