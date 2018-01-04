using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using System.Xml;

namespace RAFClientDemo
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        //Start Logger
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       
        //GUI fields for pulldowns fetched from WS at startup
        public static XmlDocument guiFieldsXml = new XmlDocument();

        public MDIParent1()
        {
            string curCulture = Properties.Settings.Default.mainCulture;
            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(curCulture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(curCulture);
            this.IsMdiContainer = true;

            InitializeComponent();


            //Show Splash Screen
            splash sp = new splash();
            sp.Show(this);

            //Check WS Access
            bool ws = false;
            try
            {
                RAFClientDemo.RafProxy.RAFProxy rproxy = new RAFClientDemo.RafProxy.RAFProxy();
                ws = rproxy.testDBCnx();
            }
            catch (Exception ex)
            {
                ex.Message.Trim();
            }

            if (!ws)
            {
                if (MessageBox.Show("No se puede connectar a base de datos de usuarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    System.Environment.Exit(-1);
                }
            }

            //Show Login Form and exit if failed
            sp.showLoginForm();


            //Fetch GUI fields
            getGuiFields();

        }

        private void getGuiFields()
        {
            int lang = 0;
            string regID;
            string regKey;
            try
            {
                regID = ""; // System.Configuration.ConfigurationManager.AppSettings["registrarID"];
                regKey = ""; // System.Configuration.ConfigurationManager.AppSettings["registrarKey"];   
                RAFClientDemo.RafProxy.RAFProxy wsX = new RAFClientDemo.RafProxy.RAFProxy();
                string te = wsX.guiGetFieldsByLanguage(lang, regID, regKey).OuterXml;
                guiFieldsXml.LoadXml(wsX.guiGetFieldsByLanguage(lang,regID,regKey).OuterXml);
            }
            catch(Exception x)
            {
                x.Message.Trim();
            }
        }

        //private void ShowNewForm(object sender, EventArgs e)
        //{
        //    Form childForm = new Form();
        //    childForm.MdiParent = this;
        //    childForm.Text = "Window " + childFormNumber++;
        //    childForm.Show();
        //}

        //private void OpenFile(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        //    if (openFileDialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        string FileName = openFileDialog.FileName;
        //    }
        //}

        //private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        //    if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        string FileName = saveFileDialog.FileName;
        //    }
        //}

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

  
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void enrollClientButton_Click(object sender, EventArgs e)
        {
            clientAdd caForm = new clientAdd();
            caForm.MdiParent = this;
            caForm.Show();
        }
        
        private void endUserSession()
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar la sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                endUserSession();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butClientSearch_Click(object sender, EventArgs e)
        {
            clientSearch cSearchForm = new clientSearch();
            cSearchForm.MdiParent = this;
            cSearchForm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aForm = new AboutBox();
            aForm.MdiParent = this;
            aForm.Show();
        }



    }
}
