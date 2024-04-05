using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data.Access.Layer;

namespace Business.Logic.Layer
{
    /*internal class BLL_PCCARREG
    {
    }*/

    public class BLL_PCCARREG
    {
        public void Alterar(EL_PCCARREG _registro, string _filtro)
        {
            //aqui entra os tratamentos necessários
            DAL_PCCARREG cmd = new DAL_PCCARREG();
            cmd.Alterar(_registro, _filtro);
        }

        public void executarUpdate(EL_PCCARREG registro)
        {
            DAL_PCCARREG cmd = new DAL_PCCARREG();
            cmd.executarUpdade(registro);
        }
    }
}
