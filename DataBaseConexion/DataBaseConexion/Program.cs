using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DataBaseConexion
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            DataBaseConnection DBC = new DataBaseConnection();
            DBC.SetConnectionString("Data Source=ERICK-PC;Initial Catalog=SeguridadRAF;Integrated Security=True");
            DBC.OpenConnection();
            List<Object> list = DBC.ExecuteProcedures("Exec sp_SearchForGroups ''", 3);
            Console.WriteLine((int)list[0]);
            Console.WriteLine((String)list[1]);
            Console.WriteLine((String)list[2]);
        }
    }
}
