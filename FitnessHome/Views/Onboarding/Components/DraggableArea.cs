using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessHome.Views.Onboarding.Components
{
    public partial class DraggableArea : UserControl
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

        public DraggableArea(Form parentForm)
        {
            InitializeComponent();

            this.parentForm = parentForm;
        }

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
