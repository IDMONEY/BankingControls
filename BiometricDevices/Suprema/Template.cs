using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace PrivatePropertyRegistry
{
    // Se declara serializable
    [XmlRootAttribute("Template", Namespace = "", IsNullable = false)]
    public class Template : ISerializable
    {
        // Este campo: 'DateTimeValue' sera un atributo del nodo raiz
        [XmlAttributeAttribute(DataType = "date")]
        public System.DateTime DateTimeValue;

        // Array para almacenar el template   
        [XmlElementAttribute("Huella")]
        public byte[] arrTemplate = new byte[384];
        
        // Constructor vacio, indispensable para la serializacion
        public Template() { }

        // Constructor
        public Template(byte[] newTemplate) {
            this.arrTemplate = newTemplate;
        }

        // Constructor de Deserialisacion
        public Template(SerializationInfo info, StreamingContext ctxt)
        {
            // Obtener las variables de info y asignarlas a los atributos de la clase
            arrTemplate = (byte[])info.GetValue("arrTemplate", typeof(byte[]));
        }
        
        // Funcion de Serialisation
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("arrTemplate", arrTemplate);
        }
    }
}
