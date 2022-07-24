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
    public partial class RSAEncrypter : Form
    {
        public RSAEncrypter()
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
        public bool verifyIsNumber(string text)
        {
            bool numeric = true;
            var regex = new Regex(@"^[0-9]+$");
            numeric = regex.IsMatch(text);
            if (numeric)
                return true;
            return false;
        }
        public double cmmdc(double a, double b)
        {
            while (a != b)
            {
                if (a > b)
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
        public double castN(double cheie,double n)
        {
            if (cheie == n)
                cheie = 0;
            if (cheie == -n)
                cheie = 0;
            else if (cheie < 0)
            {
                cheie = -cheie;
                cheie = n - (cheie - (n * (cheie / n)));
            }
            if (cheie > n)
            {
                cheie = cheie - (n * (cheie / n));
            }
            return cheie;
        }
        public bool isPrime(double n)
        {
            if (n == 2)
                return true;
            int c = 0;
            for (double i=2;i<n;i++)
            {
                if (n % i == 0)
                    c++;
            }
            if (c == 0)
                return true;
            else return false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void criptareRSA()
        {
            this.textBox1.Text = this.textBox1.Text.TrimStart();
            this.textBox1.Text = this.textBox1.Text.TrimEnd();
            this.textBox2.Text = this.textBox2.Text.TrimStart();
            this.textBox2.Text = this.textBox2.Text.TrimEnd();
            this.textBox3.Text = this.textBox3.Text.TrimStart();
            this.textBox3.Text = this.textBox3.Text.TrimEnd();
            this.textBox4.Text = this.textBox4.Text.TrimStart();
            this.textBox4.Text = this.textBox4.Text.TrimEnd();
            if (this.textBox1.Text != "" && this.textBox2.Text != "" && this.textBox3.Text != "" && this.textBox4.Text !="")
            {
                if (verifyIsNumber(this.textBox1.Text) && verifyIsNumber(this.textBox2.Text) && verifyIsNumber(this.textBox2.Text) && verifyIsNumber(this.textBox3.Text) && verifyIsNumber(this.textBox4.Text))
                {
                    double p = Convert.ToDouble(this.textBox1.Text);
                    double q = Convert.ToDouble(this.textBox2.Text);
                    double n = p * q;
                    double phi = (p - 1) * (q - 1);
                    double m = Convert.ToDouble(this.textBox3.Text);
                    double e = Convert.ToDouble(this.textBox4.Text);
                    double cmmdc1 = cmmdc(e, phi);
                    if (cmmdc1 == 1 && e>1 && e<phi)
                    {
                        if (isPrime(p) && isPrime(q))
                        {
                            this.textBox1.ReadOnly = true;
                            this.textBox2.ReadOnly = true;
                            this.textBox3.ReadOnly = true;
                            this.textBox4.ReadOnly = true;
                            this.button1.Enabled = false;
                            double c = Math.Pow(m, e) % n;
                            double c1 = castN(c, n);
                            this.textBox5.Text = c1.ToString();
                        }
                        else
                        {
                            MessageBox.Show("p and q must be a prime numbers");
                        }
                    }
                    else
                    {
                        MessageBox.Show("key and phi must be prime number between them and key must be > 1 and <phi");
                    }
                }
                else
                {
                    MessageBox.Show("Each of p,q,number and key must be valid integers!");
                }
            }
            else
            {
                MessageBox.Show("Each box must be completed!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            criptareRSA();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly=false;
            this.textBox2.ReadOnly = false;
            this.textBox3.ReadOnly = false;
            this.textBox4.ReadOnly = false;
            this.button1.Enabled = true;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
        }
    }
}
