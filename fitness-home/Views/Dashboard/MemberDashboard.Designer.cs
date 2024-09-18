namespace fitness_home.Views.Dashboard
{
    partial class MemberDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberDashboard));
            this.tableLayoutPanel_dashboard = new System.Windows.Forms.TableLayoutPanel();
            this.panel_logo = new System.Windows.Forms.Panel();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.panel_sidebar = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_dashboard.SuspendLayout();
            this.panel_logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_dashboard
            // 
            this.tableLayoutPanel_dashboard.ColumnCount = 2;
            this.tableLayoutPanel_dashboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel_dashboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73F));
            this.tableLayoutPanel_dashboard.Controls.Add(this.panel_logo, 0, 0);
            this.tableLayoutPanel_dashboard.Controls.Add(this.panel_sidebar, 0, 1);
            this.tableLayoutPanel_dashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_dashboard.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_dashboard.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_dashboard.Name = "tableLayoutPanel_dashboard";
            this.tableLayoutPanel_dashboard.RowCount = 2;
            this.tableLayoutPanel_dashboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel_dashboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_dashboard.Size = new System.Drawing.Size(1264, 681);
            this.tableLayoutPanel_dashboard.TabIndex = 0;
            // 
            // panel_logo
            // 
            this.panel_logo.BackColor = System.Drawing.Color.Black;
            this.panel_logo.Controls.Add(this.pictureBox_logo);
            this.panel_logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_logo.Location = new System.Drawing.Point(0, 0);
            this.panel_logo.Margin = new System.Windows.Forms.Padding(0);
            this.panel_logo.Name = "panel_logo";
            this.panel_logo.Size = new System.Drawing.Size(341, 80);
            this.panel_logo.TabIndex = 1;
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBox_logo.BackgroundImage = global::fitness_home.Properties.Resources.logo_cropped;
            this.pictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_logo.Location = new System.Drawing.Point(116, 15);
            this.pictureBox_logo.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(106, 65);
            this.pictureBox_logo.TabIndex = 0;
            this.pictureBox_logo.TabStop = false;
            // 
            // panel_sidebar
            // 
            this.panel_sidebar.BackColor = System.Drawing.Color.Black;
            this.panel_sidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_sidebar.Location = new System.Drawing.Point(0, 80);
            this.panel_sidebar.Margin = new System.Windows.Forms.Padding(0);
            this.panel_sidebar.Name = "panel_sidebar";
            this.panel_sidebar.Size = new System.Drawing.Size(341, 601);
            this.panel_sidebar.TabIndex = 2;
            // 
            // MemberDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tableLayoutPanel_dashboard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 360);
            this.Name = "MemberDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Member";
            this.Load += new System.EventHandler(this.Member_Load);
            this.tableLayoutPanel_dashboard.ResumeLayout(false);
            this.panel_logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_dashboard;
        private System.Windows.Forms.Panel panel_logo;
        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.Panel panel_sidebar;
    }
}