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
    public partial class assetAdd : Form
    {
        int customer = 0;

        public assetAdd(int CustomerID)
        {
            if (CustomerID != 0)
            {
              customer = CustomerID;
            }
            InitializeComponent();





            //ID type
            assetType.Items.Clear();
            assetType.DataSource = commonMethods.getGuiDSData("assets");
            assetType.DisplayMember = "text";
            assetType.ValueMember = "value";









            


        }

        private void idType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (assetType.SelectedIndex)
            {
                default:
                    break;  
            }           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //Create xml to Post
                XmlDocument param = new XmlDocument();
                //Create xml to Collect
                XmlDocument resp = new XmlDocument();
                //Svc
                RAFClientDemo.RafProxy.RAFProxy rproxy = new RAFClientDemo.RafProxy.RAFProxy();
                param.LoadXml(rproxy.AssetInsertParams().OuterXml);

                param.SelectSingleNode("/Params/CustID").Attributes["Value"].Value = customer.ToString();
                param.SelectSingleNode("/Params/IDType").Attributes["Value"].Value = ((System.Data.DataRowView)(assetType.SelectedItem)).Row.ItemArray[0].ToString();
                param.SelectSingleNode("/Params/IDNumber").Attributes["Value"].Value = idNum.Text;

                resp.LoadXml(rproxy.AssetInsert(param).OuterXml);

                Cursor.Current = Cursors.Default;

                if (resp.SelectSingleNode("/AssetInsert/Status/ErrMsg").InnerText != "")
                {
                    MessageBox.Show(resp.SelectSingleNode("/AssetInsert/Status/ErrMsg").InnerText, "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception x)
            {
                x.Message.Trim();
            }            


            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
