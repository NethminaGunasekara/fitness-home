using AnimateDemo;
using System;
using System.Windows.Forms;

namespace fitness_home.Views.Dashboard
{
    public partial class MemberDashboard : Form
    {
        public MemberDashboard()
        {
            InitializeComponent();
        }

        private void Member_Load(object sender, EventArgs e)
        {
            // Form transition
            WinAPI.AnimateWindow(this.Handle, 400, WinAPI.BLEND);
        }
    }
}
