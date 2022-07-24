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
    public partial class AfinDecrypter : Form
    {
        public AfinDecrypter()
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
        public int cmmdc(int a, int b)
        {
            if (a == 0)
                return b;
            while(a!=b)
            {
                if(a>b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            return a;
        }
        public int inversM26(int a)
        {
            if (a == 1)
                return 1;
            else if (a == 3)
                return 9;
            else if (a == 5)
                return 21;
            else if (a == 7)
                return 15;
            else if (a == 9)
                return 3;
            else if (a == 11)
                return 19;
            else if (a == 15)
                return 7;
            else if (a == 17)
                return 23;
            else if (a == 17)
                return 23;
            else if (a == 19)
                return 11;
            else if (a == 23)
                return 17;
            else if (a == 25)
                return 25;
            return 0;
        }
        public void decriptareAfin()
        {
            this.textBox1.Text = this.textBox1.Text.TrimStart();
            this.textBox1.Text = this.textBox1.Text.TrimEnd();
            this.textBox2.Text = this.textBox2.Text.TrimStart();
            this.textBox2.Text = this.textBox2.Text.TrimEnd();
            this.textBox3.Text = this.textBox3.Text.TrimStart();
            this.textBox3.Text = this.textBox3.Text.TrimEnd();
            if (this.textBox1.Text != "")
            {
                if (esteLitera(this.textBox1.Text) && this.checkBox1.Checked == true && verifyIsNumber(this.textBox2.Text) && verifyIsNumber(this.textBox3.Text))
                {
                    int cheie1 = Convert.ToInt32(this.textBox2.Text);
                    cheie1 = castCheie(cheie1);
                    int cheie2 = Convert.ToInt32(this.textBox3.Text);
                    cheie2 = castCheie(cheie2);
                    if (cmmdc(cheie1, 26) == 1)
                    {
                        this.textBox2.Text = cheie1.ToString();
                        cheie1 = inversM26(cheie1);
                        this.checkBox1.Enabled = false;
                        this.button1.Enabled = false;
                        this.textBox1.Text = this.textBox1.Text.ToUpper();
                        this.textBox1.ReadOnly = true;
                        this.textBox2.ReadOnly = true;
                        this.textBox3.ReadOnly = true;
                        this.textBox3.Text = cheie2.ToString();
                        string solutie = "";
                        for (int i = 0; i < this.textBox1.Text.Length; i++)
                        {
                            if (this.textBox1.Text[i] != ' ')
                            {
                                char c = this.textBox1.Text[i];
                                int ch = Convert.ToInt32(c);
                                ch = ch - 65;
                                ch = (cheie1 * (ch - cheie2));
                                int ch2=(castCheie(ch))%26;
                                ch2 = ch2 + 65;
                                solutie = solutie + Convert.ToChar(ch2);
                            }
                            else
                            {
                                solutie = solutie + ' ';
                            }
                        }
                        this.listBox1.Items.Add(solutie);
                    }
                    else if (cmmdc(cheie1, 26) != 1)
                    {
                        MessageBox.Show("Inverse of " + cheie1 + " doesn't exit in modulo 26!");
                    }
                }
                if (esteLitera(this.textBox1.Text) && this.checkBox1.Checked == false)
                {
                    this.checkBox1.Enabled = false;
                    this.button1.Enabled = false;
                    this.textBox1.Text = this.textBox1.Text.ToUpper();
                    this.textBox1.ReadOnly = true;
                    string solutie = "";
                    for (int j = 0; j < 26; j++)
                    {
                        for (int k = 0; k < 26; k++)
                        {
                            solutie = "";
                            if (cmmdc(j, 26) == 1)
                            {
                                int j1 = inversM26(j);
                                for (int i = 0; i < this.textBox1.Text.Length; i++)
                                {
                                    if (this.textBox1.Text[i] != ' ')
                                    {
                                        char c = this.textBox1.Text[i];
                                        int ch = Convert.ToInt32(c);
                                        ch = ch - 65;
                                        ch = (j1 * (ch - k));
                                        int ch2 = (castCheie(ch)) % 26;
                                        ch2 = ch2 + 65;
                                        solutie = solutie + Convert.ToChar(ch2);
                                    }
                                    else
                                    {
                                        solutie = solutie + ' ';
                                    }
                                }
                                this.listBox1.Items.Add(solutie);
                            }
                        }
                    }
                }
                else if (!esteLitera(this.textBox1.Text) && verifyIsNumber(this.textBox2.Text) && verifyIsNumber(this.textBox3.Text) && this.checkBox1.Checked == true)
                {
                    MessageBox.Show("The text must contains only letters!");
                }
                else if (!esteLitera(this.textBox1.Text) && !verifyIsNumber(this.textBox2.Text) && !verifyIsNumber(this.textBox3.Text) && this.checkBox1.Checked == true)
                {
                    MessageBox.Show("The text must contains only letters and the key 1 and key 2 must be a valid numbers!");
                }
                else if (esteLitera(this.textBox1.Text) && !verifyIsNumber(this.textBox2.Text) && verifyIsNumber(this.textBox3.Text) && this.checkBox1.Checked == true)
                {
                    MessageBox.Show("The key 1 must be a valid number!");
                }
                else if (esteLitera(this.textBox1.Text) && verifyIsNumber(this.textBox2.Text) && !verifyIsNumber(this.textBox3.Text) && this.checkBox1.Checked == true)
                {
                    MessageBox.Show("The key 2 must be a valid number!");
                }
                else if (!esteLitera(this.textBox1.Text) && !verifyIsNumber(this.textBox2.Text) && verifyIsNumber(this.textBox3.Text) && this.checkBox1.Checked == true)
                {
                    MessageBox.Show("The text must contains only letters and the key 1 must be a valid number!");
                }
                else if (!esteLitera(this.textBox1.Text) && verifyIsNumber(this.textBox2.Text) && !verifyIsNumber(this.textBox3.Text) && this.checkBox1.Checked == true)
                {
                    MessageBox.Show("The text must contains only letters and the key 2 must be a valid number!");
                }
                else if (esteLitera(this.textBox1.Text) && !verifyIsNumber(this.textBox2.Text) && !verifyIsNumber(this.textBox3.Text) && this.checkBox1.Checked == true)
                {
                    MessageBox.Show("The key 1 and key 2 must be a valid numbers!");
                }
            }
            else if (this.textBox1.Text == "" && this.textBox2.Text != "" && this.textBox3.Text != "" && this.checkBox1.Checked == true)
            {
                MessageBox.Show("The text must contain a letter!");
            }
            else if (this.textBox1.Text == "" && this.checkBox1.Checked == false)
            {
                MessageBox.Show("The text must contain a letter!");
            }
            else if (this.textBox1.Text != "" && this.textBox2.Text == "" && this.textBox3.Text != "" && this.checkBox1.Checked == true)
            {
                MessageBox.Show("The key 1 must be a valid number!");
            }
            else if (this.textBox1.Text != "" && this.textBox2.Text != "" && this.textBox3.Text == "" && this.checkBox1.Checked == true)
            {
                MessageBox.Show("The key 2 must be a valid number!");
            }
            else if (this.textBox1.Text != "" && this.textBox2.Text != "" && this.textBox3.Text == "" && this.checkBox1.Checked == true)
            {
                MessageBox.Show("The key 2 must be a valid number!");
            }
            else if (this.textBox1.Text == "" && this.textBox2.Text == "" && this.textBox3.Text != "" && this.checkBox1.Checked == true)
            {
                MessageBox.Show("The text must contain a letter and the key 1 must be a valid number!");
            }
            else if (this.textBox1.Text == "" && this.textBox2.Text != "" && this.textBox3.Text == "" && this.checkBox1.Checked == true)
            {
                MessageBox.Show("The text must contain a letter and the key 2 must be a valid number!");
            }
            else if ((this.textBox1.Text == "") && (this.textBox2.Text == "") && (this.checkBox1.Checked == true))
            {
                MessageBox.Show("The text must contain one letter and the key 1 and key 2 must be a valid numbers!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            decriptareAfin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.checkBox1.Enabled = true;
            this.button1.Enabled = true;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox1.ReadOnly = false;
            this.checkBox1.Checked = false;
            this.listBox1.Items.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                this.textBox2.ReadOnly = false;
                this.textBox3.ReadOnly = false;
            }
            if (this.checkBox1.Checked == false)
            {
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox2.ReadOnly = true;
                this.textBox3.ReadOnly = true;
            }
        }
    }
}
