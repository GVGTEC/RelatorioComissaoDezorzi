using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioComissaoDezorzi
{
    public class DadosRelatorio
    {
        public string Periodo { get; set; }
        public int LancamentoId { get; set; }
        public int SeguradoId { get; set; }
        public string SeguradoNome { get; set; }
        public int CompanhiaId { get; set; }
        public string CompanhiaNome { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal ValorPremioLiquido{ get; set; }
        public decimal ValorComissão { get; set; }
        public string NossoNumero { get; set; }
        public string NumeroCompanhia { get; set; }
        public string Fatura { get; set; }

        public int ProdutorId_01 { get; set; }
        public string ProdutorNome_01 { get; set; }
        public string ComissãoPC_01 { get; set; }
        public decimal ValorComissão_01 { get; set; }

        public int ProdutorId_02 { get; set; }
        public string ProdutorNome_02 { get; set; }
        public string ComissãoPC_02 { get; set; }
        public decimal ValorComissão_02 { get; set; }

        public int ProdutorId_03 { get; set; }
        public string ProdutorNome_03 { get; set; }
        public string ComissãoPC_03 { get; set; }
        public decimal ValorComissão_03 { get; set; }

        public int ProdutorId_04 { get; set; }
        public string ProdutorNome_04 { get; set; }
        public string ComissãoPC_04 { get; set; }
        public decimal ValorComissão_04 { get; set; }

        public int ProdutorId_05 { get; set; }
        public string ProdutorNome_05 { get; set; }
        public string ComissãoPC_05 { get; set; }
        public decimal ValorComissão_05 { get; set; }
    }
}
