using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace AplicatieLicenta
{
    public partial class PolibiusDecrypter : Form
    {
        string[,] PolibiusMatrix = new string[5, 5]
        {
          { "A","B","C","D","E" },
          { "F","G","H","IJ","K" },
          { "L","M","N","O","P" },
          { "Q","R","S","T","U" },
          { "V","W","X","Y","Z" }
        };
        public PolibiusDecrypter()
        {
            InitializeComponent();
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

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public bool verifyIsNumber(string input)
        {
            bool numeric = true;
            var regex = new Regex(@"^[1-5]+$");
            numeric = regex.IsMatch(input);
            if (numeric)
                return true;
            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox1.ReadOnly = false;
            this.button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text.TrimStart();
            this.textBox1.Text = this.textBox1.Text.TrimEnd();
            string fSpatii = this.textBox1.Text.Replace(" ", "");
            if (fSpatii != "")
            {
                if (verifyIsNumber(fSpatii) && fSpatii.Length%2==0)
                {
                    this.textBox1.Text = fSpatii;
                    this.textBox1.ReadOnly = true;
                    this.button1.Enabled = false;
                    string solutie = "";
                    for(int i=0;i<fSpatii.Length-1;i=i+2)
                    {
                        int j = Convert.ToInt32(fSpatii[i]);
                        j = j - 48;
                        int k = Convert.ToInt32(fSpatii[i + 1]);
                        k = k - 48;
                        if (j >= 1 && k >= 1 && j <= 5 && k <= 5)
                        {
                            solutie = solutie + PolibiusMatrix[j - 1, k - 1];
                        }
                    }
                    this.textBox2.Text= solutie;
                }
                else if(verifyIsNumber(fSpatii) == true && fSpatii.Length %2==1)
                {
                    MessageBox.Show("The text must have an even length!");
                }
                else
                {
                    MessageBox.Show("The text must contains only numbers in interval [0,5] and even length!");
                }
            }
            else if (fSpatii == "")
            {
                MessageBox.Show("The text must contain minimum two numbers in interval [0,5]!");
            }
        }
    }
}
