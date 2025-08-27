using FitnessHome.Properties;
using FitnessHome.Views.Onboarding.Components;

namespace fitness_home
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();

            // Add the close button to the layout
            CloseBtn closeBtn = new CloseBtn(this);
            closeBtn.Dock = DockStyle.Fill;

            // Position the close button at the top-right corner
            content_layout.Controls.Add(closeBtn, 0, 0);
            content_layout.SetColumnSpan(closeBtn, 3);

            // Add an empty draggable area to fill the remaining space in the titlebar
            DraggableArea draggableArea = new DraggableArea(this);
            draggableArea.Dock = DockStyle.Fill;

            // Position the draggable area to fill the remaining space in the titlebar
            left_area.Controls.Add(draggableArea, 0, 0);
            left_area.SetColumnSpan(draggableArea, 3);
        }

        // Navigate user to the Login view once they click "Get Started" button
        private void GetStarted(object sender, EventArgs e)
        {
            // Create a new instance of Login form, or pass the existing one
            // Login LoginForm = FormProvider.Login ?? (FormProvider.Login = new Login());
            // FormProvider.ShowForm(LoginForm, this);
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }
    }
}
