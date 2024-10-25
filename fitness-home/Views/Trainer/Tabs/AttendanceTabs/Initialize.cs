using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Zen.Barcode;

namespace fitness_home.Views.Trainer.Tabs
{
    public partial class Initialize : UserControl
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

        public Initialize()
        {
            InitializeComponent();
        }

        // Applies rounded corners around the intstructions panel
        private void ApplyRoundedCorners()
        {
            panel_instructions.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_instructions.Width, panel_instructions.Height, 12, 12));
        }

        // ** Event: When the control is first loaded
        private void Initialize_Load(object sender, EventArgs e)
        {
            // Apply rounded corners to the form or relevant controls
            ApplyRoundedCorners();

            // Generate the QR code and display it in the PictureBox
            CodeQrBarcodeDraw qrcode = BarcodeDrawFactory.CodeQr;
            pictureBox_qrc.Image = qrcode.Draw("https://github.com/NethminaGunasekara/fitness-home", 60);
        }


        // ** Event: When the control is being resized
        private void Initialize_Resize(object sender, EventArgs e)
        {
            // Here, we re-calculate the size of the panels with rounded corners as our control is resized
            ApplyRoundedCorners();
        }
    }
}
