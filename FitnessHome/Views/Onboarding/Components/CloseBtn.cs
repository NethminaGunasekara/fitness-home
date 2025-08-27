using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FitnessHome.Views.Onboarding.Components
{
    public partial class CloseBtn : UserControl
    {
        // Import user32.dll functions
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        // Constants for dragging the form
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public Form parentForm;

        public CloseBtn(Form parentForm)
        {
            InitializeComponent();

            // Set button properties
            close_btn.FlatStyle = FlatStyle.Flat;
            close_btn.BackColor = Color.Transparent;
            close_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 60, 60);
            close_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 60, 60);

            // Set button image
            close_btn.Image = new Bitmap(Properties.Resources.CloseBtn, new Size(22, 22));

            this.parentForm = parentForm;
        }

        private void ExitApplication(object sender, EventArgs e) => Application.Exit();

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(parentForm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}
