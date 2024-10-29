namespace fitness_home.Views.Tests
{
    partial class InitializeData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_add_plans = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_add_plans
            // 
            this.button_add_plans.Location = new System.Drawing.Point(276, 107);
            this.button_add_plans.Name = "button_add_plans";
            this.button_add_plans.Size = new System.Drawing.Size(183, 30);
            this.button_add_plans.TabIndex = 0;
            this.button_add_plans.Text = "Add Membership Plans";
            this.button_add_plans.UseVisualStyleBackColor = true;
            this.button_add_plans.Click += new System.EventHandler(this.button_add_plans_Click);
            // 
            // InitializeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_add_plans);
            this.Name = "InitializeData";
            this.Text = "InitializeData";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_add_plans;
    }
}