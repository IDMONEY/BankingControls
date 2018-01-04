using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RAFClientDemo
{
    public partial class bioFinger : Form
    {
        public bioFinger(string finger)
        {
            InitializeComponent();
            label1.Text = "A continuación debe de registrar sus huellas digitales.\n\n";
            label1.Text += "1. Coloque el dedo firmemente en el\n    lector sin aplicar demasiada presión.\n";
            label1.Text += "2. Presione el botón 'Leer Huella'.\n";

            switch (finger)
            { 
                case "right":
                    rightFinger.Checked = true;
                    leftFinger.Enabled = false;
                    break;
                case "left":
                    leftFinger.Checked = true;
                    rightFinger.Enabled = false;
                    break;

            }

        }

        public bioFinger()
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //start
            Cursor.Current = Cursors.WaitCursor;
            progressBar1.Visible = true;
            work.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee; 
            progressBar1.MarqueeAnimationSpeed = 500;

            timer1.Interval = 3000;
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(OnTimerEvent);


            
        }

        public void OnTimerEvent(object source, EventArgs e)
        {
            //stop
            work.Visible = false;
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.MarqueeAnimationSpeed = 0;
            Cursor.Current = Cursors.Default;
            progressBar1.Visible = false;
            timer1.Stop();
            timer1.Dispose();

            MessageBox.Show("Huella recibida", "RAF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
