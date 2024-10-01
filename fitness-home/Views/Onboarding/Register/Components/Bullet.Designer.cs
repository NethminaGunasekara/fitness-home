namespace fitness_home.Views.Onboarding.Register.Components
{
    partial class Bullet
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
            this.pictureBox_bullet = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bullet)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_bullet
            // 
            this.pictureBox_bullet.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_bullet.BackgroundImage = global::fitness_home.Properties.Resources.list_item;
            this.pictureBox_bullet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_bullet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_bullet.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_bullet.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_bullet.Name = "pictureBox_bullet";
            this.pictureBox_bullet.Size = new System.Drawing.Size(7, 26);
            this.pictureBox_bullet.TabIndex = 0;
            this.pictureBox_bullet.TabStop = false;
            // 
            // Bullet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox_bullet);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Bullet";
            this.Size = new System.Drawing.Size(7, 26);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bullet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_bullet;
    }
}
