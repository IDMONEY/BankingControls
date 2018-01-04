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
    public partial class clientAdd : Form
    {
        private int newCustomerID;
        public clientAdd()
        {
            InitializeComponent();


            try
            {

                //ID type
                idType.Items.Clear();
                idType.DataSource = commonMethods.getGuiDSData("customeridtypes");
                idType.DisplayMember = "text";
                idType.ValueMember = "value";

                //issueCountry
                issueCountry.Items.Clear();
                issueCountry.DataSource = commonMethods.getGuiDSData("countries");
                issueCountry.DisplayMember = "text";
                issueCountry.ValueMember = "value";

                //Languages
                lang.Items.Clear();
                lang.DataSource = commonMethods.getGuiDSData("languages");
                lang.DisplayMember = "text";
                lang.ValueMember = "value";
            }
            catch (Exception x)
            {
                x.Message.Trim();
            }





            


        }

        private void idType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (idType.SelectedIndex)
            {
                case 1:
                    idNum.Mask = "0-0000-0000";
                    idNum.PromptChar = '_';
                    //Show Persons Name
                    lName.Show();
                    tName1.Show();
                    lNameM.Show();
                    tName2.Show();
                    lSurname1.Show();
                    tSName1.Show();
                    lSurname2.Show();
                    tSName2.Show();
                    //Hide Company Info
                    lcompName.Hide();
                    compName.Hide();

                    break;
                //Company
                case 2:
                    //Clear Mask for id num
                    idNum.Mask = "";
                    idNum.PromptChar = ' ';
                    //Disable Persons Name
                    lName.Hide();
                    tName1.Hide();
                    lNameM.Hide();
                    tName2.Hide();
                    lSurname1.Hide();
                    tSName1.Hide();
                    lSurname2.Hide();
                    tSName2.Hide();
                    //ShowCompany Info
                    lcompName.Show();
                    compName.Show();


                    break;
                case 3:
                    idNum.Mask = "";
                    idNum.PromptChar = ' ';
                    break;
                case 4:
                    idNum.Mask = "";
                    idNum.PromptChar = ' ';
                    break;
                case 5:
                    idNum.Mask = "";
                    idNum.PromptChar = ' ';
                    break;  
                default:
                    idNum.Mask = "";
                    idNum.PromptChar = ' ';
                    //Show Persons Name
                    lName.Show();
                    tName1.Show();
                    lNameM.Show();
                    tName2.Show();
                    lSurname1.Show();
                    tSName1.Show();
                    lSurname2.Show();
                    tSName2.Show();
                    //Hide Company Info
                    lcompName.Hide();
                    compName.Hide();

                    break;  
            }           
        }

        private void btRegFgRight_Click(object sender, EventArgs e)
        {
            bioFinger getFg = new bioFinger("right");
            getFg.Show(this);
            btRegFgRight.Enabled = false;
        }

        private void btRegFgLeft_Click(object sender, EventArgs e)
        {
            bioFinger getFg = new bioFinger("left");
            getFg.Show(this);
            btRegFgLeft.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Create xml to Post
            XmlDocument param = new XmlDocument();
            //Create xml to Collect
            XmlDocument resp = new XmlDocument();
            //Svc
            RAFClientDemo.RafProxy.RAFProxy rproxy = new RAFClientDemo.RafProxy.RAFProxy();
            param.LoadXml(rproxy.CustomerInsertParams().OuterXml);

            //Populate
            param.SelectSingleNode("/Params/Profile").Attributes["Value"].Value = "1";
            param.SelectSingleNode("/Params/Password").Attributes["Value"].Value = passphrase.Text;
            param.SelectSingleNode("/Params/Photo").Attributes["Value"].Value = "";
            param.SelectSingleNode("/Params/FingerRight").Attributes["Value"].Value = "c2974e78fbfd1a134b2420bd0aaba573";
            param.SelectSingleNode("/Params/FingerLeft").Attributes["Value"].Value = "c2974e78fbfd1a134b2420bd0aaba573";
            param.SelectSingleNode("/Params/IDNumber").Attributes["Value"].Value = idNum.Text;
            param.SelectSingleNode("/Params/IDType").Attributes["Value"].Value = ((System.Data.DataRowView)(idType.SelectedItem)).Row.ItemArray[0].ToString();
            param.SelectSingleNode("/Params/IDCountry").Attributes["Value"].Value = ((System.Data.DataRowView)(issueCountry.SelectedItem)).Row.ItemArray[0].ToString();
            param.SelectSingleNode("/Params/FirstName").Attributes["Value"].Value = tName1.Text;
            param.SelectSingleNode("/Params/MiddleName").Attributes["Value"].Value = tName2.Text;
            param.SelectSingleNode("/Params/SurName1").Attributes["Value"].Value = tSName1.Text;
            param.SelectSingleNode("/Params/SurName2").Attributes["Value"].Value = tSName2.Text;
            param.SelectSingleNode("/Params/Suffix").Attributes["Value"].Value = "";
            param.SelectSingleNode("/Params/Country").Attributes["Value"].Value = ((System.Data.DataRowView)(issueCountry.SelectedItem)).Row.ItemArray[0].ToString();
            param.SelectSingleNode("/Params/Registrar").Attributes["Value"].Value = "1";
            param.SelectSingleNode("/Params/CompanyName").Attributes["Value"].Value = compName.Text;

            resp.LoadXml(rproxy.CustomerInsert(param).OuterXml);
            
            Cursor.Current = Cursors.Default;

            if (resp.SelectSingleNode("/CustomerInsert/Status/ErrMsg").InnerText != "")
            {
                MessageBox.Show(resp.SelectSingleNode("/CustomerInsert/Status/ErrMsg").InnerText, "Error", MessageBoxButtons.OK);
            }
            else
            {
                newCustomerID = Convert.ToInt32(resp.SelectSingleNode("/CustomerInsert/CustomerID").InnerText);
            }


            clientInfo cliForm = new clientInfo(newCustomerID);
            cliForm.MdiParent = this.MdiParent;
            cliForm.Show();
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
