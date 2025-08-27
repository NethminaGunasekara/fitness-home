namespace fitness_home
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            left_area = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            label_quote = new Label();
            label_said = new Label();
            content_layout = new TableLayoutPanel();
            panel_background = new Panel();
            tableLayoutPanel_content = new TableLayoutPanel();
            left_area.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            content_layout.SuspendLayout();
            panel_background.SuspendLayout();
            tableLayoutPanel_content.SuspendLayout();
            SuspendLayout();
            // 
            // left_area
            // 
            resources.ApplyResources(left_area, "left_area");
            left_area.Controls.Add(pictureBox1, 1, 2);
            left_area.Name = "left_area";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = FitnessHome.Properties.Resources.Logo;
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // label_quote
            // 
            resources.ApplyResources(label_quote, "label_quote");
            label_quote.ForeColor = Color.White;
            label_quote.Name = "label_quote";
            // 
            // label_said
            // 
            resources.ApplyResources(label_said, "label_said");
            label_said.BackColor = Color.FromArgb(161, 210, 0);
            label_said.Name = "label_said";
            // 
            // content_layout
            // 
            resources.ApplyResources(content_layout, "content_layout");
            content_layout.Controls.Add(label_quote, 1, 2);
            content_layout.Controls.Add(label_said, 1, 3);
            content_layout.Name = "content_layout";
            // 
            // panel_background
            // 
            panel_background.BackColor = Color.Transparent;
            panel_background.BackgroundImage = FitnessHome.Properties.Resources.SplashBackground;
            resources.ApplyResources(panel_background, "panel_background");
            panel_background.Controls.Add(content_layout);
            panel_background.Name = "panel_background";
            // 
            // tableLayoutPanel_content
            // 
            tableLayoutPanel_content.BackColor = Color.Black;
            resources.ApplyResources(tableLayoutPanel_content, "tableLayoutPanel_content");
            tableLayoutPanel_content.Controls.Add(panel_background, 1, 0);
            tableLayoutPanel_content.Controls.Add(left_area, 0, 0);
            tableLayoutPanel_content.Name = "tableLayoutPanel_content";
            // 
            // Welcome
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            BackgroundImage = FitnessHome.Properties.Resources.Background;
            Controls.Add(tableLayoutPanel_content);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Welcome";
            Load += Welcome_Load;
            left_area.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            content_layout.ResumeLayout(false);
            content_layout.PerformLayout();
            panel_background.ResumeLayout(false);
            tableLayoutPanel_content.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel Right;
        private TableLayoutPanel left_area;
        private PictureBox pictureBox1;
        private Label label_quote;
        private Label label_said;
        private TableLayoutPanel content_layout;
        private Panel panel_background;
        private TableLayoutPanel tableLayoutPanel_content;
    }
}

