namespace RAFClientDemo
{
    partial class clientInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(clientInfo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ClientPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.photoPrev = new System.Windows.Forms.Button();
            this.photoNext = new System.Windows.Forms.Button();
            this.buttOk = new System.Windows.Forms.Button();
            this.buttCancel = new System.Windows.Forms.Button();
            this.buttClose = new System.Windows.Forms.Button();
            this.assetsGridView1 = new System.Windows.Forms.DataGridView();
            this.AssetstoolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.assetRulesdataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.actionDS = new System.Data.DataSet();
            this.RuleAction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Transaction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Field = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Operator = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FieldValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assetsGridView1)).BeginInit();
            this.AssetstoolStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assetRulesdataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionDS)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ClientPropertyGrid);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // ClientPropertyGrid
            // 
            this.ClientPropertyGrid.CausesValidation = false;
            resources.ApplyResources(this.ClientPropertyGrid, "ClientPropertyGrid");
            this.ClientPropertyGrid.Name = "ClientPropertyGrid";
            this.ClientPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.ClientPropertyGrid.ToolbarVisible = false;
            // 
            // photoPrev
            // 
            this.photoPrev.CausesValidation = false;
            this.photoPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.photoPrev, "photoPrev");
            this.photoPrev.Name = "photoPrev";
            this.photoPrev.TabStop = false;
            this.photoPrev.UseVisualStyleBackColor = true;
            // 
            // photoNext
            // 
            this.photoNext.CausesValidation = false;
            this.photoNext.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.photoNext, "photoNext");
            this.photoNext.Name = "photoNext";
            this.photoNext.TabStop = false;
            this.photoNext.UseVisualStyleBackColor = true;
            // 
            // buttOk
            // 
            resources.ApplyResources(this.buttOk, "buttOk");
            this.buttOk.Name = "buttOk";
            this.buttOk.UseVisualStyleBackColor = true;
            // 
            // buttCancel
            // 
            resources.ApplyResources(this.buttCancel, "buttCancel");
            this.buttCancel.Name = "buttCancel";
            this.buttCancel.UseVisualStyleBackColor = true;
            // 
            // buttClose
            // 
            resources.ApplyResources(this.buttClose, "buttClose");
            this.buttClose.Name = "buttClose";
            this.buttClose.UseVisualStyleBackColor = true;
            // 
            // assetsGridView1
            // 
            this.assetsGridView1.AllowUserToAddRows = false;
            this.assetsGridView1.AllowUserToDeleteRows = false;
            this.assetsGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.assetsGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assetsGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            resources.ApplyResources(this.assetsGridView1, "assetsGridView1");
            this.assetsGridView1.Name = "assetsGridView1";
            this.assetsGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.assetsGridView1.SelectionChanged += new System.EventHandler(this.assetsGridView1_SelectionChanged);
            // 
            // AssetstoolStrip
            // 
            resources.ApplyResources(this.AssetstoolStrip, "AssetstoolStrip");
            this.AssetstoolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.AssetstoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.AssetstoolStrip.Name = "AssetstoolStrip";
            // 
            // toolStripButton1
            // 
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.assetAddButton_Click);
            // 
            // toolStripButton2
            // 
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.Name = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
            this.toolStripButton3.Name = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Name = "toolStripButton4";
            resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.HotTrack = true;
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.assetsGridView1);
            this.tabPage1.Controls.Add(this.AssetstoolStrip);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.assetRulesdataGridView);
            this.groupBox2.Controls.Add(this.toolStrip1);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // assetRulesdataGridView
            // 
            this.assetRulesdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assetRulesdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RuleAction,
            this.Transaction,
            this.Field,
            this.Operator,
            this.FieldValue});
            resources.ApplyResources(this.assetRulesdataGridView, "assetRulesdataGridView");
            this.assetRulesdataGridView.Name = "assetRulesdataGridView";
            this.assetRulesdataGridView.ReadOnly = true;
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButton5
            // 
            resources.ApplyResources(this.toolStripButton5, "toolStripButton5");
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.assetRuleAddButton_Click);
            // 
            // toolStripButton6
            // 
            resources.ApplyResources(this.toolStripButton6, "toolStripButton6");
            this.toolStripButton6.Name = "toolStripButton6";
            // 
            // toolStripButton7
            // 
            resources.ApplyResources(this.toolStripButton7, "toolStripButton7");
            this.toolStripButton7.Name = "toolStripButton7";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Name = "toolStripButton8";
            resources.ApplyResources(this.toolStripButton8, "toolStripButton8");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkedListBox1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // checkedListBox1
            // 
            resources.ApplyResources(this.checkedListBox1, "checkedListBox1");
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            resources.GetString("checkedListBox1.Items"),
            resources.GetString("checkedListBox1.Items1"),
            resources.GetString("checkedListBox1.Items2"),
            resources.GetString("checkedListBox1.Items3"),
            resources.GetString("checkedListBox1.Items4"),
            resources.GetString("checkedListBox1.Items5")});
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // actionDS
            // 
            this.actionDS.DataSetName = "actionDataSet";
            // 
            // RuleAction
            // 
            this.RuleAction.Frozen = true;
            resources.ApplyResources(this.RuleAction, "RuleAction");
            this.RuleAction.Name = "RuleAction";
            this.RuleAction.ReadOnly = true;
            // 
            // Transaction
            // 
            resources.ApplyResources(this.Transaction, "Transaction");
            this.Transaction.Items.AddRange(new object[] {
            "Débito",
            "Crédito",
            "Transferencia",
            "Cobro Intereses",
            "Traspaso",
            "Debito Internacional",
            "Crédito Internacional",
            "Transferencia Cuenta Propia",
            "Transferencia Cuenta Autorizada",
            "Pignoración",
            "Consulta de Saldo"});
            this.Transaction.Name = "Transaction";
            this.Transaction.ReadOnly = true;
            this.Transaction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Transaction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Field
            // 
            resources.ApplyResources(this.Field, "Field");
            this.Field.Items.AddRange(new object[] {
            "Monto",
            "Horario",
            "Moneda",
            "Nombre del solicitante",
            "Identificación del solicitante",
            "Nombre del destinatario",
            "Identificación del destinatario",
            "Monto Acumulado Periodo",
            "Num Transacciones Periodo",
            "Método de Indentificación",
            "Localización",
            "Derecho"});
            this.Field.Name = "Field";
            this.Field.ReadOnly = true;
            // 
            // Operator
            // 
            resources.ApplyResources(this.Operator, "Operator");
            this.Operator.Items.AddRange(new object[] {
            "Igual A",
            "No Igual A",
            "Mayor A",
            "Menor A",
            "Mayor O Igual A",
            "Menor O Igual A",
            "Entre"});
            this.Operator.Name = "Operator";
            this.Operator.ReadOnly = true;
            // 
            // FieldValue
            // 
            resources.ApplyResources(this.FieldValue, "FieldValue");
            this.FieldValue.Name = "FieldValue";
            this.FieldValue.ReadOnly = true;
            this.FieldValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FieldValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clientInfo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttClose);
            this.Controls.Add(this.buttCancel);
            this.Controls.Add(this.buttOk);
            this.Controls.Add(this.photoNext);
            this.Controls.Add(this.photoPrev);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "clientInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.clientInfo_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.assetsGridView1)).EndInit();
            this.AssetstoolStrip.ResumeLayout(false);
            this.AssetstoolStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assetRulesdataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button photoPrev;
        private System.Windows.Forms.Button photoNext;
        private System.Windows.Forms.Button buttOk;
        private System.Windows.Forms.Button buttCancel;
        private System.Windows.Forms.Button buttClose;
        private System.Windows.Forms.PropertyGrid ClientPropertyGrid;
        private System.Windows.Forms.ToolStrip AssetstoolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.DataGridView assetsGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView assetRulesdataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Data.DataSet actionDS;
        private System.Windows.Forms.DataGridViewComboBoxColumn RuleAction;
        private System.Windows.Forms.DataGridViewComboBoxColumn Transaction;
        private System.Windows.Forms.DataGridViewComboBoxColumn Field;
        private System.Windows.Forms.DataGridViewComboBoxColumn Operator;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldValue;
    }
}