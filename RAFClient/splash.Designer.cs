namespace RAFClient
{
    partial class splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(splash));
            this.versionlabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // versionlabel1
            // 
            this.versionlabel1.AutoSize = true;
            this.versionlabel1.BackColor = System.Drawing.Color.Transparent;
            this.versionlabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionlabel1.ForeColor = System.Drawing.Color.White;
            this.versionlabel1.Location = new System.Drawing.Point(297, 10);
            this.versionlabel1.Margin = new System.Windows.Forms.Padding(0);
            this.versionlabel1.Name = "versionlabel1";
            this.versionlabel1.Size = new System.Drawing.Size(90, 16);
            this.versionlabel1.TabIndex = 0;
            this.versionlabel1.Text = "v 1.60.10.0";
            this.versionlabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RAFClient.Properties.Resources.splash;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.ControlBox = false;
            this.Controls.Add(this.versionlabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "splash";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label versionlabel1;
    }
}