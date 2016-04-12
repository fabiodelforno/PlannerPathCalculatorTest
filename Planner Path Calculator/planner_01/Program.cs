using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planner_Path_Calculator
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists("config.txt"))
            {
                Console.WriteLine("file esistente");
                MessageBox.Show("file config.txt esistente");
                Application.Run(new Start());
            }else
            {
                Application.Run(new LoginDB());
            }
            
            
        }
    }
}
