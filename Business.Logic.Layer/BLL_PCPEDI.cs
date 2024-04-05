using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data.Access.Layer;

namespace Business.Logic.Layer
{
    public class BLL_PCPEDI
    {
        public void Alterar(EL_PCPEDI _registro, string _filtro)
        {
            //aqui entra os tratamentos necessários
            DAL_PCPEDI cmd = new DAL_PCPEDI();
            cmd.Alterar(_registro, _filtro);
        }
    }
}
