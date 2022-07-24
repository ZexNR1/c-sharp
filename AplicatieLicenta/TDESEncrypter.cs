using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace AplicatieLicenta
{
    public partial class TDESEncrypter : Form
    {
        public TDESEncrypter()
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
        public void Criptare3DES(string text,string key)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tdes.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    this.textBox3.Text = Convert.ToBase64String(result,0,result.Length);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text.TrimStart();
            this.textBox1.Text = this.textBox1.Text.TrimEnd();
            this.textBox2.Text = this.textBox2.Text.TrimStart();
            this.textBox2.Text = this.textBox2.Text.TrimEnd();
            if (this.textBox1.Text != "" && this.textBox2.Text != "")
            {
                this.textBox1.ReadOnly = true;
                this.textBox2.ReadOnly = true;
                this.button1.Enabled = false;
                Criptare3DES(this.textBox1.Text, this.textBox2.Text);
            }
            else if (this.textBox1.Text == "" && this.textBox2.Text != "")
            {
                MessageBox.Show("The text must be a valid string!");
            }
            else if (this.textBox1.Text != "" && this.textBox2.Text == "")
            {
                MessageBox.Show("The key must be a valid string!");
            }
            else if (this.textBox1.Text == "" && this.textBox2.Text == "")
            {
                MessageBox.Show("The text and the Key must be a valid string!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.button1.Enabled = true;
            this.textBox1.ReadOnly = false;
            this.textBox2.ReadOnly = false;
        }
    }
}
