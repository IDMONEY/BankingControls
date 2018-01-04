using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RAFClientDemo
{
    public partial class bioLogin : RAFClientDemo.bioFinger
    {
        public bioLogin()
        {
            InitializeComponent();
            label1.Text = "A continuación debe de demostrar su identidad biometricamente por medio de una de sus huellas digitales  registradas.\n\n";
            label1.Text += "1. Elija si va a utilizar su dedo índice\n    derecho o izquierdo.\n";
            label1.Text += "2. Coloque el dedo firmemente en el\n    lector sin aplicar demasiada presión.\n";
            label1.Text += "3. Presione el botón 'Leer Huella'.\n";

        }
    }
}
