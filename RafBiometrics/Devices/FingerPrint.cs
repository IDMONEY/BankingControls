using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.IO;

namespace RafBiometrics.Devices
{
    class FingerPrint
    {


        public object getFingerPrint()
        {
            Suprema.SFR sfr = new Suprema.SFR();
            bool returnvalue = sfr.Initialize();
            sfr.Sensor = Suprema.SFR.SensorType.SFR300V2;

            if (!sfr.IsSensorOn()){
                lblMsg.Text = "El lector se encuentra desconectado";
                sfr.Uninitialize();
                return;
            }

            bool boolValid = false;

            while (!boolValid) {
                dialog = MessageBox.Show("Por favor ponga el dedo en el lector.",
					            "Ponga el dedo en el lector", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dialog.Equals(DialogResult.Cancel)){
	            return;
                }

                temptemplate1 = sfr.ScanTemplate(false, false);

                while (sfr.IsFingerOn())
                {
	            dialog = MessageBox.Show("Por favor retire el dedo. Y vuelvalo a colocar.",
					            "Ponga el dedo en el lector", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
	            if(dialog.Equals(DialogResult.Cancel)){
	                return;
	            }
                }

                temptemplate2 = sfr.ScanTemplate(false, false);

                boolValid = sfr.MatchTemplate(temptemplate1, temptemplate2);

                if(!boolValid){
	            dialog = MessageBox.Show("Sus huellas no concuerdan. Por favor recuerde poner el dedo centrado en el lector en ambas ocaciones.",
					            "Ponga el dedo en el lector", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
	            if (dialog.Equals(DialogResult.Cancel)) {
	                return;
	            }
                }
            }

            // Si llega hasta aqui es porque las huellas coinciden.
            // Ahora hay que enviarla al server

            String strFileName = "c:\\huella.xml";

            // Escribe el archivo
            FileStream fileStream = File.Create(strFileName);
            XmlSerializer xmlSerializer =
	                  new XmlSerializer(typeof(Template), "Template");
            xmlSerializer.Serialize(fileStream, new Template(temptemplate1));
            fileStream.Close();

            // Leer el archivo 
	            //StreamReader fp = File.OpenText(strFileName);
            TextReader tr = new StreamReader(strFileName);
            String strTemplate = tr.ReadToEnd();
            // Crear un objeto Template    
            //Template oTemplate = (Template) xmlSerializer.Deserialize(tr);
            tr.Close(); 
            }

    }
}
