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
    public class DAL_PCPEDC
    {
        /// <summary>
        /// UPDATE 
        /// </summary>
        /// <param name="PCPEDC"></param>
        public void Alterar(EL_PCPEDC _registro, string _filtro)
        {
            var myExecuteQuery = new StringBuilder();
            myExecuteQuery.Append("update pcpedc set ");
            myExecuteQuery.Append("codfilialnf= :codfilialnf ");
            myExecuteQuery.Append("where 1=1 ");
            myExecuteQuery.Append("and pcpedc.codfilial in(3, 53) ");
            myExecuteQuery.Append("and pcpedc.posicao in('B','P') ");
            myExecuteQuery.Append("and numped in ('" + _filtro + "')");

            var connectionString = DAL_Connection.StringConnection;
            using (var connection = new OracleConnection(connectionString))
            {
                using (var command = new OracleCommand(myExecuteQuery.ToString(), connection))
                {
                    command.Parameters.Add("@codfilialnf", _registro.codfilialnf);
                    command.Connection.Open();
                    int resultado = command.ExecuteNonQuery();
                    if (resultado < 1)
                    {
                        throw new Exception("Não foi possível salvar a alteração do registro. O número de registros afetados foi " + resultado.ToString());
                    }
                }
            }
        }
    }

}
