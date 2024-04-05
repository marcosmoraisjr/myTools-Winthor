using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  
    public class EL_Dados
    {

        // cliente
        public Byte[] cliImagem { get; set; }
        public Int32 cliCodigo { get; set; }
        public String cliNome { get; set; }
        public String cliCPFCNPJ { get; set; }


        // endereco
        public String endLogradouro { get; set; }
        public String endNumero { get; set; }
        public String endComplemento { get; set; }
        public String endBairro { get; set; }
        public String endCEP { get; set; }
        public String endCidade { get; set; }
        public String endEstado { get; set; }

        // pedido
        public String pedNumero { get; set; }
        public DateTime pedDataEmissao { get; set; }
        public DateTime pedDataVencimento { get; set; }
        public Decimal pedValor { get; set; }
        public String pedParcelas { get; set; }
    }

}
