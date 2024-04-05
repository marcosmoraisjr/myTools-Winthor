using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data.Access.Layer;
using System.Data;

/// <summary>
/// BLL(Business Logic Layer)
/// Descrição.: Responsável pelos métodos com as regras de negócio
/// Autor.....: Marcos Morais de Sousa
/// Data......: 14/10/2011
/// Email.....: mmstec@gmail.com
/// </summary>
namespace Business.Logic.Layer
{
    public class BLL_Curinga
    {

        /// <summary>
        /// MARCOS:
        /// Seleciona todos os registros passados por query e retorna um DataTable..
        /// </summary>
        /// <param name="filtro da consulta</param>
        /// <returns>DataTable</returns>
        public DataTable FindByQuery(string _query)
        {
            DAL cmd = new DAL();
            return cmd.FindByQuery(_query);
        }

        public DataTable SqlDataTable(string _query)
        {
            DAL cmd = new DAL();
            return cmd.SqlDataTable(_query);
        }

    }


}
