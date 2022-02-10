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

namespace Addition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                string name = "Folder_" + string.Format("{0:d4}", i);
                if (!Directory.Exists(name))
                {
                    try 
                    {
                        Directory.CreateDirectory(name);
                        richTextBox1.AppendText($"Каталог {name} создан.\n");
                    }
                    catch (Exception ex) 
                    {
                        richTextBox1.AppendText(ex.Message + "\n");
                    }
                   
                }
                else
                {
                    richTextBox1.AppendText($"Каталог {name} уже существует\n");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                string name = "Folder_" + string.Format("{0:d4}", i);
                if (Directory.Exists(name))
                {
                    try
                    {
                        Directory.Delete(name);
                        richTextBox1.AppendText($"Каталог {name} удален.\n");
                    }
                    catch (Exception ex)
                    {
                        richTextBox1.AppendText(ex.Message + "\n");
                    }

                }
                else
                {
                    richTextBox1.AppendText($"Каталог {name} не существует\n");
                }
            }
        }
    }
}
