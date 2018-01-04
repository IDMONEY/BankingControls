using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace RAFClient
{
    public partial class Main : Form
    {
       //Start Logger
       private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Main()
        {
            InitializeComponent();
            log.Info("Start App");
            log.Debug("This is a DEBUG level message. Typically your most VERBOSE level.");
/*
            bioLogin bl = new bioLogin();
            bl.Show();
*/            
            //Show Splash Screen
            splash sp = new splash();
            sp.Show(this);

            //Check DB Access
            MySqlConnection mysqlCon = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbConnectionRAFSecurity"].ConnectionString);
            try
            {
                mysqlCon.Open();
            }
            catch (Exception ex)
            {
                log.Fatal("No se puede connectar a base de datos de usuarios.", ex);
                MessageBox.Show("No se puede connectar a base de datos de usuarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (mysqlCon.State.ToString() != "Open")
            {
                System.Environment.Exit(-1);
            }

            //Check version compatibility
            bool isDBok = false;
            string validDBversion = "";

            try
            {
                validDBversion = commonMethods.GetSetting("SecurityDBVersion", "1.1.0.0");
                string selectStr = "SELECT * FROM system";
                MySqlCommand mysqlCmd = new MySqlCommand(selectStr, mysqlCon);
                MySqlDataReader mysqlReader = mysqlCmd.ExecuteReader();
                while (mysqlReader.Read())
                {
                    mysqlReader.GetString("dbversion");
                }


            }
            catch (Exception ex)
            {
                log.Error("No se puede obtener la versión de la base de datos de usuarios", ex);

            }
            finally
            {
                mysqlCon.Close();
            }
            if (!isDBok)
            {
                MessageBox.Show("Esta versión del cliente no es compatible con la base de datos de usuarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(-1);
            }
            //Show Login Form
            Login loginForm = new Login();
            loginForm.ShowDialog();
            if (!loginForm.GetStatus())
            { System.Environment.Exit(-1); }
 
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

    }
}
