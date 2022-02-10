using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//Напишите приложение  для  поиска  заданного  файла  на  диске.  Добавьте  код, использующий 
//класс  FileStream  и  позволяющий  просматривать  файл  в  текстовом  окне.  В  заключение 
//добавьте возможность сжатия найденного файла. 

namespace Task_3
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
