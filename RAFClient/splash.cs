using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace RAFClient
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
         
            //get version info
            string objVersion = Application.ProductVersion.ToString();
            objVersion = objVersion.Replace(".0", "");
            versionlabel1.Text = "v. " + objVersion;

       }
    }
}
