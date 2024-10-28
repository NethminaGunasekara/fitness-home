using fitness_home.Services;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Net;
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

        // ** Helper Method: Get the local IP address
        private string GetLocalIPAddress()
        {
            string localIP = string.Empty;
            
            foreach (var ip in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }

            Console.WriteLine( localIP );

            return localIP;
        }

        // ** Helper Method: Generate the QR code and display it in the PictureBox
        private void GenerateQR()
        {
            // Information to be stored in the QR code
            object qrData = new
            {
                TrainerId = Authentication.LoggedUser.ID,
                IPAddress = GetLocalIPAddress(),
            };

            // Convert qrData to JSON
            string jsonData = JsonConvert.SerializeObject(qrData);

            // Generate the QR code and display it in the PictureBox
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(jsonData, QRCodeGenerator.ECCLevel.Q))
            using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
            {
                // Generate the QR code image as a byte array
                byte[] qrCodeImage = qrCode.GetGraphic(20);

                // Convert the byte array to an Image and set it in the PictureBox
                using (MemoryStream ms = new MemoryStream(qrCodeImage))
                {
                    pictureBox_qrc.Image = Image.FromStream(ms);
                }
            }
        }

        // ** Event Method: When the control is first loaded
        private void Initialize_Load(object sender, EventArgs e)
        {
            // Apply rounded corners to the form or relevant controls
            ApplyRoundedCorners();

            // Generate and display the initial QR code
            GenerateQR();
        }


        // ** Event Method: When the control is being resized
        private void Initialize_Resize(object sender, EventArgs e)
        {
            // Here, we re-calculate the size of the panels with rounded corners as our control is resized
            ApplyRoundedCorners();
        }

        // ** Event Method: Regenerate the QR code on user request
        private void button_refresh_qrc_Click(object sender, EventArgs e)
        {
            // Re generate the QR code
            GenerateQR();

            // Invalidate the form to display the new QR code
            Refresh();
        }
    }
}
