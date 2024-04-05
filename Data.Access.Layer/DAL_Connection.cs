using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using Oracle.ManagedDataAccess.Client; //responsável pela comunicação com a base Oracle

namespace Data.Access.Layer
{
    public class DAL_Connection
    {
        public static string StringConnection
        {
            get
            {
                try
                {
                    return @"Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.10.200)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = WINT))); User Id = barreto; Password = brt995to";
                    //return @"Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.10.101)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = TESTE))); User Id = TESTE; Password = TESTE";
                    //var connectionString = ConfigurationManager.ConnectionStrings["UI.Properties.Settings.ConnectionStringTeste"].ConnectionString;
                    //var splitters = connectionString.Split(';');
                    //return connectionString;
                }
                catch
                {
                    throw new Exception("Não foi possível acessar o servidor informado nos parametros.");
                }
            }
        }

        public static OracleConnection GetConnection()
        {
            string connection = ConfigurationManager.AppSettings["ROTA"].ToString();
            return new OracleConnection(connection);
        }

        
    }

    public class OracleConexion
    {
        protected string strOracle = string.Empty;
        public OracleConexion()
        {
            strOracle = ConfigurationManager.ConnectionStrings["ROTA"].ConnectionString;
        }
    }

}
