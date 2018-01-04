namespace RAFClientDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.userLabel = new System.Windows.Forms.Label();
            this.userBox = new System.Windows.Forms.TextBox();
            this.pwdLabel = new System.Windows.Forms.Label();
            this.pwdBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userLabel
            // 
            resources.ApplyResources(this.userLabel, "userLabel");
            this.userLabel.Name = "userLabel";
            // 
            // userBox
            // 
            resources.ApplyResources(this.userBox, "userBox");
            this.userBox.Name = "userBox";
            // 
            // pwdLabel
            // 
            resources.ApplyResources(this.pwdLabel, "pwdLabel");
            this.pwdLabel.Name = "pwdLabel";
            // 
            // pwdBox
            // 
            resources.ApplyResources(this.pwdBox, "pwdBox");
            this.pwdBox.Name = "pwdBox";
            // 
            // LoginButton
            // 
            this.LoginButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.LoginButton, "LoginButton");
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.ExitButton, "ExitButton");
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.LoginButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ExitButton;
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.pwdBox);
            this.Controls.Add(this.pwdLabel);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.userLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.Label pwdLabel;
        private System.Windows.Forms.TextBox pwdBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button ExitButton;
    }
}