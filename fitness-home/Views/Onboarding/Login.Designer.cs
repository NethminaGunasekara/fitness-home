namespace fitness_home
{
    partial class Login
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
            System.Windows.Forms.PictureBox icon_password;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            System.Windows.Forms.Label label_title;
            System.Windows.Forms.PictureBox icon_email;
            this.btn_get_started = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_password = new System.Windows.Forms.Panel();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.panel_logo = new System.Windows.Forms.Panel();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.panel_email = new System.Windows.Forms.Panel();
            this.textbox_email = new System.Windows.Forms.TextBox();
            this.panel_sign_up = new System.Windows.Forms.Panel();
            this.label_sign_up = new System.Windows.Forms.Label();
            this.link_sign_up = new System.Windows.Forms.LinkLabel();
            icon_password = new System.Windows.Forms.PictureBox();
            label_title = new System.Windows.Forms.Label();
            icon_email = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(icon_password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(icon_email)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_password.SuspendLayout();
            this.panel_logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.panel_email.SuspendLayout();
            this.panel_sign_up.SuspendLayout();
            this.SuspendLayout();
            // 
            // icon_password
            // 
            icon_password.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("icon_password.BackgroundImage")));
            icon_password.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            icon_password.Location = new System.Drawing.Point(16, 7);
            icon_password.Name = "icon_password";
            icon_password.Size = new System.Drawing.Size(28, 22);
            icon_password.TabIndex = 0;
            icon_password.TabStop = false;
            // 
            // label_title
            // 
            label_title.AutoSize = true;
            label_title.BackColor = System.Drawing.Color.Transparent;
            label_title.Dock = System.Windows.Forms.DockStyle.Bottom;
            label_title.Font = new System.Drawing.Font("Rajdhani", 26.25F, System.Drawing.FontStyle.Bold);
            label_title.ForeColor = System.Drawing.Color.White;
            label_title.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label_title.Location = new System.Drawing.Point(353, 76);
            label_title.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            label_title.Name = "label_title";
            label_title.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label_title.Size = new System.Drawing.Size(531, 45);
            label_title.TabIndex = 0;
            label_title.Text = "Sign in to your account";
            label_title.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // icon_email
            // 
            icon_email.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("icon_email.BackgroundImage")));
            icon_email.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            icon_email.Location = new System.Drawing.Point(16, -1);
            icon_email.Name = "icon_email";
            icon_email.Size = new System.Drawing.Size(28, 41);
            icon_email.TabIndex = 0;
            icon_email.TabStop = false;
            // 
            // btn_get_started
            // 
            this.btn_get_started.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_get_started.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(210)))), ((int)(((byte)(0)))));
            this.btn_get_started.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_get_started.Enabled = false;
            this.btn_get_started.FlatAppearance.BorderSize = 0;
            this.btn_get_started.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_get_started.Font = new System.Drawing.Font("Rajdhani SemiBold", 14.25F, System.Drawing.FontStyle.Bold);
            this.btn_get_started.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_get_started.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_get_started.Location = new System.Drawing.Point(534, 329);
            this.btn_get_started.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.btn_get_started.Name = "btn_get_started";
            this.btn_get_started.Size = new System.Drawing.Size(169, 41);
            this.btn_get_started.TabIndex = 3;
            this.btn_get_started.Text = "GET STARTED";
            this.btn_get_started.UseVisualStyleBackColor = false;
            this.btn_get_started.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel1.BackgroundImage")));
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.panel_password, 0, 2);
            this.tableLayoutPanel1.Controls.Add(label_title, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_logo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_get_started, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel_email, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_sign_up, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 450);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel_password
            // 
            this.panel_password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.panel_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_password.Controls.Add(icon_password);
            this.panel_password.Controls.Add(this.textbox_password);
            this.panel_password.Location = new System.Drawing.Point(393, 225);
            this.panel_password.Margin = new System.Windows.Forms.Padding(40, 3, 40, 3);
            this.panel_password.Name = "panel_password";
            this.panel_password.Size = new System.Drawing.Size(451, 41);
            this.panel_password.TabIndex = 8;
            // 
            // textbox_password
            // 
            this.textbox_password.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.textbox_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_password.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_password.ForeColor = System.Drawing.SystemColors.Window;
            this.textbox_password.Location = new System.Drawing.Point(61, 9);
            this.textbox_password.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.textbox_password.MaxLength = 72;
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.Size = new System.Drawing.Size(377, 20);
            this.textbox_password.TabIndex = 5;
            this.textbox_password.Text = "Password";
            this.textbox_password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            this.textbox_password.Enter += new System.EventHandler(this.RemovePlaceholder);
            this.textbox_password.Leave += new System.EventHandler(this.AddPlaceholder);
            // 
            // panel_logo
            // 
            this.panel_logo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.panel_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_logo.Controls.Add(this.pictureBox_logo);
            this.panel_logo.Location = new System.Drawing.Point(0, 0);
            this.panel_logo.Margin = new System.Windows.Forms.Padding(0);
            this.panel_logo.Name = "panel_logo";
            this.tableLayoutPanel1.SetRowSpan(this.panel_logo, 5);
            this.panel_logo.Size = new System.Drawing.Size(353, 450);
            this.panel_logo.TabIndex = 4;
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_logo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_logo.BackgroundImage = global::fitness_home.Properties.Resources.logo;
            this.pictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_logo.Location = new System.Drawing.Point(73, 135);
            this.pictureBox_logo.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(205, 244);
            this.pictureBox_logo.TabIndex = 1;
            this.pictureBox_logo.TabStop = false;
            // 
            // panel_email
            // 
            this.panel_email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.panel_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_email.Controls.Add(icon_email);
            this.panel_email.Controls.Add(this.textbox_email);
            this.panel_email.Location = new System.Drawing.Point(393, 161);
            this.panel_email.Margin = new System.Windows.Forms.Padding(40, 20, 40, 20);
            this.panel_email.Name = "panel_email";
            this.panel_email.Size = new System.Drawing.Size(451, 41);
            this.panel_email.TabIndex = 7;
            // 
            // textbox_email
            // 
            this.textbox_email.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox_email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.textbox_email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_email.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_email.ForeColor = System.Drawing.SystemColors.Window;
            this.textbox_email.Location = new System.Drawing.Point(61, 9);
            this.textbox_email.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.textbox_email.MaxLength = 100;
            this.textbox_email.Name = "textbox_email";
            this.textbox_email.Size = new System.Drawing.Size(377, 20);
            this.textbox_email.TabIndex = 5;
            this.textbox_email.Text = "Email";
            this.textbox_email.TextChanged += new System.EventHandler(this.Email_TextChanged);
            this.textbox_email.Enter += new System.EventHandler(this.RemovePlaceholder);
            this.textbox_email.Leave += new System.EventHandler(this.AddPlaceholder);
            // 
            // panel_sign_up
            // 
            this.panel_sign_up.BackColor = System.Drawing.Color.Transparent;
            this.panel_sign_up.Controls.Add(this.label_sign_up);
            this.panel_sign_up.Controls.Add(this.link_sign_up);
            this.panel_sign_up.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_sign_up.Location = new System.Drawing.Point(356, 272);
            this.panel_sign_up.Name = "panel_sign_up";
            this.panel_sign_up.Size = new System.Drawing.Size(525, 34);
            this.panel_sign_up.TabIndex = 9;
            // 
            // label_sign_up
            // 
            this.label_sign_up.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_sign_up.AutoSize = true;
            this.label_sign_up.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sign_up.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(164)))), ((int)(((byte)(164)))));
            this.label_sign_up.Location = new System.Drawing.Point(149, 8);
            this.label_sign_up.Name = "label_sign_up";
            this.label_sign_up.Size = new System.Drawing.Size(163, 18);
            this.label_sign_up.TabIndex = 0;
            this.label_sign_up.Text = "Don’t have an account?";
            this.label_sign_up.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // link_sign_up
            // 
            this.link_sign_up.ActiveLinkColor = System.Drawing.Color.White;
            this.link_sign_up.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.link_sign_up.AutoSize = true;
            this.link_sign_up.DisabledLinkColor = System.Drawing.Color.White;
            this.link_sign_up.Font = new System.Drawing.Font("Noto Sans Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_sign_up.ForeColor = System.Drawing.Color.White;
            this.link_sign_up.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.link_sign_up.LinkColor = System.Drawing.Color.White;
            this.link_sign_up.Location = new System.Drawing.Point(308, 5);
            this.link_sign_up.Name = "link_sign_up";
            this.link_sign_up.Size = new System.Drawing.Size(64, 23);
            this.link_sign_up.TabIndex = 1;
            this.link_sign_up.TabStop = true;
            this.link_sign_up.Text = "Sign Up";
            this.link_sign_up.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.link_sign_up.VisitedLinkColor = System.Drawing.Color.White;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(884, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "Login - Fitness Home";
            ((System.ComponentModel.ISupportInitialize)(icon_password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(icon_email)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel_password.ResumeLayout(false);
            this.panel_password.PerformLayout();
            this.panel_logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.panel_email.ResumeLayout(false);
            this.panel_email.PerformLayout();
            this.panel_sign_up.ResumeLayout(false);
            this.panel_sign_up.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_logo;
        private System.Windows.Forms.TextBox textbox_email;
        private System.Windows.Forms.Panel panel_email;
        private System.Windows.Forms.Panel panel_password;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.Panel panel_sign_up;
        private System.Windows.Forms.Label label_sign_up;
        private System.Windows.Forms.LinkLabel link_sign_up;
        private System.Windows.Forms.Button btn_get_started;
        private System.Windows.Forms.PictureBox pictureBox_logo;
    }
}