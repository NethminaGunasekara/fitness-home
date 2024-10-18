using System;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace fitness_home.Views.Dashboard.Member.Components.Views
{
    public partial class ContactUsView : UserControl
    {
        // Code required to create rounded rectangle panels
        // Source: https://stackoverflow.com/questions/38632035/winforms-smooth-the-rounded-edges-for-panel
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        // Applies rounded corners around selected panels
        private void ApplyRoundedCorners()
        {
            // Initialize a list of pannels to apply rounded corners
            List<Panel> panelsToDraw = new List<Panel> { panel_send_message, panel_provide_feedback, panel_message };

            SuspendLayout();

            // Apply rounded corners to all panels of the list above
            panelsToDraw.ForEach((Panel panel) =>
            {
                panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 12, 12));
            });

            ResumeLayout();
        }

        public ContactUsView()
        {
            InitializeComponent();
        }

        // ** Event: When the control is first loaded
        private void ContactUsView_Load(object sender, EventArgs e)
        {
            ApplyRoundedCorners();
        }

        // ** Event: When the control is being resized
        private void ContactUsView_Resize(object sender, EventArgs e)
        {
            ApplyRoundedCorners();
        }

        private void tableLayoutPanel_content_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_email_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel_message_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
