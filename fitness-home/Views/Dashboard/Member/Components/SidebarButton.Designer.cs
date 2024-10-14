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
            this.tableLayoutPanel_btn_content = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox_icon = new System.Windows.Forms.PictureBox();
            this.label_btn_text = new System.Windows.Forms.Label();
            this.panel_button.SuspendLayout();
            this.tableLayoutPanel_btn_content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_button
            // 
            this.panel_button.BackColor = System.Drawing.Color.Black;
            this.panel_button.Controls.Add(this.tableLayoutPanel_btn_content);
            this.panel_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_button.Location = new System.Drawing.Point(0, 0);
            this.panel_button.Margin = new System.Windows.Forms.Padding(0);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(232, 52);
            this.panel_button.TabIndex = 0;
            this.panel_button.Click += new System.EventHandler(this.OnClick);
            this.panel_button.MouseEnter += new System.EventHandler(this.SidebarButton_MouseEnter);
            this.panel_button.MouseLeave += new System.EventHandler(this.SidebarButton_MouseLeave);
            // 
            // tableLayoutPanel_btn_content
            // 
            this.tableLayoutPanel_btn_content.ColumnCount = 4;
            this.tableLayoutPanel_btn_content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_btn_content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_btn_content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel_btn_content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_btn_content.Controls.Add(this.pictureBox_icon, 1, 1);
            this.tableLayoutPanel_btn_content.Controls.Add(this.label_btn_text, 2, 1);
            this.tableLayoutPanel_btn_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_btn_content.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_btn_content.Name = "tableLayoutPanel_btn_content";
            this.tableLayoutPanel_btn_content.RowCount = 3;
            this.tableLayoutPanel_btn_content.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_btn_content.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_btn_content.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_btn_content.Size = new System.Drawing.Size(232, 52);
            this.tableLayoutPanel_btn_content.TabIndex = 2;
            this.tableLayoutPanel_btn_content.Click += new System.EventHandler(this.OnClick);
            this.tableLayoutPanel_btn_content.MouseEnter += new System.EventHandler(this.SidebarButton_MouseEnter);
            this.tableLayoutPanel_btn_content.MouseLeave += new System.EventHandler(this.SidebarButton_MouseLeave);
            // 
            // pictureBox_icon
            // 
            this.pictureBox_icon.BackgroundImage = global::fitness_home.Properties.Resources.home;
            this.pictureBox_icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_icon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_icon.Location = new System.Drawing.Point(44, 14);
            this.pictureBox_icon.Margin = new System.Windows.Forms.Padding(0, 3, 0, 4);
            this.pictureBox_icon.Name = "pictureBox_icon";
            this.pictureBox_icon.Size = new System.Drawing.Size(20, 22);
            this.pictureBox_icon.TabIndex = 0;
            this.pictureBox_icon.TabStop = false;
            this.pictureBox_icon.Click += new System.EventHandler(this.OnClick);
            this.pictureBox_icon.MouseEnter += new System.EventHandler(this.SidebarButton_MouseEnter);
            this.pictureBox_icon.MouseLeave += new System.EventHandler(this.SidebarButton_MouseLeave);
            // 
            // label_btn_text
            // 
            this.label_btn_text.AutoSize = true;
            this.label_btn_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_btn_text.Font = new System.Drawing.Font("Rajdhani SemiBold", 15.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_btn_text.ForeColor = System.Drawing.Color.White;
            this.label_btn_text.Location = new System.Drawing.Point(70, 13);
            this.label_btn_text.Margin = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.label_btn_text.Name = "label_btn_text";
            this.label_btn_text.Size = new System.Drawing.Size(118, 27);
            this.label_btn_text.TabIndex = 1;
            this.label_btn_text.Text = "Dashboard";
            this.label_btn_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_btn_text.Click += new System.EventHandler(this.OnClick);
            this.label_btn_text.MouseEnter += new System.EventHandler(this.SidebarButton_MouseEnter);
            this.label_btn_text.MouseLeave += new System.EventHandler(this.SidebarButton_MouseLeave);
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
            this.panel_button.ResumeLayout(false);
            this.tableLayoutPanel_btn_content.ResumeLayout(false);
            this.tableLayoutPanel_btn_content.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_button;
        private System.Windows.Forms.PictureBox pictureBox_icon;
        private System.Windows.Forms.Label label_btn_text;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_btn_content;
    }
}
