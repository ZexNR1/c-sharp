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
    public partial class CaesarDecrypter : Form
    {
        public CaesarDecrypter()
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
        public bool verifyIsNumber()
        {
            bool numeric = true;
            var regex = new Regex(@"^-?[0-9]+$");
            numeric = regex.IsMatch(this.textBox2.Text);
            if (numeric)
                return true;
            return false;
        }
        public void decriptareCaesar()
        {
            this.textBox1.Text = this.textBox1.Text.TrimStart();
            this.textBox1.Text = this.textBox1.Text.TrimEnd();
            this.textBox2.Text = this.textBox2.Text.TrimStart();
            this.textBox2.Text = this.textBox2.Text.TrimEnd();
            if (this.textBox1.Text != "")
            {
                if (esteLitera(this.textBox1.Text) && this.checkBox1.Checked==true && verifyIsNumber())
                {
                    this.checkBox1.Enabled = false;
                    this.button1.Enabled = false;
                    this.textBox1.Text = this.textBox1.Text.ToUpper();
                    int cheie = Convert.ToInt32(this.textBox2.Text);
                    cheie = castCheie(cheie);
                    this.textBox1.ReadOnly = true;
                    this.textBox2.ReadOnly = true;
                    this.textBox2.Text = cheie.ToString();
                    string solutie = "";
                    for (int i = 0; i < this.textBox1.Text.Length; i++)
                    {
                        if (this.textBox1.Text[i] != ' ')
                        {
                            char c = this.textBox1.Text[i];
                            int ch = Convert.ToInt32(c);
                            ch = ch - 65;
                            ch = (ch - cheie) % 26;
                            ch = castCheie(ch);
                            ch = ch + 65;
                            solutie = solutie + Convert.ToChar(ch);
                        }
                    }
                    this.listBox1.Items.Add(solutie);
                }
                if (esteLitera(this.textBox1.Text) && this.checkBox1.Checked == false)
                {
                    this.checkBox1.Enabled = false;
                    this.button1.Enabled = false;
                    this.textBox1.Text = this.textBox1.Text.ToUpper();
                    this.textBox1.ReadOnly = true;
                    string solutie = "";
                    for(int j=0;j<26;j++)
                    {
                            solutie = "";
                            for (int i = 0; i < this.textBox1.Text.Length; i++)
                            {
                                if(this.textBox1.Text[i] != ' ')
                                {
                                    char c = this.textBox1.Text[i];
                                    int ch = Convert.ToInt32(c);
                                    ch = ch - 65;
                                    ch = (ch - j) % 26;
                                    ch = castCheie(ch);
                                    ch = ch + 65;
                                    solutie = solutie + Convert.ToChar(ch);
                                }
                                else
                                {
                                    solutie = solutie + ' ';
                                }
                            }
                            this.listBox1.Items.Add((solutie));
                     }
                }
                else if (!esteLitera(this.textBox1.Text) && verifyIsNumber() && this.checkBox1.Checked==true)
                {
                    MessageBox.Show("The text must contains only letters!");
                }
                else if (!esteLitera(this.textBox1.Text) && !verifyIsNumber() && this.checkBox1.Checked==true)
                {
                    MessageBox.Show("The text must contains only letters and the key must be a valid number!");
                }
                else if (esteLitera(this.textBox1.Text) && !verifyIsNumber() && this.checkBox1.Checked==true)
                {
                    MessageBox.Show("The key must be a valid number");
                }
            }
            else if (this.textBox1.Text == "" && this.textBox2.Text != "" && this.checkBox1.Checked==true)
            {
                MessageBox.Show("The text must contain a letter!");
            }
            else if(this.textBox1.Text == "" && this.checkBox1.Checked==false)
            {
                MessageBox.Show("The text must contain a letter!");
            }
            else if (this.textBox1.Text != "" && this.textBox2.Text == "" && this.checkBox1.Checked==true)
            {
                MessageBox.Show("The key must be a valid number!");
            }
            else if ((this.textBox1.Text == "") && (this.textBox2.Text == "") && (this.checkBox1.Checked==true))
            {
                MessageBox.Show("The text must contain one letter and the key must be a valid number!");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.checkBox1.Enabled = true;
            this.button1.Enabled = true;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox1.ReadOnly = false;
            this.checkBox1.Checked = false;
            this.listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decriptareCaesar();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
                this.textBox2.ReadOnly = false;
            if (this.checkBox1.Checked == false)
            {
                this.textBox2.Text = "";
                this.textBox2.ReadOnly = true;
            }
        }
    }
}
