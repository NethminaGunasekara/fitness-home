﻿namespace fitness_home.Views.Messages
{
    partial class ApplicationError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationError));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_message = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.error_heading = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_heading = new System.Windows.Forms.TableLayoutPanel();
            this.label_error = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_try_again = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.error_heading.SuspendLayout();
            this.tableLayoutPanel_heading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label_message, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_title, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.error_heading, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 240);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_message
            // 
            this.label_message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_message.AutoSize = true;
            this.label_message.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_message.Font = new System.Drawing.Font("Noto Sans", 10.5F);
            this.label_message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.label_message.Location = new System.Drawing.Point(0, 123);
            this.label_message.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(400, 22);
            this.label_message.TabIndex = 5;
            this.label_message.Text = "We apologize for the inconvenience";
            this.label_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_title
            // 
            this.label_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_title.AutoSize = true;
            this.label_title.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_title.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.Color.White;
            this.label_title.Location = new System.Drawing.Point(0, 95);
            this.label_title.Margin = new System.Windows.Forms.Padding(0, 8, 0, 4);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(400, 24);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "Unable to connect to the database";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // error_heading
            // 
            this.error_heading.Controls.Add(this.tableLayoutPanel_heading);
            this.error_heading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.error_heading.Location = new System.Drawing.Point(0, 0);
            this.error_heading.Margin = new System.Windows.Forms.Padding(0);
            this.error_heading.Name = "error_heading";
            this.error_heading.Size = new System.Drawing.Size(400, 87);
            this.error_heading.TabIndex = 3;
            // 
            // tableLayoutPanel_heading
            // 
            this.tableLayoutPanel_heading.ColumnCount = 4;
            this.tableLayoutPanel_heading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_heading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_heading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_heading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_heading.Controls.Add(this.label_error, 2, 0);
            this.tableLayoutPanel_heading.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel_heading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_heading.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_heading.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_heading.Name = "tableLayoutPanel_heading";
            this.tableLayoutPanel_heading.RowCount = 1;
            this.tableLayoutPanel_heading.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_heading.Size = new System.Drawing.Size(400, 87);
            this.tableLayoutPanel_heading.TabIndex = 2;
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.BackColor = System.Drawing.Color.Transparent;
            this.label_error.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_error.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_error.Font = new System.Drawing.Font("Noto Sans", 16F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.label_error.Location = new System.Drawing.Point(114, 49);
            this.label_error.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(209, 34);
            this.label_error.TabIndex = 1;
            this.label_error.Text = "Application Error!";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(77, 51);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_try_again);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 81);
            this.panel1.TabIndex = 4;
            // 
            // button_try_again
            // 
            this.button_try_again.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button_try_again.FlatAppearance.BorderSize = 0;
            this.button_try_again.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_try_again.Font = new System.Drawing.Font("Noto Sans", 11F, System.Drawing.FontStyle.Bold);
            this.button_try_again.ForeColor = System.Drawing.Color.White;
            this.button_try_again.Location = new System.Drawing.Point(117, 8);
            this.button_try_again.Margin = new System.Windows.Forms.Padding(0);
            this.button_try_again.Name = "button_try_again";
            this.button_try_again.Size = new System.Drawing.Size(156, 33);
            this.button_try_again.TabIndex = 0;
            this.button_try_again.Text = "Exit Application";
            this.button_try_again.UseVisualStyleBackColor = false;
            this.button_try_again.Click += new System.EventHandler(this.button_try_again_Click);
            // 
            // ApplicationError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(400, 240);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApplicationError";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.DatabaseError_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.error_heading.ResumeLayout(false);
            this.tableLayoutPanel_heading.ResumeLayout(false);
            this.tableLayoutPanel_heading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Panel error_heading;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_error;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_try_again;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_heading;
        private System.Windows.Forms.Label label_message;
    }
}