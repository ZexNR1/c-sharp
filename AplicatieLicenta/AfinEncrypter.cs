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
    public partial class AfinEncrypter : Form
    {
        public AfinEncrypter()
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
            this.textBox1.ReadOnly = false;
            this.textBox2.ReadOnly = false;
            this.textBox3.ReadOnly = false;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
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
        public int castCheie(int cheie)
        {
            if (cheie == 26)
                cheie = 0;
            if (cheie == -26)
                cheie = 0;
            else if (cheie < 0)
            {
                cheie = -cheie;
                cheie = 26 - (cheie - (26 * (cheie / 26)));
            }
            if (cheie > 26)
            {
                cheie = cheie - (26 * (cheie / 26));
            }
            return cheie;
        }
        public bool verifyIsNumber(string input)
        {
            bool numeric = true;
            var regex = new Regex(@"^-?[0-9]+$");
            numeric = regex.IsMatch(input);
            if (numeric)
                return true;
            return false;
        }
        public void criptareAfin()
        {
            this.textBox1.Text = this.textBox1.Text.TrimStart();
            this.textBox1.Text = this.textBox1.Text.TrimEnd();
            this.textBox2.Text = this.textBox2.Text.TrimStart();
            this.textBox2.Text = this.textBox2.Text.TrimEnd();
            this.textBox3.Text = this.textBox3.Text.TrimStart();
            this.textBox3.Text = this.textBox3.Text.TrimEnd();
            this.textBox4.Text = "";
            if (this.textBox1.Text != "" && this.textBox2.Text != "" && this.textBox3.Text!="")
            {
                if (esteLitera(this.textBox1.Text) && verifyIsNumber(this.textBox2.Text) && verifyIsNumber(this.textBox3.Text))
                {
                    this.button1.Enabled = false;
                    this.textBox1.Text = this.textBox1.Text.ToUpper();
                    int cheie1 = Convert.ToInt32(this.textBox2.Text);
                    cheie1 = castCheie(cheie1);
                    int cheie2 = Convert.ToInt32(this.textBox3.Text);
                    cheie2 = castCheie(cheie2);
                    this.textBox1.ReadOnly = true;
                    this.textBox2.ReadOnly = true;
                    this.textBox3.ReadOnly = true;
                    for (int i = 0; i < this.textBox1.Text.Length; i++)
                    {
                        if (this.textBox1.Text[i] != ' ')
                        {
                            char c = this.textBox1.Text[i];
                            int ch = Convert.ToInt32(c);
                            ch = ch - 65;
                            ch = (ch*cheie1+cheie2) % 26;
                            ch = ch + 65;
                            this.textBox4.Text = this.textBox4.Text + Convert.ToChar(ch);
                        }
                    }
                    this.textBox2.Text = cheie1.ToString();
                    this.textBox3.Text = cheie2.ToString();
                }
                else if (!esteLitera(this.textBox1.Text) && verifyIsNumber(this.textBox2.Text) && verifyIsNumber(this.textBox3.Text))
                {
                    MessageBox.Show("The text must contains only letters!");
                }
                else if (!esteLitera(this.textBox1.Text) && !verifyIsNumber(this.textBox2.Text) && verifyIsNumber(this.textBox3.Text))
                {
                    MessageBox.Show("The text must contains only letters and the key 1 must be a valid number!");
                }
                else if (!esteLitera(this.textBox1.Text) && verifyIsNumber(this.textBox2.Text) && !verifyIsNumber(this.textBox3.Text))
                {
                    MessageBox.Show("The text must contains only letters and the key 2 must be a valid number!");
                }
                else if (!esteLitera(this.textBox1.Text) && !verifyIsNumber(this.textBox2.Text) && !verifyIsNumber(this.textBox3.Text))
                {
                    MessageBox.Show("The text must contains only letters and the key 1 and key 2 must be a valid numbers!");
                }
                else if (esteLitera(this.textBox1.Text) && !verifyIsNumber(this.textBox2.Text) && !verifyIsNumber(this.textBox3.Text))
                {
                    MessageBox.Show("The key 1 and key 2  must be a valid numbers");
                }
                else if (esteLitera(this.textBox1.Text) && !verifyIsNumber(this.textBox2.Text) && verifyIsNumber(this.textBox3.Text))
                {
                    MessageBox.Show("The key 1 must be a valid number");
                }
                else if (esteLitera(this.textBox1.Text) && verifyIsNumber(this.textBox2.Text) && !verifyIsNumber(this.textBox3.Text))
                {
                    MessageBox.Show("The key 2 must be a valid number");
                }
            }
            else if (this.textBox1.Text == "" && this.textBox2.Text != "" && this.textBox3.Text!="")
            {
                MessageBox.Show("The text must contain a letter!");
            }
            else if (this.textBox1.Text != "" && this.textBox2.Text == "" && this.textBox3.Text!="")
            {
                MessageBox.Show("The key 1 must be a valid number!");
            }
            else if (this.textBox1.Text != "" && this.textBox2.Text != "" && this.textBox3.Text == "")
            {
                MessageBox.Show("The key 2 must be a valid number!");
            }
            else if (this.textBox1.Text != "" && this.textBox2.Text == "" && this.textBox3.Text == "")
            {
                MessageBox.Show("The key 1 and key 2 must be a valid numbers!");
            }
            else if (this.textBox1.Text == "" && this.textBox2.Text == "" && this.textBox3.Text != "")
            {
                MessageBox.Show("The text must contain a letter and the key 1 must be a valid number!");
            }
            else if (this.textBox1.Text == "" && this.textBox2.Text != "" && this.textBox3.Text == "")
            {
                MessageBox.Show("The text must contain a letter and the key 2 must be a valid number!");
            }
            else if (this.textBox1.Text == "" && this.textBox2.Text == "" && this.textBox3.Text=="")
            {
                MessageBox.Show("The text must contain one letter and the key 1 and key 2 must be a valid numbers!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            criptareAfin();
        }
    }
}
