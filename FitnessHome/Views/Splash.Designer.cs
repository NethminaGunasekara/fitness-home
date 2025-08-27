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
            tableLayoutPanel_content = new TableLayoutPanel();
            panel_background = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label_quote = new Label();
            label_said = new Label();
            tableLayoutPanel_left = new TableLayoutPanel();
            panel_logo = new Panel();
            pictureBox1 = new PictureBox();
            panel_loading = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel_square_1 = new Panel();
            panel_square_2 = new Panel();
            panel_square_3 = new Panel();
            label_message = new Label();
            label_fetching_data = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel_separator = new Panel();
            tableLayoutPanel_content.SuspendLayout();
            panel_background.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel_left.SuspendLayout();
            panel_logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel_loading.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel_content
            // 
            tableLayoutPanel_content.BackColor = Color.Black;
            tableLayoutPanel_content.ColumnCount = 2;
            tableLayoutPanel_content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel_content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel_content.Controls.Add(panel_background, 1, 0);
            tableLayoutPanel_content.Controls.Add(tableLayoutPanel_left, 0, 0);
            tableLayoutPanel_content.Dock = DockStyle.Fill;
            tableLayoutPanel_content.Location = new Point(0, 0);
            tableLayoutPanel_content.Margin = new Padding(0);
            tableLayoutPanel_content.Name = "tableLayoutPanel_content";
            tableLayoutPanel_content.RowCount = 1;
            tableLayoutPanel_content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_content.RowStyles.Add(new RowStyle(SizeType.Absolute, 519F));
            tableLayoutPanel_content.Size = new Size(1280, 720);
            tableLayoutPanel_content.TabIndex = 0;
            // 
            // panel_background
            // 
            panel_background.BackColor = Color.Transparent;
            panel_background.BackgroundImage = FitnessHome.Properties.Resources.SplashBackground;
            panel_background.BackgroundImageLayout = ImageLayout.Zoom;
            panel_background.Controls.Add(tableLayoutPanel3);
            panel_background.Dock = DockStyle.Fill;
            panel_background.Location = new Point(512, 0);
            panel_background.Margin = new Padding(0);
            panel_background.Name = "panel_background";
            panel_background.Size = new Size(768, 720);
            panel_background.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(label_quote, 1, 1);
            tableLayoutPanel3.Controls.Add(label_said, 1, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(768, 720);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // label_quote
            // 
            label_quote.AutoSize = true;
            label_quote.Font = new Font("Rajdhani SemiBold", 21F, FontStyle.Bold);
            label_quote.ForeColor = Color.White;
            label_quote.Location = new Point(134, 306);
            label_quote.Margin = new Padding(4, 0, 4, 0);
            label_quote.Name = "label_quote";
            label_quote.Size = new Size(500, 108);
            label_quote.TabIndex = 0;
            label_quote.Text = "Strength doesn’t come from what you can \r\ndo, it comes from overcoming the things \r\nyou once thought you couldn’t.";
            label_quote.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_said
            // 
            label_said.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_said.AutoSize = true;
            label_said.BackColor = Color.FromArgb(161, 210, 0);
            label_said.Font = new Font("Rajdhani SemiBold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_said.Location = new Point(453, 448);
            label_said.Margin = new Padding(0, 34, 20, 0);
            label_said.Name = "label_said";
            label_said.Size = new Size(165, 28);
            label_said.TabIndex = 1;
            label_said.Text = " - FITNESS HOME ";
            // 
            // tableLayoutPanel_left
            // 
            tableLayoutPanel_left.ColumnCount = 1;
            tableLayoutPanel_left.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_left.Controls.Add(panel_logo, 0, 0);
            tableLayoutPanel_left.Controls.Add(panel_loading, 0, 2);
            tableLayoutPanel_left.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel_left.Dock = DockStyle.Fill;
            tableLayoutPanel_left.Location = new Point(0, 0);
            tableLayoutPanel_left.Margin = new Padding(0);
            tableLayoutPanel_left.Name = "tableLayoutPanel_left";
            tableLayoutPanel_left.RowCount = 3;
            tableLayoutPanel_left.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel_left.RowStyles.Add(new RowStyle());
            tableLayoutPanel_left.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel_left.Size = new Size(512, 720);
            tableLayoutPanel_left.TabIndex = 1;
            // 
            // panel_logo
            // 
            panel_logo.Controls.Add(pictureBox1);
            panel_logo.Dock = DockStyle.Fill;
            panel_logo.Location = new Point(0, 0);
            panel_logo.Margin = new Padding(0);
            panel_logo.Name = "panel_logo";
            panel_logo.Size = new Size(512, 423);
            panel_logo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = FitnessHome.Properties.Resources.Logo;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(78, 135);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(373, 248);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel_loading
            // 
            panel_loading.Controls.Add(tableLayoutPanel1);
            panel_loading.Dock = DockStyle.Fill;
            panel_loading.Location = new Point(0, 437);
            panel_loading.Margin = new Padding(0);
            panel_loading.Name = "panel_loading";
            panel_loading.Size = new Size(512, 283);
            panel_loading.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 22F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 22F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel_square_1, 1, 3);
            tableLayoutPanel1.Controls.Add(panel_square_2, 3, 3);
            tableLayoutPanel1.Controls.Add(panel_square_3, 5, 3);
            tableLayoutPanel1.Controls.Add(label_message, 0, 1);
            tableLayoutPanel1.Controls.Add(label_fetching_data, 0, 2);
            tableLayoutPanel1.Location = new Point(10, 17);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(475, 257);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // panel_square_1
            // 
            panel_square_1.BackColor = Color.Transparent;
            panel_square_1.BorderStyle = BorderStyle.FixedSingle;
            panel_square_1.Location = new Point(194, 106);
            panel_square_1.Margin = new Padding(0);
            panel_square_1.Name = "panel_square_1";
            panel_square_1.Size = new Size(14, 14);
            panel_square_1.TabIndex = 5;
            panel_square_1.Paint += SquarePaint;
            // 
            // panel_square_2
            // 
            panel_square_2.BackColor = Color.Transparent;
            panel_square_2.BorderStyle = BorderStyle.FixedSingle;
            panel_square_2.Location = new Point(230, 106);
            panel_square_2.Margin = new Padding(0);
            panel_square_2.Name = "panel_square_2";
            panel_square_2.Size = new Size(14, 14);
            panel_square_2.TabIndex = 6;
            panel_square_2.Paint += SquarePaint;
            // 
            // panel_square_3
            // 
            panel_square_3.BackColor = Color.Transparent;
            panel_square_3.BorderStyle = BorderStyle.FixedSingle;
            panel_square_3.Location = new Point(266, 106);
            panel_square_3.Margin = new Padding(0);
            panel_square_3.Name = "panel_square_3";
            panel_square_3.Size = new Size(14, 14);
            panel_square_3.TabIndex = 7;
            panel_square_3.Paint += SquarePaint;
            // 
            // label_message
            // 
            label_message.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label_message, 7);
            label_message.Dock = DockStyle.Fill;
            label_message.Font = new Font("Noto Sans Medium", 10F, FontStyle.Bold);
            label_message.ForeColor = Color.White;
            label_message.Location = new Point(4, 20);
            label_message.Margin = new Padding(4, 0, 4, 0);
            label_message.Name = "label_message";
            label_message.Size = new Size(467, 22);
            label_message.TabIndex = 2;
            label_message.Text = "Please wait a moment..";
            label_message.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_fetching_data
            // 
            label_fetching_data.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label_fetching_data, 7);
            label_fetching_data.Dock = DockStyle.Fill;
            label_fetching_data.Font = new Font("Rajdhani", 20F, FontStyle.Bold);
            label_fetching_data.ForeColor = Color.FromArgb(161, 210, 0);
            label_fetching_data.Location = new Point(0, 57);
            label_fetching_data.Margin = new Padding(0, 15, 0, 15);
            label_fetching_data.Name = "label_fetching_data";
            label_fetching_data.Size = new Size(475, 34);
            label_fetching_data.TabIndex = 3;
            label_fetching_data.Text = "FETCHING DATA";
            label_fetching_data.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel_separator, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 423);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(512, 14);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // panel_separator
            // 
            panel_separator.BackColor = Color.White;
            panel_separator.Location = new Point(57, 0);
            panel_separator.Margin = new Padding(0);
            panel_separator.Name = "panel_separator";
            panel_separator.Size = new Size(397, 1);
            panel_separator.TabIndex = 1;
            // 
            // Splash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(1280, 720);
            Controls.Add(tableLayoutPanel_content);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Splash";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fitness Home - Loading";
            Load += Splash_Load;
            Shown += Splash_Shown;
            tableLayoutPanel_content.ResumeLayout(false);
            panel_background.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel_left.ResumeLayout(false);
            panel_logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel_loading.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);

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
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label_quote;
        private Label label_said;
    }
}