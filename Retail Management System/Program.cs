using System;
using System.Windows.Forms;

namespace Retail_Management_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMainMenu());
            //Application.Run(new Form1());
            //Application.Run(new FormFinance());

        }
    }
}
