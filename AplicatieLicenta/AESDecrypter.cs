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
    public partial class AESDecrypter : Form
    {
        public AESDecrypter()
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
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.button1.Enabled = true;
            this.textBox1.ReadOnly = false;
            this.textBox2.ReadOnly = false;
        }
        public string DecriptareAES(string text, string key)
        {
            try
            {
                byte[] iv = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                byte[] keys = Encoding.UTF8.GetBytes(key);
                AesManaged aes = new AesManaged();
                aes.Key = keys;
                aes.IV = iv;
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
                byte[] inputBytes = Convert.FromBase64String(text);
                cs.Write(inputBytes, 0, inputBytes.Length);
                cs.FlushFinalBlock();
                byte[] decryptedText = ms.ToArray();
                return UTF8Encoding.UTF8.GetString(decryptedText,0,decryptedText.Length);
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
                if (this.textBox2.Text.Length == 16)
                {
                    string solutie = DecriptareAES(this.textBox1.Text, this.textBox2.Text);
                    if (solutie != null)
                        this.textBox3.Text = solutie;
                    else this.textBox3.Text = "Solution not Found!";
                    this.textBox1.ReadOnly = true;
                    this.textBox2.ReadOnly = true;
                    this.button1.Enabled = false;
                }
                else MessageBox.Show("The key must have 16 characters!");
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
