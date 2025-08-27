using System.Configuration;


using FitnessHome.Helpers;
using Timer = System.Windows.Forms.Timer;

namespace fitness_home.Views.Onboarding
{
    public partial class Splash : Form
    {
        // Loading animation properties
        private Timer? animationTimer;
        private int currentSquare = 1;
        private Color fillColor = Color.FromArgb(161, 210, 0);
        private Color emptyColor = Color.Transparent;

        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            // Application starting animation
            WinAPI.AnimateWindow(this.Handle, 400, WinAPI.BLEND);

            // Loading animation
            animationTimer = new Timer();

            // Animation interval
            animationTimer.Interval = 300;
            animationTimer.Tick += new EventHandler(AnimationTimer_Tick);
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            switch (currentSquare)
            {
                // Initial state: make all squares transparent
                case 0:
                    panel_square_1.BackColor = emptyColor;
                    panel_square_2.BackColor = emptyColor;
                    panel_square_3.BackColor = emptyColor;
                    break;

                // Fill the first square
                case 1:
                    panel_square_1.BackColor = fillColor;
                    panel_square_2.BackColor = emptyColor;
                    panel_square_3.BackColor = emptyColor;
                    break;

                // Fill the second one too
                case 2:
                    panel_square_2.BackColor = fillColor;
                    panel_square_1.BackColor = fillColor;
                    panel_square_3.BackColor = emptyColor;
                    break;

                // Fill all three squares
                case 3:
                    panel_square_3.BackColor = fillColor;
                    panel_square_1.BackColor = fillColor;
                    panel_square_2.BackColor = fillColor;
                    break;
            }

            // Increment and reset the counter
            currentSquare++;

            // Go to transparent state for one cycle before restarting
            if (currentSquare > 3)
            {
                currentSquare = 0;
            }
        }

        private void Splash_Shown(object sender, EventArgs e)
        {
            // If user credentials are stored in the config
            string userEmail = ConfigurationManager.AppSettings["USER_EMAIL"] ?? "";
            string userPass = ConfigurationManager.AppSettings["USER_PASSWORD"] ?? "";

            Forms.ShowForm(Forms.FormType.Welcome, this);
        }

        // Draws a custom border around the progress bar squares
        private void DrawBorder(PaintEventArgs e)
        {
            Color borderColor = Color.FromArgb(161, 210, 0);
            int borderWidth = 3;

            // Create a pen to draw the border
            using (Pen borderPen = new Pen(borderColor, borderWidth))
            {
                // Reduce the size of the rectangle for drawing
                Rectangle rect = new Rectangle(0, 0, panel_square_1.Width - borderWidth, panel_square_1.Height - borderWidth);

                // Draw the rectangle around the panel
                e.Graphics.DrawRectangle(borderPen, rect);
            }
        }

        private void SquarePaint(object sender, PaintEventArgs e)
        {
            DrawBorder(e);
        }

        private void panel_square_2_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(e);
        }

        private void panel_square_3_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(Forms.FormType.Welcome, this, false);
        }
    }
}
