namespace fitness_home.Views.Dashboard.Member.Components
{
    partial class SidebarButton
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
            this.panel_button = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel_button
            // 
            this.panel_button.BackColor = System.Drawing.Color.Black;
            this.panel_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_button.Location = new System.Drawing.Point(0, 0);
            this.panel_button.Margin = new System.Windows.Forms.Padding(0);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(232, 52);
            this.panel_button.TabIndex = 0;
            this.panel_button.MouseEnter += new System.EventHandler(this.SidebarButton_MouseEnter);
            this.panel_button.MouseLeave += new System.EventHandler(this.SidebarButton_MouseLeave);
            // 
            // SidebarButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_button);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SidebarButton";
            this.Size = new System.Drawing.Size(232, 52);
            this.Load += new System.EventHandler(this.SidebarButton_Load);
            this.MouseEnter += new System.EventHandler(this.SidebarButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SidebarButton_MouseLeave);
            this.Resize += new System.EventHandler(this.SidebarButton_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_button;
    }
}
