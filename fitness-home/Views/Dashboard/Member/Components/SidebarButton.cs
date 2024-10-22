using fitness_home.Properties;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace fitness_home.Views.Dashboard.Member.Components
{
    public partial class SidebarButton : UserControl
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

        private bool _ActiveButton;
        public Action BtnClick;

        private readonly Bitmap BtnIconLight;
        private readonly Bitmap BtnIconDark;
        private readonly string BtnText;

        public bool ActiveButton
        {
            get { return _ActiveButton; }
        
            set
            {
                // When the button's active status has changed
                _ActiveButton = value; // Assign the new value to the private member

                // Change the background color, foreground color, and the icon
                if (_ActiveButton)
                {
                    // Set the background color #A1D200
                    panel_button.BackColor = Color.FromArgb(161, 210, 0);

                    // Set the text color black
                    label_btn_text.ForeColor = Color.Black;

                    // Set the dark icon
                    pictureBox_icon.BackgroundImage = BtnIconDark;

                    return; // Exit the method
                }

                // Set the background color #000000
                panel_button.BackColor = Color.Black;

                // Set the text color black
                label_btn_text.ForeColor = Color.White;

                // Set the dark icon
                pictureBox_icon.BackgroundImage = BtnIconLight;
            }
        }

        public SidebarButton(ButtonType buttonType, Action btnClick = null, bool activeButton = false)
        {
            InitializeComponent();

            // Whether the current button is active
            ActiveButton = activeButton;

            // Set the action to invoke when the button is clicked
            BtnClick = btnClick;            

            // Set the icons and text based on the button type
            switch(buttonType)
            {
                case ButtonType.Dashboard:
                    BtnIconLight = Resources.home;
                    BtnIconDark = Resources.home_dark;
                    BtnText = "Dashboard";
                    break;

                case ButtonType.Schedule:
                    BtnIconLight = Resources.schedule;
                    BtnIconDark = Resources.schedule_dark;
                    BtnText = "Schedule";
                    break;

                case ButtonType.Membership:
                    BtnIconLight = Resources.membership;
                    BtnIconDark = Resources.membership_dark;
                    BtnText = "Membership";
                    break;

                case ButtonType.Payments:
                    BtnIconLight = Resources.payments;
                    BtnIconDark = Resources.payments_dark;
                    BtnText = "Payments";
                    break;

                case ButtonType.ContactUs:
                    BtnIconLight = Resources.contact;
                    BtnIconDark = Resources.contact_dark;
                    BtnText = "Contact Us";
                    break;

                case ButtonType.Classes:
                    BtnIconLight = Resources.schedule;
                    BtnIconDark = Resources.schedule_dark;
                    BtnText = "Classes";
                    break;

                case ButtonType.Students:
                    BtnIconLight = Resources.students;
                    BtnIconDark = Resources.students_dark;
                    BtnText = "Students";
                    break;

                case ButtonType.Feedbacks:
                    BtnIconLight = Resources.feedbacks;
                    BtnIconDark = Resources.feedbacks_dark;
                    BtnText = "Feedbacks";
                    break;

                case ButtonType.Assessements:
                    BtnIconLight = Resources.assessments;
                    BtnIconDark = Resources.assessments_dark;
                    BtnText = "Assessements";
                    break;
            }

            // Set the button text
            label_btn_text.Text = BtnText;

            // Set the button icon
            pictureBox_icon.BackgroundImage = BtnIconLight;
        }

        // ** Event: When the control is first loaded
        private void SidebarButton_Load(object sender, EventArgs e)
        {
            // Make the "panel_button" a rounded rectangle
            panel_button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_button.Width,
            panel_button.Height, 12, 12));

            // If the current button is active
            if(ActiveButton)
            {
                // Set the background color #A1D200
                panel_button.BackColor = Color.FromArgb(161, 210, 0);

                // Set the text color black
                label_btn_text.ForeColor = Color.Black;

                // Set the dark icon
                pictureBox_icon.BackgroundImage = BtnIconDark;
            }
        }

        // ** Event: When the mouse cursor enters the visible part of the control
        private void SidebarButton_MouseEnter(object sender, EventArgs e)
        {
            if (ActiveButton) return; // Exit the method if the current button is active

            // Set the background color #A1D200
            panel_button.BackColor = Color.FromArgb(161, 210, 0);

            // Set the text color black
            label_btn_text.ForeColor = Color.Black;

            // Set the dark icon
            pictureBox_icon.BackgroundImage = BtnIconDark;
        }

        // ** Event: When the mouse cursor leaves the visible part of the control
        private void SidebarButton_MouseLeave(object sender, EventArgs e)
        {
            if (ActiveButton) return; // Exit the method if the current button is active

            // Set the background color #000000
            panel_button.BackColor = Color.Black;

            // Set the text color black
            label_btn_text.ForeColor = Color.White;

            // Set the dark icon
            pictureBox_icon.BackgroundImage = BtnIconLight;
        }

        // ** Event: Invoke the "BtnClick" action we took as a parameter when any control within the button is clicked
        private void OnClick(object sender, EventArgs e) => BtnClick.Invoke();

        // ** Event: When the button is being resized
        private void SidebarButton_Resize(object sender, EventArgs e)
        {
            // Here, we re-calculate the size of the rounded rectangle as our control is resized
            panel_button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_button.Width,
            panel_button.Height, 12, 12));
        }
    }

    public enum ButtonType
    {
        // Common and member specific buttons
        Dashboard,
        Schedule,
        Membership,
        Payments,
        ContactUs,

        // Trainer specific buttons
        Classes,
        Students,
        Feedbacks,
        Assessements,
    }
}
