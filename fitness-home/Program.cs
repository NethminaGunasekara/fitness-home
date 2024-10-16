using fitness_home.Views.Dashboard;
using fitness_home.Views.Onboarding;
using System;
using System.Windows.Forms;


namespace fitness_home
{
    internal static class Program
    {
        public static Splash EntryPoint;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EntryPoint = new Splash();
            Application.Run(EntryPoint);
        }
    }
}
