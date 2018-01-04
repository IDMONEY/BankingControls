namespace RAFClientDemo
{
    partial class bioFinger
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bioFinger));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.rightFinger = new System.Windows.Forms.RadioButton();
            this.leftFinger = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.work = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RAFClientDemo.Properties.Resources.fp1;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.UseWaitCursor = true;
            // 
            // rightFinger
            // 
            resources.ApplyResources(this.rightFinger, "rightFinger");
            this.rightFinger.Checked = true;
            this.rightFinger.Name = "rightFinger";
            this.rightFinger.TabStop = true;
            this.rightFinger.Tag = "";
            this.rightFinger.UseVisualStyleBackColor = true;
            // 
            // leftFinger
            // 
            resources.ApplyResources(this.leftFinger, "leftFinger");
            this.leftFinger.Name = "leftFinger";
            this.leftFinger.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.MaximumSize = new System.Drawing.Size(198, 147);
            this.label1.Name = "label1";
            // 
            // work
            // 
            resources.ApplyResources(this.work, "work");
            this.work.Name = "work";
            // 
            // bioFinger
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.work);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.leftFinger);
            this.Controls.Add(this.rightFinger);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "bioFinger";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.ProgressBar progressBar1;
        protected System.Windows.Forms.RadioButton rightFinger;
        protected System.Windows.Forms.RadioButton leftFinger;
        protected System.Windows.Forms.Button button1;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label work;
        private System.Windows.Forms.Timer timer1;
    }
}