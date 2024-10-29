namespace fitness_home.Views.Onboarding.Register.Components
{
    partial class MembershipCard
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
            this.tableLayoutPanel_content = new System.Windows.Forms.TableLayoutPanel();
            this.panel_plan_name = new System.Windows.Forms.Panel();
            this.label_plan_name = new System.Windows.Forms.Label();
            this.panel_plan_fee = new System.Windows.Forms.Panel();
            this.flowLayoutPanel_fee = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_plan_fee_currency = new System.Windows.Forms.Panel();
            this.label_plan_fee_currency = new System.Windows.Forms.Label();
            this.label_plan_fee = new System.Windows.Forms.Label();
            this.panel_plan_fee_per = new System.Windows.Forms.Panel();
            this.label_plan_fee_per = new System.Windows.Forms.Label();
            this.panel_benefits_title = new System.Windows.Forms.Panel();
            this.label_plan_benefits_title = new System.Windows.Forms.Label();
            this.panel_benefits = new System.Windows.Forms.Panel();
            this.plan_benefits = new System.Windows.Forms.Label();
            this.tableLayoutPanel_content.SuspendLayout();
            this.panel_plan_name.SuspendLayout();
            this.panel_plan_fee.SuspendLayout();
            this.flowLayoutPanel_fee.SuspendLayout();
            this.panel_plan_fee_currency.SuspendLayout();
            this.panel_plan_fee_per.SuspendLayout();
            this.panel_benefits_title.SuspendLayout();
            this.panel_benefits.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_content
            // 
            this.tableLayoutPanel_content.ColumnCount = 1;
            this.tableLayoutPanel_content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_content.Controls.Add(this.panel_plan_name, 0, 0);
            this.tableLayoutPanel_content.Controls.Add(this.panel_plan_fee, 0, 1);
            this.tableLayoutPanel_content.Controls.Add(this.panel_benefits_title, 0, 2);
            this.tableLayoutPanel_content.Controls.Add(this.panel_benefits, 0, 3);
            this.tableLayoutPanel_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_content.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_content.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_content.Name = "tableLayoutPanel_content";
            this.tableLayoutPanel_content.RowCount = 4;
            this.tableLayoutPanel_content.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel_content.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel_content.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel_content.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_content.Size = new System.Drawing.Size(532, 741);
            this.tableLayoutPanel_content.TabIndex = 0;
            this.tableLayoutPanel_content.Click += new System.EventHandler(this.OnClick);
            // 
            // panel_plan_name
            // 
            this.panel_plan_name.BackColor = System.Drawing.Color.Transparent;
            this.panel_plan_name.Controls.Add(this.label_plan_name);
            this.panel_plan_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_plan_name.Location = new System.Drawing.Point(0, 0);
            this.panel_plan_name.Margin = new System.Windows.Forms.Padding(0);
            this.panel_plan_name.Name = "panel_plan_name";
            this.panel_plan_name.Size = new System.Drawing.Size(532, 90);
            this.panel_plan_name.TabIndex = 0;
            this.panel_plan_name.Click += new System.EventHandler(this.OnClick);
            // 
            // label_plan_name
            // 
            this.label_plan_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_plan_name.AutoSize = true;
            this.label_plan_name.Font = new System.Drawing.Font("Noto Sans", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_plan_name.ForeColor = System.Drawing.Color.White;
            this.label_plan_name.Location = new System.Drawing.Point(29, 49);
            this.label_plan_name.Name = "label_plan_name";
            this.label_plan_name.Size = new System.Drawing.Size(201, 53);
            this.label_plan_name.TabIndex = 0;
            this.label_plan_name.Text = "Individual";
            this.label_plan_name.Click += new System.EventHandler(this.OnClick);
            // 
            // panel_plan_fee
            // 
            this.panel_plan_fee.BackColor = System.Drawing.Color.Transparent;
            this.panel_plan_fee.Controls.Add(this.flowLayoutPanel_fee);
            this.panel_plan_fee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_plan_fee.Location = new System.Drawing.Point(0, 90);
            this.panel_plan_fee.Margin = new System.Windows.Forms.Padding(0);
            this.panel_plan_fee.Name = "panel_plan_fee";
            this.panel_plan_fee.Size = new System.Drawing.Size(532, 70);
            this.panel_plan_fee.TabIndex = 1;
            this.panel_plan_fee.Click += new System.EventHandler(this.OnClick);
            // 
            // flowLayoutPanel_fee
            // 
            this.flowLayoutPanel_fee.Controls.Add(this.panel_plan_fee_currency);
            this.flowLayoutPanel_fee.Controls.Add(this.label_plan_fee);
            this.flowLayoutPanel_fee.Controls.Add(this.panel_plan_fee_per);
            this.flowLayoutPanel_fee.Location = new System.Drawing.Point(33, 27);
            this.flowLayoutPanel_fee.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel_fee.Name = "flowLayoutPanel_fee";
            this.flowLayoutPanel_fee.Size = new System.Drawing.Size(320, 43);
            this.flowLayoutPanel_fee.TabIndex = 4;
            this.flowLayoutPanel_fee.WrapContents = false;
            this.flowLayoutPanel_fee.Click += new System.EventHandler(this.OnClick);
            // 
            // panel_plan_fee_currency
            // 
            this.panel_plan_fee_currency.Controls.Add(this.label_plan_fee_currency);
            this.panel_plan_fee_currency.Location = new System.Drawing.Point(3, 3);
            this.panel_plan_fee_currency.Name = "panel_plan_fee_currency";
            this.panel_plan_fee_currency.Size = new System.Drawing.Size(20, 43);
            this.panel_plan_fee_currency.TabIndex = 1;
            this.panel_plan_fee_currency.Click += new System.EventHandler(this.OnClick);
            // 
            // label_plan_fee_currency
            // 
            this.label_plan_fee_currency.AutoSize = true;
            this.label_plan_fee_currency.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_plan_fee_currency.ForeColor = System.Drawing.Color.White;
            this.label_plan_fee_currency.Location = new System.Drawing.Point(-1, 0);
            this.label_plan_fee_currency.Margin = new System.Windows.Forms.Padding(0);
            this.label_plan_fee_currency.Name = "label_plan_fee_currency";
            this.label_plan_fee_currency.Size = new System.Drawing.Size(28, 28);
            this.label_plan_fee_currency.TabIndex = 2;
            this.label_plan_fee_currency.Text = "Rs";
            this.label_plan_fee_currency.UseCompatibleTextRendering = true;
            this.label_plan_fee_currency.Click += new System.EventHandler(this.OnClick);
            // 
            // label_plan_fee
            // 
            this.label_plan_fee.AutoSize = true;
            this.label_plan_fee.Font = new System.Drawing.Font("Roboto", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_plan_fee.ForeColor = System.Drawing.Color.White;
            this.label_plan_fee.Location = new System.Drawing.Point(26, 0);
            this.label_plan_fee.Margin = new System.Windows.Forms.Padding(0);
            this.label_plan_fee.Name = "label_plan_fee";
            this.label_plan_fee.Size = new System.Drawing.Size(113, 49);
            this.label_plan_fee.TabIndex = 1;
            this.label_plan_fee.Text = "3990";
            this.label_plan_fee.UseCompatibleTextRendering = true;
            this.label_plan_fee.Click += new System.EventHandler(this.OnClick);
            // 
            // panel_plan_fee_per
            // 
            this.panel_plan_fee_per.Controls.Add(this.label_plan_fee_per);
            this.panel_plan_fee_per.Location = new System.Drawing.Point(142, 3);
            this.panel_plan_fee_per.Name = "panel_plan_fee_per";
            this.panel_plan_fee_per.Size = new System.Drawing.Size(35, 43);
            this.panel_plan_fee_per.TabIndex = 0;
            this.panel_plan_fee_per.Click += new System.EventHandler(this.OnClick);
            // 
            // label_plan_fee_per
            // 
            this.label_plan_fee_per.AutoSize = true;
            this.label_plan_fee_per.Font = new System.Drawing.Font("Noto Sans Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_plan_fee_per.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.label_plan_fee_per.Location = new System.Drawing.Point(-3, 14);
            this.label_plan_fee_per.Margin = new System.Windows.Forms.Padding(0);
            this.label_plan_fee_per.Name = "label_plan_fee_per";
            this.label_plan_fee_per.Size = new System.Drawing.Size(32, 31);
            this.label_plan_fee_per.TabIndex = 3;
            this.label_plan_fee_per.Text = "/m";
            this.label_plan_fee_per.UseCompatibleTextRendering = true;
            this.label_plan_fee_per.Click += new System.EventHandler(this.OnClick);
            // 
            // panel_benefits_title
            // 
            this.panel_benefits_title.BackColor = System.Drawing.Color.Transparent;
            this.panel_benefits_title.Controls.Add(this.label_plan_benefits_title);
            this.panel_benefits_title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_benefits_title.Location = new System.Drawing.Point(0, 160);
            this.panel_benefits_title.Margin = new System.Windows.Forms.Padding(0);
            this.panel_benefits_title.Name = "panel_benefits_title";
            this.panel_benefits_title.Size = new System.Drawing.Size(532, 60);
            this.panel_benefits_title.TabIndex = 2;
            this.panel_benefits_title.Click += new System.EventHandler(this.OnClick);
            // 
            // label_plan_benefits_title
            // 
            this.label_plan_benefits_title.AutoSize = true;
            this.label_plan_benefits_title.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_plan_benefits_title.ForeColor = System.Drawing.Color.White;
            this.label_plan_benefits_title.Location = new System.Drawing.Point(33, 23);
            this.label_plan_benefits_title.Margin = new System.Windows.Forms.Padding(0);
            this.label_plan_benefits_title.Name = "label_plan_benefits_title";
            this.label_plan_benefits_title.Size = new System.Drawing.Size(169, 28);
            this.label_plan_benefits_title.TabIndex = 2;
            this.label_plan_benefits_title.Text = "This plan includes:";
            this.label_plan_benefits_title.UseCompatibleTextRendering = true;
            this.label_plan_benefits_title.Click += new System.EventHandler(this.OnClick);
            // 
            // panel_benefits
            // 
            this.panel_benefits.BackColor = System.Drawing.Color.Transparent;
            this.panel_benefits.Controls.Add(this.plan_benefits);
            this.panel_benefits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_benefits.Location = new System.Drawing.Point(0, 220);
            this.panel_benefits.Margin = new System.Windows.Forms.Padding(0);
            this.panel_benefits.Name = "panel_benefits";
            this.panel_benefits.Size = new System.Drawing.Size(532, 521);
            this.panel_benefits.TabIndex = 3;
            this.panel_benefits.Click += new System.EventHandler(this.OnClick);
            // 
            // plan_benefits
            // 
            this.plan_benefits.Font = new System.Drawing.Font("Noto Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plan_benefits.ForeColor = System.Drawing.Color.White;
            this.plan_benefits.Location = new System.Drawing.Point(34, 14);
            this.plan_benefits.Margin = new System.Windows.Forms.Padding(0);
            this.plan_benefits.Name = "plan_benefits";
            this.plan_benefits.Size = new System.Drawing.Size(498, 507);
            this.plan_benefits.TabIndex = 8;
            this.plan_benefits.Text = "⦿ All Gym Facilities\r\n⦿ Supplement Offers\r\n⦿ Diet and nutrition plan\r\n⦿ Strength," +
    " Functional, Cardio Training\r\n⦿ Free Wi-Fi and Parking\r\n⦿ Monthly progress repor" +
    "t";
            this.plan_benefits.Click += new System.EventHandler(this.OnClick);
            // 
            // MembershipCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.tableLayoutPanel_content);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MembershipCard";
            this.Size = new System.Drawing.Size(532, 741);
            this.Load += new System.EventHandler(this.MembershipCard_Load);
            this.tableLayoutPanel_content.ResumeLayout(false);
            this.panel_plan_name.ResumeLayout(false);
            this.panel_plan_name.PerformLayout();
            this.panel_plan_fee.ResumeLayout(false);
            this.flowLayoutPanel_fee.ResumeLayout(false);
            this.flowLayoutPanel_fee.PerformLayout();
            this.panel_plan_fee_currency.ResumeLayout(false);
            this.panel_plan_fee_currency.PerformLayout();
            this.panel_plan_fee_per.ResumeLayout(false);
            this.panel_plan_fee_per.PerformLayout();
            this.panel_benefits_title.ResumeLayout(false);
            this.panel_benefits_title.PerformLayout();
            this.panel_benefits.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_content;
        private System.Windows.Forms.Panel panel_plan_name;
        private System.Windows.Forms.Panel panel_plan_fee;
        private System.Windows.Forms.Panel panel_benefits_title;
        private System.Windows.Forms.Label label_plan_name;
        private System.Windows.Forms.Label label_plan_fee;
        private System.Windows.Forms.Label label_plan_fee_currency;
        private System.Windows.Forms.Label label_plan_fee_per;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_fee;
        private System.Windows.Forms.Panel panel_plan_fee_per;
        private System.Windows.Forms.Panel panel_plan_fee_currency;
        private System.Windows.Forms.Label label_plan_benefits_title;
        private System.Windows.Forms.Panel panel_benefits;
        private System.Windows.Forms.Label plan_benefits;
    }
}
