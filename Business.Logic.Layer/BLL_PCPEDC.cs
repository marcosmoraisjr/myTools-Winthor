using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data.Access.Layer;

namespace Business.Logic.Layer
{
    public class BLL_PCPEDC
    {
        public void Alterar(EL_PCPEDC _registro, string _filtro)
        {
            //aqui entra os tratamentos necessários
            DAL_PCPEDC cmd = new DAL_PCPEDC();
            cmd.Alterar(_registro, _filtro);
        }
    }
}
