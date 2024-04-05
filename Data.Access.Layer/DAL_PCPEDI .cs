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
    public class DAL_PCPEDI
    {
        /// <summary>
        /// UPDATE 
        /// </summary>
        /// <param name="PCPEDI"></param>
        public void Alterar(EL_PCPEDI _registro, string _filtro)
        {
            var myExecuteQuery = new StringBuilder();
            myExecuteQuery.Append("update pcpedi set ");
            myExecuteQuery.Append("codfilialretira= :codfilialretira ");
            myExecuteQuery.Append("where 1=1 ");
            myExecuteQuery.Append("and pcpedi.codfilialretira in(3, 53) ");
            myExecuteQuery.Append("and pcpedi.posicao in('B','P') ");
            myExecuteQuery.Append("and pcpedi.numped in ('" + _filtro + "')");

            var connectionString = DAL_Connection.StringConnection;
            using (var connection = new OracleConnection(connectionString))
            {
                using (var command = new OracleCommand(myExecuteQuery.ToString(), connection))
                {
                    command.Parameters.Add("@codfilialretira", _registro.codfilialretira);
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
