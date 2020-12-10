using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioComissaoDezorzi
{
    public class TotaisRelatorio
    {
        public decimal TotalPremioLiquido1{ get; set; }
        public decimal TotalPremioLiquido2 { get; set; }
        public decimal ComissoesRecebidas { get; set; }
        public decimal ComissoesEstornadas { get; set; }
        public decimal ComissoesProdutores1 { get; set; }
        public decimal ComissoesProdutores2 { get; set; }
    }
}
