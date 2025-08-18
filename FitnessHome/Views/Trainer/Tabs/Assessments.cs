using fitness_home.Helpers;
using fitness_home.Utils.Types;
using fitness_home.Utils.Types.UserTypes;
using fitness_home.Views.Messages;
using System;
using System.Windows.Forms;

namespace fitness_home.Views.Trainer.Tabs
{
    public partial class Assessments : UserControl
    {
        // Field to store an instance of MemberData class, used to retrieve and edit information about a member
        MemberData MemberData;

        // Id of the member being assessed by the trainer (we'll later use this to update assessments for them)
        private int MemberId = 0;

        // Field to store an instance of "AssessmentsForMember" helper class
        AssessmentsForMember AssessmentsForMember;

        public Assessments()
        {
            InitializeComponent();
        }

        // ** Event: When the search member button is clicked
        private void button_search_member_Click(object sender, EventArgs e)
        {
            string userInput = textBox_search.Text;

            // Try to parse the entered member ID to an integer (actual member id within the database: e.g. 3)
            try
            {
                // Extract the numeric part of the entered member id after removing "M" from it. e.g. "M001" becomes "001"
                string numericPart = userInput.Replace("M", "");

                int memberId = int.Parse(numericPart);

                // Set the id of member being assessed
                MemberId = memberId;
            }

            // If any error occurs while parsing
            catch (Exception)
            {
                // Initialize an input error message to display
                InputError inputError = new InputError(
                    errorType: "Invalid Member ID Format",
                    errorTitle: "Member ID format you've entered is invalid",
                    errorMessage: "Please check your input and try again");

                // Display the error message
                inputError.ShowDialog();

                return; // Exit the method as we don't want to continue after an exception occurs
            }

            // Retrieve the information about a member
            try
            {
                // Retrieve personal information of the searched member
                MemberData = new MemberData(MemberId);
            }

            // If the custom exception thrown when no user is found with the given id occurs
            catch (MemberNotFoundException)
            {
                // Initialize a member not found error message to display
                InputError inputError = new InputError(
                    errorType: "Member Not Found",
                    errorTitle: "No Member Found with Given ID",
                    errorMessage: "Please check the ID and try again.");

                // Display the error message
                inputError.ShowDialog();

                return; // Exit the method as we don't want to continue after an exception occurs
            }

            // Proceed to display assessments as no errors are occured

            // Retrieve information for the searched member
            AssessmentsForMember = new AssessmentsForMember(MemberId);

            // Display the name and id of the member being assessed
            UpdateTitle();

            // Make all hidden panels and other controls visible before displaying and editing data
            label_assessments_for_title.Visible = label_assessments_for.Visible = panel_daily_kcal.Visible = panel_lbm.Visible = panel_bmr.Visible = panel_bfp.Visible = panel_activity_level.Visible = true;

            // Display the retrieved assessments for the member id
            DisplayAssessments();
        }

        // Update the assessments for the current user
        private void button_update_assessments_Click(object sender, EventArgs e)
        {
            // If no member is selected to make assessments
            if (MemberId == 0 || AssessmentsForMember == null)
            {
                // Initialize an error message to display if no Member ID has been entered
                InputError inputError = new InputError(
                    errorType: "Missing Member ID",
                    errorTitle: "No Member ID Entered",
                    errorMessage: "Please enter a Member ID to search for assessments."
                );

                // Display the error message
                inputError.ShowDialog();

                return; // Exit the method
            }

            // If any of the textboxes are empty, or no activity level is selected (none of the radiobuttons are checked)
            if (textBox_height.Text == "" || textBox_weight.Text == "" || textBox_daily_kcal.Text == "" || CheckActivityLevel() == ActivityLevel.NotSpecified)
            {
                // Initialize an error message to display if any of the inputs are missing
                InputError inputError = new InputError(
                    errorType: "Missing Input",
                    errorTitle: "Required Inputs Are Missing",
                    errorMessage: "Please ensure that all fields are filled in before proceeding"
                );

                // Display the error message
                inputError.ShowDialog();

                return; // Exit the method
            }

            // Try to parse user inputs before updating assessments
            try
            {
                short weight = short.Parse(textBox_weight.Text);
                short height = short.Parse(textBox_height.Text);
                short dailyKcal = short.Parse(textBox_daily_kcal.Text);

                // If none of the errors occured while parsing inputs, proceed to update assessments
                AssessmentsForMember.Update(MemberId, height, weight, CheckActivityLevel().ToString(), dailyKcal);

                // Display an update operation successful message if updating the assessments is successful
                SuccessMessage successMessage = new SuccessMessage(
                    heading: "Assessment Successful!",
                    title: "Assessment has been updated successfully",
                    reference: "All changes are now reflected on the member's dashboard"
                );

                // Display the success message dialog
                successMessage.ShowDialog();
            }

            catch (Exception)
            {
                // Initialize an error message to display if the user has entered any invalid value
                InputError parsingError = new InputError(
                    errorType: "Invalid Input",
                    errorTitle: "One or More Inputs Are Invalid",
                    errorMessage: "Please ensure that all inputs are entered as whole numbers"
                );

                // Display the error message
                parsingError.ShowDialog();

                return; // Exit the method
            }
        }

        // Update the "assessments for" title (e.g. "Assessments For: Shehan Anushka (M002)")
        private void UpdateTitle()
        {
            // Step 1: Convert the integer memberId to a string first
            string memberIdString = MemberId.ToString();

            // Step 2: Add a padding left of "0"s to have a minimum length of 3 digits for the numeric part of the member id
            string paddedMemberId = memberIdString.PadLeft(3, '0');

            // Step 3: Combine the padded numeric part of the member id (e.g. "003") with the letter "M" and display it as the id of the member being assessed
            string formattedMemberId = $"M{paddedMemberId}";

            // Step 4: Combine the formatted member id with the member's name and display
            label_assessments_for.Text = $"{MemberData.FirstName} {MemberData.LastName} ({formattedMemberId})";
        }

