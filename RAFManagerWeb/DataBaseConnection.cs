using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Collections.Generic;

   public class DataBaseConnection
    {
       private SqlConnection _Connection;
       private String _ConnectionString;
       private int _Usage = 0;
       public DataBaseConnection()
       {
       }

       private void ConnectToDatabase(String pConnectionString){
           if (_Connection == null && _Usage == 0)
           {
               _Usage = 1;
               if (_Connection == null)
               {
                   _ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["rafMainConnectionString"].ConnectionString;
                   _Connection = new SqlConnection(pConnectionString); 
               }
           }
       }

       public void OpenConnection()
       {
           if (_Connection == null)
           {
               ConnectToDatabase(_ConnectionString);
           }
           _Connection.Open();
           _Usage = 2;
       }

       public void CloseConnection()
       {
           _Usage = 1;
           _Connection.Close();
       }

       public void SetConnectionString(String pConnectionString)
       {
           _ConnectionString = pConnectionString;
       }
       
       public String GetConnectionString()
       {
           return _ConnectionString;
       }

       public List<Object> ExecuteProcedures(String pProcedure, int pNumberOfReturnedColums)
       {
           SqlCommand _cmd = new SqlCommand(pProcedure, _Connection);
           List<Object> _result = new List<object>();
           try
           {
               SqlDataReader _reader = _cmd.ExecuteReader();
               while (_reader.Read())
               {
                   for (int i = 0; i < pNumberOfReturnedColums; i++)
                   {
                       _result.Add(_reader[i]);
                   }
               }
               _reader.Close();
               return _result;
           }
           catch (Exception ex)
           {
               _result = null;
               return _result;
           }
           
       }

    }
