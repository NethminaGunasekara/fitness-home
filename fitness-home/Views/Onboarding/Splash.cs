using AnimateDemo;
using fitness_home.Services;
using fitness_home.Services.Types;
using fitness_home.Utils;
using fitness_home.Utils.Types.User;
using fitness_home.Views.Dashboard;
using fitness_home.Views.Messages;
using System;
using System.Configuration;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fitness_home.Views.Onboarding
{
    public partial class Splash : Form
    {
        // Loading animation properties
        private Timer animationTimer;
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

        private async void Splash_Shown(object sender, EventArgs e)
        {
            // If user credentials are stored in the config
            string userEmail = ConfigurationManager.AppSettings["USER_EMAIL"] ?? "";
            string userPass = ConfigurationManager.AppSettings["USER_PASSWORD"] ?? "";

            if (userEmail.Length == 0 || userPass.Length == 0)
            {
                // Display Welcome form after 2s if no email or password is stored in the config
                await Task.Delay(2000);

                Welcome WelcomeForm = FormProvider.Welcome ?? (FormProvider.Welcome = new Welcome());
                Helpers.ShowForm(WelcomeForm, this);
            }

            else
            {
                // Proceed to login with the stored email and password
                LoginStatus loginStatus = Authentication.Instance.Login(userEmail, userPass);

                if(loginStatus == LoginStatus.Success)
                {
                    // Change the loading status from "FETCHING DATA" to "LOGGING IN" after 2s
                    await Task.Delay(2000);

                    // Add a margin to make it look better as it's shorter than the previous text
                    label_fetching_data.Location = new Point(
                        label_fetching_data.Location.X + 16, 
                        label_fetching_data.Location.Y);
                    
                    label_fetching_data.Text = "LOGGING IN";

                    // Redirect user to the dashboard after another 2s
                    await Task.Delay(2000);

                    // Redirect logged user to a dashboard based on the user type
                    if(Authentication.LoggedUser is Member)
                    {
                        // Show the Member Dashboard
                        MemberDashboard MemberDashboard = FormProvider.MemberDashboard ?? (FormProvider.MemberDashboard = new MemberDashboard());
                        
                        Helpers.ShowForm(
                            targetForm: MemberDashboard, 
                            currentForm: this, 
                            setSize: false, 
                            setPosition: false);
                    }
                }

                // If stored email or password is incorrect (let's assume that the user has edited the config)
                else if(loginStatus == LoginStatus.InvalidEmail || loginStatus == LoginStatus.InvalidPassword)
                {
                    // Display Welcome form after a delay of 2 seconds
                    await Task.Delay(2000);

                    Welcome WelcomeForm = FormProvider.Welcome ?? (FormProvider.Welcome = new Welcome());
                    Helpers.ShowForm(WelcomeForm, this);
                }

                // If there's a database connection error
                else if (loginStatus == LoginStatus.DatabaseError) {
                    DatabaseError databaseError = new DatabaseError();
                    databaseError.StartPosition = FormStartPosition.Manual;

                    int x = this.Location.X + (this.Width / 2) - databaseError.Width / 2;
                    int y = this.Location.Y + (this.Height / 2) - databaseError.Height / 2;

                    Point location = new Point(x, y);

                    databaseError.Location = location;

                    databaseError.ShowDialog();
                }
            }

        }

        // Used to draw a custom border around the progress bar squares
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

        private void panel_square_1_Paint(object sender, PaintEventArgs e)
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
    }
}
