using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetDrivers();
        }

        void GetDrivers()
        {
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            foreach (var item in driveInfo)
            {
                if (item.DriveType != DriveType.CDRom)
                {
                    checkedListBox1.Items.Add(string.Format(item.Name));
                }
            }
        }

        string file;

        bool SearchFile(string directory, string fileName)
        {
            DirectoryInfo dir = new DirectoryInfo(directory);

            if (!dir.Exists)
            {
                return false;
            }

            FileInfo[] fileInfo = null;
            try
            {
                fileInfo = dir.GetFiles(fileName);
            }
            catch (Exception)
            {
                return false;
            }

            if (fileInfo.Length == 0)
            {
                DirectoryInfo[] dirInfo = dir.GetDirectories();
                if (dirInfo.Length == 0)
                {
                    return false;
                }
                foreach (var item in dirInfo)
                {
                    if (item.Attributes.Equals(FileAttributes.System | FileAttributes.Hidden | FileAttributes.Directory))
                    {
                        continue;
                    }
                    if (SearchFile(item.FullName, fileName))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                file = fileInfo[0].FullName;
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e) // Search
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                    if (SearchFile(checkedListBox1.Items[i].ToString(), textBox1.Text))
                    {
                        label1.Text = file;
                    }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader reader = File.OpenText(file);
            textBox2.Text = reader.ReadToEnd();
            reader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var fileStream = new FileStream(saveFileDialog1.FileName, FileMode.Create))
                using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(file, Path.GetFileName(file));
                    
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (ZipArchive archive = ZipFile.OpenRead(openFileDialog1.FileName))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        entry.ExtractToFile(Path.Combine(Path.GetDirectoryName(openFileDialog1.FileName), entry.FullName));
                    }
                }

            }
        }
    }
    
}
