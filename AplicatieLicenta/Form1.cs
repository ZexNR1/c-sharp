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
    public partial class Form1 : Form
    {
        public static int optiune = -1;
        public static string optiuneStr = "";
        public Form1()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0  || this.comboBox1.SelectedIndex == 1 || this.comboBox1.SelectedIndex == 2 || this.comboBox1.SelectedIndex == 3 || this.comboBox1.SelectedIndex == 4 || this.comboBox1.SelectedIndex == 5 || this.comboBox1.SelectedIndex == 6) 
            {
                optiuneStr = "";
                this.Hide();
                optiuneStr = this.comboBox1.Text;
                Encrypt encrypt = new Encrypt();
                encrypt.Show();
                optiune = this.comboBox1.SelectedIndex;
                encrypt.Left = this.Left;
                encrypt.Top = this.Top;
                encrypt.Size = this.Size;
            }
            else
            {
                MessageBox.Show("Please select a Method!");
            }
        }
    }
}
