using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace RAFClientDemo
{
    public partial class clientSearch : Form
    {
        public clientSearch()
        {
            InitializeComponent();

            //ID type
            idType.Items.Clear();
            idType.DataSource = commonMethods.getGuiDSData( "customeridtypes");
            idType.DisplayMember = "text";
            idType.ValueMember = "value";
        }

        private void butSearch_Click(object sender, EventArgs e)
        {

            if (!validForm())
            {
                return;
            }
            
            RAFClientDemo.RafProxy.RAFProxy rproxy = new RAFClientDemo.RafProxy.RAFProxy();
            XmlDocument paramCall = new XmlDocument();

            try
            {
                paramCall.LoadXml(rproxy.CustomerSearchParams().OuterXml);

                if (fName.Text != "")
                {
                    paramCall.SelectSingleNode("Params/FirstName").Attributes["Value"].Value = fName.Text;
                }
                if (surname1.Text != "")
                {
                    paramCall.SelectSingleNode("Params/SurName1").Attributes["Value"].Value = surname1.Text;
                }
                if (surname2.Text != "")
                {
                    paramCall.SelectSingleNode("Params/Surname2").Attributes["Value"].Value = surname2.Text;
                }
                if (companyname.Text != "")
                {
                    paramCall.SelectSingleNode("Params/CompanyName").Attributes["Value"].Value = companyname.Text;
                }
                if (idType.Text != "")
                {
                    paramCall.SelectSingleNode("Params/IDType").Attributes["Value"].Value = ((System.Data.DataRowView)(idType.SelectedItem)).Row.ItemArray[0].ToString();
                }
                if (idNum.Text != "")
                {
                    paramCall.SelectSingleNode("Params/IDNumber").Attributes["Value"].Value = idNum.Text;
                }

                DSClientSearch = rproxy.CustomerSearch(paramCall);

                if (DSClientSearch.Tables[0].Rows.Count > 0)
                {
                    BindingSource dbBindSource = new BindingSource();
                    dbBindSource.DataSource = DSClientSearch.Tables[0];
                    dataGridResults.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                    dataGridResults.ReadOnly = true;
                    dataGridResults.DataSource = dbBindSource;

                    ///////// 
                    // Format
                    ///////// 

                    //Headers
                    dataGridResults.Columns["CustID"].Visible = false;
                    dataGridResults.Columns["CustName"].HeaderText = "Nombre";
                    dataGridResults.Columns["CustIDNumber"].HeaderText = "Identificación";
                    
                    //Grid
                    dataGridResults.AllowUserToResizeColumns = true;
                    dataGridResults.ReadOnly = true;
                    dataGridResults.RowHeadersVisible = false;
                    dataGridResults.AutoSize = true;

                    //Columns
                    dataGridResults.Columns["CustName"].Width = 174;
                    dataGridResults.Columns["CustIDNumber"].Width = 173;
                    dataGridResults.Columns["CustName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridResults.Columns["CustIDNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                }
                dataGridResults.Refresh();
            }
            catch(Exception x)
            {

            }

        }

        private void butReset_Click(object sender, EventArgs e)
        {
            commonMethods.ClearForm(this);
            dataGridResults.DataSource = null;
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validForm()
        {
            bool r = true;
            //Req Fields
            if (
                fName.Text == "" && 
                surname1.Text == "" &&
                surname2.Text == "" &&
                companyname.Text == "" &&
                idType.Text == "" &&
                idNum.Text == ""
              )
            {
                MessageBox.Show("Para buscar un cliente debe escribir el nombre o el número de identificación .", "Datos Invalidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                r = false;
            }            
            
            //Name
            if(
                ((fName.Text!="")&&(surname1.Text==""))||
                ((surname1.Text!="")&&(fName.Text==""))
              )
            {
                MessageBox.Show("Para buscar por nombre debe ingresar el nombre y al menos el primer apellido.", "Datos Invalidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                r = false;            
            }

            //ID
            if ((idNum.Text != "") && (idType.Text == ""))
            {
                MessageBox.Show("Para buscar por número de identificación, debe seleccionar un tipo de identificación.", "Datos Invalidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                r = false;
            }
            return r;
        }

        private void dataGridResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int custid = (int)dataGridResults.Rows[e.RowIndex].Cells[0].Value;
                clientInfo cliForm = new clientInfo(custid);
                cliForm.FormClosed += new FormClosedEventHandler(clientInfo_FormClosed); //add handler to catch when CustInfo form is closed
                this.Hide();
                cliForm.MdiParent = this.MdiParent;
                cliForm.Show();
            }
            catch (Exception x)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error(x.Message);            
            }
            

        }

        private void clientInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            //when custinfo form is closed, the search reappears
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }


    }
}
