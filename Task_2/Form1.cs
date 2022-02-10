using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("file.txt", false, System.Text.Encoding.Default))
            {
                sw.Write(richTextBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("file.txt", System.Text.Encoding.Default))
            {
                richTextBox1.Text = sr.ReadToEnd();
            }
        }
    }
}
