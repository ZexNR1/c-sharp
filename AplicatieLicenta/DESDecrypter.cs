using System;
using System.IO;
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
    public partial class DESDecrypter : Form
    {
        public DESDecrypter()
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
            this.textBox1.Text = "";
            this.textBox1.ReadOnly = false;
            this.textBox2.Text = "";
            this.textBox2.ReadOnly = false;
            this.textBox3.Text = "";
            this.button1.Enabled = true;
        }
        public string DecriptareDES(string text, string key)
        {
            try
            {
                byte[] keyByte = Encoding.UTF8.GetBytes(key);
                byte[] IV = { 0x05, 0x56, 0x78, 0x55, 0x86, 0x79, 0x77, 0x99 };
                byte[] textByte = Convert.FromBase64String(text);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(keyByte, IV), CryptoStreamMode.Write);
                cs.Write(textByte, 0, textByte.Length);
                cs.FlushFinalBlock();
                cs.Dispose();
                cs.Close();
                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch 
            {
                return null;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.textBox1.Text.TrimStart();
            this.textBox1.Text = this.textBox1.Text.TrimEnd();
            this.textBox2.Text = this.textBox2.Text.TrimStart();
            this.textBox2.Text = this.textBox2.Text.TrimEnd();
            if (this.textBox1.Text != "" && this.textBox2.Text != "")
            {
                if (this.textBox2.Text.Length == 8)
                {
                    string solutie = DecriptareDES(this.textBox1.Text, this.textBox2.Text);
                    if (solutie != null)
                        this.textBox3.Text = solutie;
                    else this.textBox3.Text = "Solution not Found!";
                    this.textBox1.ReadOnly = true;
                    this.textBox2.ReadOnly = true;
                    this.button1.Enabled = false;
                }
                else MessageBox.Show("The key must have 8 characters!");
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
                MessageBox.Show("The text and they Key must be a valid string!");
            }
        }
    }
}
