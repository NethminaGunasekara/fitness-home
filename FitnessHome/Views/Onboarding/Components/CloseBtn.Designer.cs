namespace FitnessHome.Views.Onboarding.Components
{
    partial class CloseBtn
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
            tableLayoutPanel1 = new TableLayoutPanel();
            close_btn = new Button();
            draggable_area = new Panel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.Controls.Add(close_btn, 1, 0);
            tableLayoutPanel1.Controls.Add(draggable_area, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(700, 70);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // close_btn
            // 
            close_btn.BackColor = SystemColors.Control;
            close_btn.BackgroundImageLayout = ImageLayout.Zoom;
            close_btn.Cursor = Cursors.Hand;
            close_btn.Dock = DockStyle.Fill;
            close_btn.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 1);
            close_btn.FlatAppearance.MouseDownBackColor = Color.Yellow;
            close_btn.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            close_btn.FlatStyle = FlatStyle.Flat;
            close_btn.Location = new Point(630, 0);
            close_btn.Margin = new Padding(0);
            close_btn.Name = "close_btn";
            close_btn.Size = new Size(70, 70);
            close_btn.TabIndex = 0;
            close_btn.UseVisualStyleBackColor = false;
            close_btn.Click += ExitApplication;
            // 
            // draggable_area
            // 
            draggable_area.Dock = DockStyle.Fill;
            draggable_area.Location = new Point(0, 0);
            draggable_area.Margin = new Padding(0);
            draggable_area.Name = "draggable_area";
            draggable_area.Size = new Size(630, 70);
            draggable_area.TabIndex = 1;
            draggable_area.MouseDown += TitleBar_MouseDown;
            // 
            // CloseBtn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(0);
            Name = "CloseBtn";
            Size = new Size(700, 70);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button close_btn;
        private Panel draggable_area;
    }
}
