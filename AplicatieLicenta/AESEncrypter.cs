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
    public partial class AESEncrypter : Form
    {
        public AESEncrypter()
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
        public void CriptareAES(string text,string key)
        {
            byte[] iv = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] keys=Encoding.UTF8.GetBytes(key);
            AesManaged aes = new AesManaged();
            aes.Key = keys;
            aes.IV = iv;
            MemoryStream ms=new MemoryStream();
            CryptoStream cs=new CryptoStream(ms, aes.CreateEncryptor(),CryptoStreamMode.Write);
            byte[] inputBytes=Encoding.UTF8.GetBytes(text);
            cs.Write(inputBytes,0,inputBytes.Length);
            cs.FlushFinalBlock();
            byte[] encryptedText=ms.ToArray();
            this.textBox3.Text=Convert.ToBase64String(encryptedText);
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
                    CriptareAES(this.textBox1.Text, this.textBox2.Text);
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

