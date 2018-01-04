using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RAFClientDemo
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        bool programStatus;

        private void Login_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.userLabel.Text = "Usuario";
            this.pwdLabel.Text = "Clave";
            this.LoginButton.Text = "Iniciar";
            this.ExitButton.Text = "Salir";
            this.pwdBox.UseSystemPasswordChar = true;

        }

        public bool GetStatus()
        {
            return programStatus;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = userBox.Text;
            string password = pwdBox.Text;

            if ( (username == "") || (password == "") )
            {
                MessageBox.Show("Datos Imcompletos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool status=CheckUserNameAndPassword(username, password);
                if (status)
                {
                    programStatus = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Credenciales Incorrectas");
                }
            }
        }

        private bool CheckUserNameAndPassword(string username, string password)
        {
            bool success = false;
            //
            if ((username == "demo") && (password == "demo"))
            {
                success = true;
            }
            //
            return success;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(-1);
        }


    }
}
