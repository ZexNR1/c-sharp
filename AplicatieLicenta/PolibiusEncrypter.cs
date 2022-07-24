using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicatieLicenta
{
    public partial class PolibiusEncrypter : Form
    {
        string[,] PolibiusMatrix = new string[5, 5] 
        { 
          { "A","B","C","D","E" }, 
          { "F","G","H","IJ","K" },
          { "L","M","N","O","P" },
          { "Q","R","S","T","U" },
          { "V","W","X","Y","Z" }
        };
        public PolibiusEncrypter()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Encrypt f = new Encrypt();
            f.Show();
            f.Left = this.Left;
            f.Top = this.Top;
            f.Size = this.Size;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.button1.Enabled = true;
        }
        public bool esteLitera(string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return false;
            for (int i = 0; i < Text.Length; i++)
                if (!char.IsLetter(Text[i]) && Text[i] != ' ')
                    return false;
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text!="")
            {
                this.textBox1.Text=this.textBox1.Text.TrimStart();
                if(esteLitera(this.textBox1.Text)==true)
                {
                    this.textBox1.Text.ToUpper();
                    this.textBox1.Text = this.textBox1.Text.ToUpper();
                    this.textBox1.ReadOnly = true;
                    this.button1.Enabled = false;
                    for (int i= 0; i < this.textBox1.Text.Length; i++)
                    {
                        for(int j=0; j < 5; j++)
                        {
                            for(int k=0; k<5; k++)
                            {
                                string ch = this.textBox1.Text[i].ToString();
                                string chm = PolibiusMatrix[j, k];
                                if (ch==chm)
                                {
                                    this.textBox2.Text += (j+1).ToString() + (k+1).ToString();
                                }
                                else if(ch=="I" && chm=="IJ")
                                {
                                    this.textBox2.Text +="24";
                                }
                                else if (ch == "J" && chm=="IJ")
                                {
                                    this.textBox2.Text += "24";
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The text must contains only letters!");
                }
            }
            else if(this.textBox1.Text=="")
            {
                MessageBox.Show("The text must contain one letter!");
            }    
        }
    }
}
