using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using fitness_home.Views.Onboarding;


namespace fitness_home
{
    internal static class Program
    {
        public static Register EntryPoint;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EntryPoint = new Register();
            Application.Run(EntryPoint);
        }
    }
}
