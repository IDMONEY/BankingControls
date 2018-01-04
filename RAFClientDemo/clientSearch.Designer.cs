namespace RAFClientDemo
{
    partial class clientSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(clientSearch));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.idNum = new System.Windows.Forms.MaskedTextBox();
            this.idType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.surname2 = new System.Windows.Forms.TextBox();
            this.surname1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.companyname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridResults = new System.Windows.Forms.DataGridView();
            this.butSearch = new System.Windows.Forms.Button();
            this.butReset = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.DSClientSearch = new System.Data.DataSet();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSClientSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.idNum);
            this.groupBox1.Controls.Add(this.idType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.surname2);
            this.groupBox1.Controls.Add(this.surname1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.companyname);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.fName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterios de Búsqueda";
            // 
            // idNum
            // 
            this.idNum.Location = new System.Drawing.Point(234, 141);
            this.idNum.Name = "idNum";
            this.idNum.Size = new System.Drawing.Size(101, 20);
            this.idNum.TabIndex = 6;
            // 
            // idType
            // 
            this.idType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.idType.FormattingEnabled = true;
            this.idType.Location = new System.Drawing.Point(83, 141);
            this.idType.Name = "idType";
            this.idType.Size = new System.Drawing.Size(95, 21);
            this.idType.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(7, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tipo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(184, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Número";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Identificación";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nombre";
            // 
            // surname2
            // 
            this.surname2.Location = new System.Drawing.Point(212, 65);
            this.surname2.Name = "surname2";
            this.surname2.Size = new System.Drawing.Size(123, 20);
            this.surname2.TabIndex = 3;
            // 
            // surname1
            // 
            this.surname1.Location = new System.Drawing.Point(83, 65);
            this.surname1.Name = "surname1";
            this.surname1.Size = new System.Drawing.Size(123, 20);
            this.surname1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Apellidos";
            // 
            // companyname
            // 
            this.companyname.Location = new System.Drawing.Point(83, 91);
            this.companyname.Name = "companyname";
            this.companyname.Size = new System.Drawing.Size(252, 20);
            this.companyname.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Razón Social";
            // 
            // fName
            // 
            this.fName.Location = new System.Drawing.Point(83, 39);
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(123, 20);
            this.fName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // dataGridResults
            // 
            this.dataGridResults.AllowUserToAddRows = false;
            this.dataGridResults.AllowUserToDeleteRows = false;
            this.dataGridResults.AllowUserToResizeRows = false;
            this.dataGridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResults.Location = new System.Drawing.Point(12, 217);
            this.dataGridResults.MultiSelect = false;
            this.dataGridResults.Name = "dataGridResults";
            this.dataGridResults.ReadOnly = true;
            this.dataGridResults.Size = new System.Drawing.Size(347, 175);
            this.dataGridResults.TabIndex = 7;
            this.dataGridResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridResults_CellDoubleClick);
            // 
            // butSearch
            // 
            this.butSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butSearch.Image = ((System.Drawing.Image)(resources.GetObject("butSearch.Image")));
            this.butSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.butSearch.Location = new System.Drawing.Point(80, 186);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(66, 25);
            this.butSearch.TabIndex = 1;
            this.butSearch.Text = "Buscar";
            this.butSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butSearch.UseVisualStyleBackColor = true;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // butReset
            // 
            this.butReset.Image = ((System.Drawing.Image)(resources.GetObject("butReset.Image")));
            this.butReset.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.butReset.Location = new System.Drawing.Point(152, 186);
            this.butReset.Name = "butReset";
            this.butReset.Size = new System.Drawing.Size(66, 25);
            this.butReset.TabIndex = 2;
            this.butReset.Text = "Limpiar";
            this.butReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butReset.UseVisualStyleBackColor = true;
            this.butReset.Click += new System.EventHandler(this.butReset_Click);
            // 
            // butClose
            // 
            this.butClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butClose.Image = ((System.Drawing.Image)(resources.GetObject("butClose.Image")));
            this.butClose.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.butClose.Location = new System.Drawing.Point(224, 186);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(66, 25);
            this.butClose.TabIndex = 3;
            this.butClose.Text = "Salir";
            this.butClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // DSClientSearch
            // 
            this.DSClientSearch.DataSetName = "NewDataSet";
            this.DSClientSearch.Locale = new System.Globalization.CultureInfo("es-CR");
            // 
            // clientSearch
            // 
            this.AcceptButton = this.butSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butClose;
            this.ClientSize = new System.Drawing.Size(371, 416);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butReset);
            this.Controls.Add(this.butSearch);
            this.Controls.Add(this.dataGridResults);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "clientSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de Clientes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSClientSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox fName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox surname1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox surname2;
        private System.Windows.Forms.TextBox companyname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox idNum;
        private System.Windows.Forms.ComboBox idType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridResults;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.Button butReset;
        private System.Windows.Forms.Button butClose;
        private System.Data.DataSet DSClientSearch;
    }
}