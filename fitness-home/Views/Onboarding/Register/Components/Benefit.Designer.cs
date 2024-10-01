namespace fitness_home.Views.Onboarding.Register.Components
{
    partial class Benefit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_benefit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_benefit
            // 
            this.label_benefit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label_benefit.AutoSize = true;
            this.label_benefit.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_benefit.ForeColor = System.Drawing.Color.White;
            this.label_benefit.Location = new System.Drawing.Point(7, 4);
            this.label_benefit.Margin = new System.Windows.Forms.Padding(0);
            this.label_benefit.Name = "label_benefit";
            this.label_benefit.Size = new System.Drawing.Size(51, 17);
            this.label_benefit.TabIndex = 2;
            this.label_benefit.Text = "benefit";
            this.label_benefit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Benefit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label_benefit);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Benefit";
            this.Size = new System.Drawing.Size(322, 26);
            this.Load += new System.EventHandler(this.Benefit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_benefit;
    }
}
