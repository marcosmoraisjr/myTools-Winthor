using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Entity;

namespace Data.Access.Layer
{
    /*internal class DAL_PCCARREG
    {
    }*/

    public class DAL_PCCARREG
    {
        /// <summary>
        /// UPDATE 
        /// </summary>
        /// <param name="PCCARREG"></param>
        /// public void executarUpdade(registro, filtro)
        public void Alterar(EL_PCCARREG registro, string _filtro)
        {
            var connectionString = DAL_Connection.StringConnection;
            var query = new StringBuilder();
            query.Append("update pccarreg set ");
            query.Append("numviasmapa=0 ");
            query.Append("where 1=1 ");
            query.Append("and numcar in (" + _filtro + ")");
            using (var connection = new OracleConnection(connectionString))
            {
                using (var command = new OracleCommand(query.ToString(), connection))
                {
                    command.Parameters.Add("@numcar", registro.numcar);
                    command.Connection.Open();
                    int resultado = command.ExecuteNonQuery();
                    if (resultado < 1)
                    {
                        throw new Exception("Não foi possível alterar o registro." + registro.numcar.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Método CRUD(SELECT, INSERT, UPDADE E DELETE).
        /// UPDATE
        /// </summary>
        /// <param name="PCCARREG"></param>
        /// public void executarUpdade(registro)
        public void executarUpdade(EL_PCCARREG registro)
        {
            var connect = DAL_Connection.StringConnection;
            var query = new StringBuilder();
            query.Append("update pccarreg set ");
            query.Append(" numviasmapa=0 ");
            query.Append(" where 1=1 ");
            query.Append(" and numcar in ('" + registro.numcar + "')");
            using (var connection = new OracleConnection(connect))
            {
                using (var command = new OracleCommand(query.ToString(), connection))
                {
                    //cmd.CommandType = CommandType.Text;
                    command.Parameters.Add("@numcar", registro.numcar);
                    command.Connection.Open();
                    int resultado = command.ExecuteNonQuery();
                    if (resultado < 1)
                    {
                        throw new Exception("Não foi possível alterar o registro."+ registro.numcar.ToString());
                    }
                }
            }
        }
    }
}
