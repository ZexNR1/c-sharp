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
    public partial class Encrypt : Form
    {
        public Encrypt()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f=new Form1();
            f.Show();
            f.Left = this.Left;
            f.Top = this.Top;
            f.Size = this.Size;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Form1.optiune==0)
            {
                this.Hide();
                CaesarEncrypter f2 = new CaesarEncrypter();
                f2.Show();
                f2.Left = this.Left;
                f2.Top = this.Top;
                f2.Size = this.Size;
            }
            if(Form1.optiune==1)
            {
                this.Hide();
                AfinEncrypter f3 = new AfinEncrypter();
                f3.Show();
                f3.Left = this.Left;
                f3.Top = this.Top;
                f3.Size = this.Size;

            }
            if(Form1.optiune==2)
            {
                this.Hide();
                PolibiusEncrypter f4 = new PolibiusEncrypter();
                f4.Show();
                f4.Left = this.Left;
                f4.Top = this.Top;
                f4.Size = this.Size;
            }
            if (Form1.optiune == 3)
            {
                this.Hide();
                RSAEncrypter f5 = new RSAEncrypter();
                f5.Show();
                f5.Left = this.Left;
                f5.Top = this.Top;
                f5.Size = this.Size;
            }
            if (Form1.optiune == 4)
            {
                this.Hide();
                DESEncrypter f6 = new DESEncrypter();
                f6.Show();
                f6.Left = this.Left;
                f6.Top = this.Top;
                f6.Size = this.Size;
            }
            if(Form1.optiune==5)
            {
                this.Hide();
                TDESEncrypter f7 = new TDESEncrypter();
                f7.Show();
                f7.Left = this.Left;
                f7.Top = this.Top;
                f7.Size = this.Size;
            }
            if (Form1.optiune == 6)
            {
                this.Hide();
                AESEncrypter f8 = new AESEncrypter();
                f8.Show();
                f8.Left = this.Left;
                f8.Top = this.Top;
                f8.Size = this.Size;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Form1.optiune==0)
            {
                this.Hide();
                CaesarDecrypter f2 = new CaesarDecrypter();
                f2.Show();
                f2.Left = this.Left;
                f2.Top = this.Top;
                f2.Size = this.Size;
            }
            if(Form1.optiune==1)
            {
                this.Hide();
                AfinDecrypter f3 = new AfinDecrypter();
                f3.Show();
                f3.Left = this.Left;
                f3.Top = this.Top;
                f3.Size = this.Size;
            }
            if(Form1.optiune==2)
            {
                this.Hide();
                PolibiusDecrypter f4 = new PolibiusDecrypter();
                f4.Show();
                f4.Left = this.Left;
                f4.Top = this.Top;
                f4.Size = this.Size;
            }
            if (Form1.optiune == 3)
            {
                this.Hide();
                RSADecrypter f5 = new RSADecrypter();
                f5.Show();
                f5.Left = this.Left;
                f5.Top = this.Top;
                f5.Size = this.Size;
            }
            if (Form1.optiune == 4)
            {
                this.Hide();
                DESDecrypter f6 = new DESDecrypter();
                f6.Show();
                f6.Left = this.Left;
                f6.Top = this.Top;
                f6.Size = this.Size;
            }
            if (Form1.optiune == 5)
            {
                this.Hide();
                TDESDecrypter f7 = new TDESDecrypter();
                f7.Show();
                f7.Left = this.Left;
                f7.Top = this.Top;
                f7.Size = this.Size;
            }
            if (Form1.optiune == 6)
            {
                this.Hide();
                AESDecrypter f8 = new AESDecrypter();
                f8.Show();
                f8.Left = this.Left;
                f8.Top = this.Top;
                f8.Size = this.Size;
            }
        }
    }
}
