using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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

            var sorted = matrix.OrderBy(x => Convert.ToInt32(x.Name.Substring(6)));
            newMatrix.AddRange(sorted);
            var button = sender as Button;
            string name = "button";
            for(int i=0;i<=40;i++)
            {
               if(button.Name == (name + i))
                {
                    if (newMatrix[i - 1].BackColor != Color.Red)
                    {
                        newMatrix[i - 1].BackColor = Color.Red;
                    }
                    else
                    {
                        newMatrix[i - 1].BackColor = Color.White;
                    }
                }
            }
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Button button in panel1.Controls)
            {
                button.BackColor = Color.White;
            }
        }

        private void Button41_Click(object sender, EventArgs e)
        {
            string defaultName = "user_char";
            string SymbolName = textBox1.Text;
            richTextBox1.Clear();
            if (SymbolName == "")
            {
                SymbolName = defaultName;
            }
            richTextBox1.AppendText($"uint8_t {SymbolName}[8];\n");
           
            translator.SetFlags(newMatrix, flagArray);
            translator.SetBits(flagArray);

            for(int i=0;i<8;i++)
            {
               richTextBox1.AppendText($"{SymbolName}[{i}] = 0b{translator.bitArray[i]};");
               richTextBox1.AppendText("\n");
            }
            richTextBox1.Invalidate();
            for(int i=0;i<8;i++)
            {
                translator.bitArray[i] = "";
            }
            panel1.Invalidate(true);
        }

        private void Clear_Btn_Click(object sender, EventArgs e)
        {
            foreach (Button button in panel1.Controls)
            {
                button.BackColor = Color.White;
            }
        }
    }
}
