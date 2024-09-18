namespace fitness_home.Views.Onboarding
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.tableLayoutPanel_content = new System.Windows.Forms.TableLayoutPanel();
            this.panel_background = new System.Windows.Forms.Panel();
            this.label_said = new System.Windows.Forms.Label();
            this.label_quote = new System.Windows.Forms.Label();
            this.tableLayoutPanel_left = new System.Windows.Forms.TableLayoutPanel();
            this.panel_logo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_loading = new System.Windows.Forms.Panel();
            this.panel_square_3 = new System.Windows.Forms.Panel();
            this.panel_square_2 = new System.Windows.Forms.Panel();
            this.panel_square_1 = new System.Windows.Forms.Panel();
            this.label_fetching_data = new System.Windows.Forms.Label();
            this.label_message = new System.Windows.Forms.Label();
            this.panel_separator = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_content.SuspendLayout();
            this.panel_background.SuspendLayout();
            this.tableLayoutPanel_left.SuspendLayout();
            this.panel_logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_loading.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_content
            // 
            this.tableLayoutPanel_content.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel_content.ColumnCount = 2;
            this.tableLayoutPanel_content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel_content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel_content.Controls.Add(this.panel_background, 1, 0);
            this.tableLayoutPanel_content.Controls.Add(this.tableLayoutPanel_left, 0, 0);
            this.tableLayoutPanel_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_content.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_content.Name = "tableLayoutPanel_content";
            this.tableLayoutPanel_content.RowCount = 1;
            this.tableLayoutPanel_content.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_content.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_content.Size = new System.Drawing.Size(884, 450);
            this.tableLayoutPanel_content.TabIndex = 0;
            // 
            // panel_background
            // 
            this.panel_background.BackColor = System.Drawing.Color.Transparent;
            this.panel_background.BackgroundImage = global::fitness_home.Properties.Resources.splash;
            this.panel_background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel_background.Controls.Add(this.label_said);
            this.panel_background.Controls.Add(this.label_quote);
            this.panel_background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_background.Location = new System.Drawing.Point(356, 3);
            this.panel_background.Name = "panel_background";
            this.panel_background.Size = new System.Drawing.Size(525, 444);
            this.panel_background.TabIndex = 0;
            // 
            // label_said
            // 
            this.label_said.AutoSize = true;
            this.label_said.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(210)))), ((int)(((byte)(0)))));
            this.label_said.Font = new System.Drawing.Font("Noto Sans SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.label_said.Location = new System.Drawing.Point(324, 287);
            this.label_said.Name = "label_said";
            this.label_said.Size = new System.Drawing.Size(124, 24);
            this.label_said.TabIndex = 1;
            this.label_said.Text = "- Fitness Home";
            // 
            // label_quote
            // 
            this.label_quote.AutoSize = true;
            this.label_quote.Font = new System.Drawing.Font("Rajdhani SemiBold", 15F, System.Drawing.FontStyle.Bold);
            this.label_quote.ForeColor = System.Drawing.Color.White;
            this.label_quote.Location = new System.Drawing.Point(95, 188);
            this.label_quote.Name = "label_quote";
            this.label_quote.Size = new System.Drawing.Size(361, 78);
            this.label_quote.TabIndex = 0;
            this.label_quote.Text = "Strength doesn’t come from what you can \r\ndo, it comes from overcoming the things" +
    " \r\nyou once thought you couldn’t.";
            this.label_quote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel_left
            // 
            this.tableLayoutPanel_left.ColumnCount = 1;
            this.tableLayoutPanel_left.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_left.Controls.Add(this.panel_logo, 0, 0);
            this.tableLayoutPanel_left.Controls.Add(this.panel_loading, 0, 1);
            this.tableLayoutPanel_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_left.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_left.Name = "tableLayoutPanel_left";
            this.tableLayoutPanel_left.RowCount = 2;
            this.tableLayoutPanel_left.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel_left.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel_left.Size = new System.Drawing.Size(347, 444);
            this.tableLayoutPanel_left.TabIndex = 1;
            // 
            // panel_logo
            // 
            this.panel_logo.Controls.Add(this.pictureBox1);
            this.panel_logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_logo.Location = new System.Drawing.Point(3, 3);
            this.panel_logo.Name = "panel_logo";
            this.panel_logo.Size = new System.Drawing.Size(341, 260);
            this.panel_logo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::fitness_home.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(49, 62);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 184);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel_loading
            // 
            this.panel_loading.Controls.Add(this.panel_square_3);
            this.panel_loading.Controls.Add(this.panel_square_2);
            this.panel_loading.Controls.Add(this.panel_square_1);
            this.panel_loading.Controls.Add(this.label_fetching_data);
            this.panel_loading.Controls.Add(this.label_message);
            this.panel_loading.Controls.Add(this.panel_separator);
            this.panel_loading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_loading.Location = new System.Drawing.Point(3, 269);
            this.panel_loading.Name = "panel_loading";
            this.panel_loading.Size = new System.Drawing.Size(341, 172);
            this.panel_loading.TabIndex = 1;
            // 
            // panel_square_3
            // 
            this.panel_square_3.BackColor = System.Drawing.Color.Transparent;
            this.panel_square_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_square_3.Location = new System.Drawing.Point(190, 115);
            this.panel_square_3.Margin = new System.Windows.Forms.Padding(0);
            this.panel_square_3.Name = "panel_square_3";
            this.panel_square_3.Size = new System.Drawing.Size(12, 12);
            this.panel_square_3.TabIndex = 7;
            this.panel_square_3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_square_3_Paint);
            // 
            // panel_square_2
            // 
            this.panel_square_2.BackColor = System.Drawing.Color.Transparent;
            this.panel_square_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_square_2.Location = new System.Drawing.Point(164, 115);
            this.panel_square_2.Margin = new System.Windows.Forms.Padding(0);
            this.panel_square_2.Name = "panel_square_2";
            this.panel_square_2.Size = new System.Drawing.Size(12, 12);
            this.panel_square_2.TabIndex = 6;
            this.panel_square_2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_square_2_Paint);
            // 
            // panel_square_1
            // 
            this.panel_square_1.BackColor = System.Drawing.Color.Transparent;
            this.panel_square_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_square_1.Location = new System.Drawing.Point(138, 115);
            this.panel_square_1.Margin = new System.Windows.Forms.Padding(0);
            this.panel_square_1.Name = "panel_square_1";
            this.panel_square_1.Size = new System.Drawing.Size(12, 12);
            this.panel_square_1.TabIndex = 5;
            this.panel_square_1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_square_1_Paint);
            // 
            // label_fetching_data
            // 
            this.label_fetching_data.AutoSize = true;
            this.label_fetching_data.Font = new System.Drawing.Font("Rajdhani", 18F, System.Drawing.FontStyle.Bold);
            this.label_fetching_data.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(210)))), ((int)(((byte)(0)))));
            this.label_fetching_data.Location = new System.Drawing.Point(96, 76);
            this.label_fetching_data.Margin = new System.Windows.Forms.Padding(0);
            this.label_fetching_data.Name = "label_fetching_data";
            this.label_fetching_data.Size = new System.Drawing.Size(161, 30);
            this.label_fetching_data.TabIndex = 3;
            this.label_fetching_data.Text = "FETCHING DATA";
            // 
            // label_message
            // 
            this.label_message.AutoSize = true;
            this.label_message.Font = new System.Drawing.Font("Noto Sans Medium", 10F, System.Drawing.FontStyle.Bold);
            this.label_message.ForeColor = System.Drawing.Color.White;
            this.label_message.Location = new System.Drawing.Point(97, 41);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(167, 22);
            this.label_message.TabIndex = 2;
            this.label_message.Text = "Please wait a moment..";
            // 
            // panel_separator
            // 
            this.panel_separator.BackColor = System.Drawing.Color.White;
            this.panel_separator.Location = new System.Drawing.Point(49, 0);
            this.panel_separator.Margin = new System.Windows.Forms.Padding(0);
            this.panel_separator.Name = "panel_separator";
            this.panel_separator.Size = new System.Drawing.Size(270, 1);
            this.panel_separator.TabIndex = 1;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(884, 450);
            this.Controls.Add(this.tableLayoutPanel_content);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fitness Home - Loading";
            this.Load += new System.EventHandler(this.Splash_Load);
            this.Shown += new System.EventHandler(this.Splash_Shown);
            this.tableLayoutPanel_content.ResumeLayout(false);
            this.panel_background.ResumeLayout(false);
            this.panel_background.PerformLayout();
            this.tableLayoutPanel_left.ResumeLayout(false);
            this.panel_logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_loading.ResumeLayout(false);
            this.panel_loading.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_content;
        private System.Windows.Forms.Panel panel_background;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_left;
        private System.Windows.Forms.Panel panel_logo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_loading;
        private System.Windows.Forms.Panel panel_separator;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.Label label_fetching_data;
        private System.Windows.Forms.Panel panel_square_1;
        private System.Windows.Forms.Panel panel_square_2;
        private System.Windows.Forms.Panel panel_square_3;
        private System.Windows.Forms.Label label_quote;
        private System.Windows.Forms.Label label_said;
    }
}