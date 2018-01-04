using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;

namespace RAFClientDemo
{
    class commonMethods
    {
        public static string GetSetting(string Setting, string Default)
        {
            string value = "";
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings[Setting] != null)
                {
                    value = System.Configuration.ConfigurationManager.AppSettings[Setting];
                }
                if (value == "")
                {
                    value = Default;
                }
            }
            catch (Exception ex)
            {
                value = Default;
            }
            return value;
        }

        public static void ClearForm(System.Windows.Forms.Control parent)
        {
            foreach (System.Windows.Forms.Control ctrControl in parent.Controls)
            {
                //Loop through all controls 
                if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.TextBox)))
                {
                    //Check to see if it's a textbox 
                    ((System.Windows.Forms.TextBox)ctrControl).Text = string.Empty;
                    //If it is then set the text to String.Empty (empty textbox) 
                }
                if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.MaskedTextBox)))
                {
                    //Check to see if it's a maskedtextbox 
                    ((System.Windows.Forms.MaskedTextBox)ctrControl).Text = string.Empty;
                    //If it is then set the text to String.Empty (empty textbox) 
                }
                else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.RichTextBox)))
                {
                    //If its a RichTextBox clear the text
                    ((System.Windows.Forms.RichTextBox)ctrControl).Text = string.Empty;
                }
                else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.ComboBox)))
                {
                    //Next check if it's a dropdown list 
                    ((System.Windows.Forms.ComboBox)ctrControl).SelectedIndex = -1;
                    //If it is then set its SelectedIndex to 0 
                }
                else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.CheckBox)))
                {
                    //Next uncheck all checkboxes
                    ((System.Windows.Forms.CheckBox)ctrControl).Checked = false;
                }
                else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.RadioButton)))
                {
                    //Unselect all RadioButtons
                    ((System.Windows.Forms.RadioButton)ctrControl).Checked = false;
                }
                if (ctrControl.Controls.Count > 0)
                {
                    //Call itself to get all other controls in other containers 
                    ClearForm(ctrControl);
                }
            }
        }

        public static DataTable getGuiDSData(string node)
        {
            DataSet ds = new DataSet();
            try
            {
                XmlNode selFields = MDIParent1.guiFieldsXml.SelectSingleNode("/guiFields/" + node);
                using (XmlNodeReader xnr = new XmlNodeReader(selFields))
                {
                    ds.ReadXml(xnr);
                }
                DataRow emptyRow = ds.Tables[0].NewRow(); ;
                ds.Tables[0].Rows.InsertAt(emptyRow, 0);

            }
            catch (Exception x)
            {
                DataTable dt = new DataTable("fields");
                ds.Tables.Add(dt); 
               
                x.Message.Trim();
            }
            return ds.Tables[0];
        }
  


        public int insertLog()
        {
            int entry;
            entry = 0;
            return entry;
        }
    }
}
