using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Oracle.ManagedDataAccess.Client;

//Declarar a referência para a dll de data types do oracle
//using Oracle.DataAccess.Types;
//Declarar a referência para o client do oracle
//using Oracle.DataAccess.Client;
//using System.Data.OleDb;
//using System.Data.Odbc;

namespace Data.Access.Layer
{
    public class DAL
    {
        /// <summary>
        /// MARCOS:
        /// Seleciona todos os registros passados por query e retorna um DataTable.
        /// </summary>
        /// <param name="filtro da consulta</param>
        /// <returns>DataTable</returns>
        public DataTable FindByQuery(string _query)
        {
            var connectionString = DAL_Connection.StringConnection;
            var data = new DataTable();
            using (var conn = new OracleConnection(connectionString))
            {
                using (var cmd = new OracleCommand(_query.ToString(), conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (var da = new OracleDataAdapter(cmd))
                    {
                        try
                        {
                            da.Fill(data);
                            return data;
                        } catch
                        {
                            data = new DataTable();
                            return data;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// MARCOS:
        /// Seleciona todos os registros passados por query e retorna um DataTable.
        /// </summary>
        /// <param name="filtro da consulta</param>
        /// <returns>DataSet</returns>
        public DataSet FindByQueryDs(string _query)
        {
            var connect = DAL_Connection.StringConnection;
            var data = new DataSet();
            using (var conn = new OracleConnection(connect))
            {
                using (var cmd = new OracleCommand(_query.ToString(), conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (var lista = new OracleDataAdapter(cmd))
                    {
                        lista.Fill(data);
                        return data;
                    }
                }
            }
        }

        public DataSet SqlDataSet(string comandoSQL)
        {
            OracleConnection conexao = new OracleConnection();
            conexao.ConnectionString = DAL_Connection.StringConnection;
            OracleCommand comando = conexao.CreateCommand();
            comando.CommandText = comandoSQL;
            OracleDataAdapter lista = new OracleDataAdapter(comando);
            DataSet Data = new DataSet();
            lista.Fill(Data);
            return Data;
        }
        public DataTable SqlDataTable(string comandoSQL)
        {
            OracleConnection conexao = new OracleConnection();
            conexao.ConnectionString = DAL_Connection.StringConnection;
            OracleCommand comando = conexao.CreateCommand();
            comando.CommandText = comandoSQL;
            OracleDataAdapter lista = new OracleDataAdapter(comando);
            DataTable Data = new DataTable();
            lista.Fill(Data);
            return Data;
        }
    }
}
