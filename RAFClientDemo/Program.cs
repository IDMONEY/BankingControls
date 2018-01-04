using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RAFClientDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Initial Form
            MDIParent1 m = new MDIParent1();
            m.TopLevel = true;            
            Application.Run(m);
        }
    }
}
