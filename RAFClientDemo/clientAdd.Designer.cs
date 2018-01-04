namespace RAFClientDemo
{
    partial class clientAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(clientAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.idType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tName1 = new System.Windows.Forms.TextBox();
            this.lNameM = new System.Windows.Forms.Label();
            this.tName2 = new System.Windows.Forms.TextBox();
            this.tSName1 = new System.Windows.Forms.TextBox();
            this.tSName2 = new System.Windows.Forms.TextBox();
            this.lSurname1 = new System.Windows.Forms.Label();
            this.lSurname2 = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lang = new System.Windows.Forms.ComboBox();
            this.issueCountry = new System.Windows.Forms.ComboBox();
            this.idNum = new System.Windows.Forms.MaskedTextBox();
            this.lLang = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lcompName = new System.Windows.Forms.Label();
            this.compName = new System.Windows.Forms.TextBox();
            this.credentials = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btRegFgLeft = new System.Windows.Forms.Button();
            this.fgRight = new System.Windows.Forms.Label();
            this.btRegFgRight = new System.Windows.Forms.Button();
            this.passphrase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.credentials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // idType
            // 
            this.idType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.idType.FormattingEnabled = true;
            resources.ApplyResources(this.idType, "idType");
            this.idType.Name = "idType";
            this.idType.SelectedIndexChanged += new System.EventHandler(this.idType_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tName1
            // 
            resources.ApplyResources(this.tName1, "tName1");
            this.tName1.Name = "tName1";
            // 
            // lNameM
            // 
            resources.ApplyResources(this.lNameM, "lNameM");
            this.lNameM.Name = "lNameM";
            // 
            // tName2
            // 
            resources.ApplyResources(this.tName2, "tName2");
            this.tName2.Name = "tName2";
            // 
            // tSName1
            // 
            resources.ApplyResources(this.tSName1, "tSName1");
            this.tSName1.Name = "tSName1";
            // 
            // tSName2
            // 
            resources.ApplyResources(this.tSName2, "tSName2");
            this.tSName2.Name = "tSName2";
            // 
            // lSurname1
            // 
            resources.ApplyResources(this.lSurname1, "lSurname1");
            this.lSurname1.Name = "lSurname1";
            // 
            // lSurname2
            // 
            resources.ApplyResources(this.lSurname2, "lSurname2");
            this.lSurname2.Name = "lSurname2";
            // 
            // lName
            // 
            resources.ApplyResources(this.lName, "lName");
            this.lName.Name = "lName";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lang);
            this.groupBox1.Controls.Add(this.issueCountry);
            this.groupBox1.Controls.Add(this.idNum);
            this.groupBox1.Controls.Add(this.lLang);
            this.groupBox1.Controls.Add(this.idType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lang
            // 
            this.lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lang.FormattingEnabled = true;
            resources.ApplyResources(this.lang, "lang");
            this.lang.Name = "lang";
            // 
            // issueCountry
            // 
            this.issueCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.issueCountry.FormattingEnabled = true;
            resources.ApplyResources(this.issueCountry, "issueCountry");
            this.issueCountry.Name = "issueCountry";
            // 
            // idNum
            // 
            resources.ApplyResources(this.idNum, "idNum");
            this.idNum.Name = "idNum";
            // 
            // lLang
            // 
            resources.ApplyResources(this.lLang, "lLang");
            this.lLang.Name = "lLang";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tName2);
            this.groupBox2.Controls.Add(this.tSName1);
            this.groupBox2.Controls.Add(this.lcompName);
            this.groupBox2.Controls.Add(this.tName1);
            this.groupBox2.Controls.Add(this.lSurname1);
            this.groupBox2.Controls.Add(this.tSName2);
            this.groupBox2.Controls.Add(this.lSurname2);
            this.groupBox2.Controls.Add(this.lNameM);
            this.groupBox2.Controls.Add(this.lName);
            this.groupBox2.Controls.Add(this.compName);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // lcompName
            // 
            resources.ApplyResources(this.lcompName, "lcompName");
            this.lcompName.Name = "lcompName";
            // 
            // compName
            // 
            resources.ApplyResources(this.compName, "compName");
            this.compName.Name = "compName";
            // 
            // credentials
            // 
            this.credentials.Controls.Add(this.label5);
            this.credentials.Controls.Add(this.btRegFgLeft);
            this.credentials.Controls.Add(this.fgRight);
            this.credentials.Controls.Add(this.btRegFgRight);
            this.credentials.Controls.Add(this.passphrase);
            this.credentials.Controls.Add(this.label4);
            resources.ApplyResources(this.credentials, "credentials");
            this.credentials.Name = "credentials";
            this.credentials.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // btRegFgLeft
            // 
            resources.ApplyResources(this.btRegFgLeft, "btRegFgLeft");
            this.btRegFgLeft.Name = "btRegFgLeft";
            this.btRegFgLeft.UseVisualStyleBackColor = true;
            this.btRegFgLeft.Click += new System.EventHandler(this.btRegFgLeft_Click);
            // 
            // fgRight
            // 
            resources.ApplyResources(this.fgRight, "fgRight");
            this.fgRight.Name = "fgRight";
            // 
            // btRegFgRight
            // 
            resources.ApplyResources(this.btRegFgRight, "btRegFgRight");
            this.btRegFgRight.Name = "btRegFgRight";
            this.btRegFgRight.UseVisualStyleBackColor = true;
            this.btRegFgRight.Click += new System.EventHandler(this.btRegFgRight_Click);
            // 
            // passphrase
            // 
            resources.ApplyResources(this.passphrase, "passphrase");
            this.passphrase.Name = "passphrase";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // clientAdd
            // 
            this.AcceptButton = this.button1;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.Controls.Add(this.credentials);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "clientAdd";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.credentials.ResumeLayout(false);
            this.credentials.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox idType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tName1;
        private System.Windows.Forms.Label lNameM;
        private System.Windows.Forms.TextBox tName2;
        private System.Windows.Forms.TextBox tSName1;
        private System.Windows.Forms.TextBox tSName2;
        private System.Windows.Forms.Label lSurname1;
        private System.Windows.Forms.Label lSurname2;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox idNum;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox compName;
        private System.Windows.Forms.Label lcompName;
        private System.Windows.Forms.ComboBox issueCountry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox credentials;
        private System.Windows.Forms.TextBox passphrase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btRegFgRight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btRegFgLeft;
        private System.Windows.Forms.Label fgRight;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox lang;
        private System.Windows.Forms.Label lLang;
    }
}