        // ** Helper method to display assessments for a given user
        private void DisplayAssessments()
        {
            // If the activity level is not specified for the member, we can assume that no assessments are made for the searched member id
            if(AssessmentsForMember.ActivityLevel == ActivityLevel.NotSpecified) {
                // Display the name and id of the member being assessed
                UpdateTitle();

                // Make all hidden panels and other controls visible before displaying and editing data
                label_assessments_for_title.Visible = label_assessments_for.Visible = panel_daily_kcal.Visible = panel_lbm.Visible = panel_bmr.Visible = panel_bfp.Visible = panel_activity_level.Visible = true;

                // Display an empty list of assessments as none of the assessments are made for the currently searched user
                textBox_daily_kcal.Text = "-";
                label_lbm.Text = "-%";
                label_bmr.Text = "- kcal";
                label_bfp.Text = "-%";
                textBox_weight.Text = "-";
                textBox_height.Text = "-";

                return; // Exit the method after displaying some blank data
            }

            // The following code only rund if assessments are made for the given member id

            // Display the daily calorie goal
            textBox_daily_kcal.Text = AssessmentsForMember.CalorieGoal.ToString();

            // Check the activity level
            switch (AssessmentsForMember.ActivityLevel)
            {
                case ActivityLevel.Sedentary:
                    radioButton_sedentary.Checked = true;
                    break;

                case ActivityLevel.LightlyActive:
                    radioButton_lightly_active.Checked = true;
                    break;

                case ActivityLevel.ModeratelyActive:
                    radioButton_moderately_active.Checked = true;
                    break;

                case ActivityLevel.VeryActive:
                    radioButton_very_active.Checked = true;
                    break;

                case ActivityLevel.SuperActive:
                    radioButton_super_active.Checked = true;
                    break;
            }

            // Calculate and display the LBM (Lean Body Mass)
            double calculatedLBM = AssessmentsForMember.CalculateLBMPercentage(AssessmentsForMember.MemberWeight, AssessmentsForMember.MemberWeight);
            label_lbm.Text = $"{calculatedLBM}%";

            // Calculate and display the Basal Metabolic Rate (BMR)
            int calculatedBMR = (int)AssessmentsForMember.CalculateBMR(AssessmentsForMember.MemberHeight, AssessmentsForMember.MemberHeight, MemberData.DateOfBirth, AssessmentsForMember.ActivityLevel.ToString());
            label_bmr.Text = $"{calculatedBMR} kcal";

            // Calculate and display the Body Fat Percentage (BFP)
            double calculatedBFP = AssessmentsForMember.CalculateBFP(AssessmentsForMember.MemberHeight, AssessmentsForMember.MemberWeight, MemberData.DateOfBirth, MemberData.Gender);
            label_bfp.Text = $"{calculatedBFP:F1}%";

            // Set the height of the member
            textBox_height.Text = AssessmentsForMember.MemberHeight.ToString();

            // Set the weight of the member
            textBox_weight.Text = AssessmentsForMember.MemberWeight.ToString();
        }

        // ** Event: When the control is being loaded by the user
        private void Assessments_Load(object sender, EventArgs e)
        {
            // Apply rounded corners to a selected set of panels
            RoundedCorners.Apply(panel_content, panel_search, panel_daily_kcal, panel_lbm, panel_bmr, panel_bfp, panel_activity_level, panel_member_info);
        }

        // ** Event: When the control is being resized by the user
        private void Assessments_Resize(object sender, EventArgs e)
        {
            // Redraw the rounded corners applied to selected panels
            RoundedCorners.Apply(panel_content, panel_search, panel_daily_kcal, panel_lbm, panel_bmr, panel_bfp, panel_activity_level, panel_member_info);
        }

        // ** Event: When the search input receives the user's focus (i.e. When they clicked on the searchbar to search)
        private void textBox_search_Enter(object sender, EventArgs e)
        {
            // If the search textbox contains the placeholder value (Enter Member ID), remove it and let the user type a member id
            if (textBox_search.Text == "Enter Member ID")
            {
                // Clear the text content of the search input and leave it empty
                textBox_search.Text = "";
            }
        }

        // ** Event: When the search input loses the user's focus (i.e. When they clicked somewhere else on the form other than the searchbar after focusing on the searchbar)
        private void textBox_search_Leave(object sender, EventArgs e)
        {
            // If the member has entered nothing to search
            if (textBox_search.Text == "")
            {
                // Restore the placeholder value
                textBox_search.Text = "Enter Member ID";
            }
        }

        // Retrieve the user's activity level based on the radiobutton checked
        private ActivityLevel CheckActivityLevel()
        {
            // If the radiobutton "Sedentary" is checked
            if (radioButton_sedentary.Checked)
            {
                return ActivityLevel.Sedentary;
            }

            // If the radiobutton "Lightly Active" is checked
            else if (radioButton_lightly_active.Checked)
            {
                return ActivityLevel.LightlyActive;
            }

            // If the radiobutton "Moderately Active" is checked
            else if (radioButton_moderately_active.Checked)
            {
                return ActivityLevel.ModeratelyActive;
            }

            // If the radiobutton "Super Active" is checked
            else if (radioButton_super_active.Checked)
            {
                return ActivityLevel.SuperActive;
            }

            // If none of the radiobuttons are checked
            else
            {
                // Return the activity level as not specified to indicate that none of the radiobuttons are selected
                return ActivityLevel.NotSpecified;
            }
        }
    }
}
