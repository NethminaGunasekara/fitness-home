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
            this.tableLayoutPanel_content = new System.Windows.Forms.TableLayoutPanel();
            this.label_description = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.btn_get_started = new System.Windows.Forms.Button();
            this.panel_logo = new System.Windows.Forms.Panel();
            this.img_logo = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel_content.SuspendLayout();
            this.panel_logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_content
            // 
            this.tableLayoutPanel_content.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.tableLayoutPanel_content, "tableLayoutPanel_content");
            this.tableLayoutPanel_content.Controls.Add(this.label_description, 1, 1);
            this.tableLayoutPanel_content.Controls.Add(this.label_title, 1, 0);
            this.tableLayoutPanel_content.Controls.Add(this.btn_get_started, 1, 2);
            this.tableLayoutPanel_content.Controls.Add(this.panel_logo, 0, 0);
            this.tableLayoutPanel_content.Name = "tableLayoutPanel_content";
            // 
            // label_description
            // 
            resources.ApplyResources(this.label_description, "label_description");
            this.label_description.BackColor = System.Drawing.Color.Transparent;
            this.label_description.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.label_description.Name = "label_description";
            // 
            // label_title
            // 
            resources.ApplyResources(this.label_title, "label_title");
            this.label_title.BackColor = System.Drawing.Color.Transparent;
            this.label_title.ForeColor = System.Drawing.Color.White;
            this.label_title.Name = "label_title";
            // 
            // btn_get_started
            // 
            resources.ApplyResources(this.btn_get_started, "btn_get_started");
            this.btn_get_started.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(210)))), ((int)(((byte)(0)))));
            this.btn_get_started.FlatAppearance.BorderSize = 0;
            this.btn_get_started.Name = "btn_get_started";
            this.btn_get_started.UseVisualStyleBackColor = false;
            this.btn_get_started.Click += new System.EventHandler(this.GetStarted);
            // 
            // panel_logo
            // 
            resources.ApplyResources(this.panel_logo, "panel_logo");
            this.panel_logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.panel_logo.Controls.Add(this.img_logo);
            this.panel_logo.Name = "panel_logo";
            this.tableLayoutPanel_content.SetRowSpan(this.panel_logo, 3);
            // 
            // img_logo
            // 
            resources.ApplyResources(this.img_logo, "img_logo");
            this.img_logo.BackColor = System.Drawing.Color.Transparent;
            this.img_logo.Name = "img_logo";
            this.img_logo.TabStop = false;
            // 
            // Welcome
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.Controls.Add(this.tableLayoutPanel_content);
            this.DoubleBuffered = true;
            this.Name = "Welcome";
            this.tableLayoutPanel_content.ResumeLayout(false);
            this.tableLayoutPanel_content.PerformLayout();
            this.panel_logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel Right;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.Button btn_get_started;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_content;
        private System.Windows.Forms.Panel panel_logo;
        private System.Windows.Forms.PictureBox img_logo;
    }
}

