using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Reporting.WinForms;

namespace RelatorioComissaoDezorzi
{
    public partial class Form1 : Form
    {
        static string empresa;
        static string linha;
        static string resultado;
        static string imprimirtotais;

        static decimal valor;

        List<DadosRelatorio> listadados = new List<DadosRelatorio>();
        List<TotaisRelatorio> listatotais = new List<TotaisRelatorio>();

        public Form1()
        {
            InitializeComponent();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    this.reportViewer1.RefreshReport();
        //}

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            //List<DadosRelatorio> listadados = new List<DadosRelatorio>();

            //StreamReader sr1 = new StreamReader("C:\\SACTRM\\LANCA.TXT");
            //StreamReader sr2 = new StreamReader("C:\\SACTRM\\TOTAIS.TXT");

            StreamReader sr1 = new StreamReader("C:\\LANCA1.TXT");
            StreamReader sr2 = new StreamReader("C:\\TOTAIS.TXT");

            while ((linha = sr1.ReadLine()) != null)
            {
                Processa1(linha);

                if (resultado != "")
                {
                    //listadados.Add(resultado);
                }
            }

            while ((linha = sr2.ReadLine()) != null)
            {
                Processa2(linha);

                if (resultado != "")
                {
                    //listadados.Add(resultado);
                }
            }

            //var DadosRelatorio = (from item in listadados
            //                      select new DadosRelatorio()
            //                      {
            //                          //OrdemProducaoId = int.Parse(listadados[0]),
            //                          //DescricaoProduto = listadados[1],
            //                          //DataFabricacao = DateTime.Parse(listadados[2]),
            //                          //DataValidade = DateTime.Parse(listadados[3]),
            //                          //Lote = listadados[4],
            //                          //Quantidade = listadados[5],
            //                          //Resultado = listadados[6],
            //                          //MatprimaDescricao = listadados[7],
            //                          //MatprimaQuantidade = listadados[8],
            //                          //MatprimaLote = listadados[9]
            //                      }).ToArray();

            //var DadosRelatorio = (from item in listadados
            //                      select new DadosRelatorio()
            //                      {
            //                          //OrdemProducaoId = int.Parse(listadados[0]),
            //                          //DescricaoProduto = listadados[1],
            //                          //DataFabricacao = DateTime.Parse(listadados[2]),
            //                          //DataValidade = DateTime.Parse(listadados[3]),
            //                          //Lote = listadados[4],
            //                          //Quantidade = listadados[5],
            //                          //Resultado = listadados[6],
            //                          //MatprimaDescricao = listadados[7],
            //                          //MatprimaQuantidade = listadados[8],
            //                          //MatprimaLote = listadados[9]
            //                      }).ToArray();


            //var DataSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetRelatorio", DadosRelatorio);

            var DataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetRelatorio", listadados);
            var DataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetTotaisRelatorio", listatotais);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(DataSource1);
            reportViewer1.LocalReport.DataSources.Add(DataSource2);

            if (imprimirtotais == "S")
            {
                reportViewer1.LocalReport.DataSources.Add(DataSource2);
            }

            // Se comentarmos a linha abaixo, a quebra de páginas customizada será ignorada.
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("AtivaQuebra", "False"));

            if (empresa == "DEZORZI   ")
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Empresa", "DEZORZI"));
            }

            if (empresa == "ITACOR    ")
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Empresa", "ITACOR"));
            }

            this.reportViewer1.RefreshReport();
        }

        public void Processa1(string linha)
        {
            DadosRelatorio dados = new DadosRelatorio();

            //dados.LancamentoId = int.Parse(linha.Substring(1,5));
            dados.Periodo = linha.Substring(0, 36);
            dados.SeguradoId = int.Parse(linha.Substring(37, 5));
            dados.SeguradoNome = linha.Substring(42, 33);
            //dados.CompanhiaId = int.Parse(linha.Substring(1));
            dados.CompanhiaNome = linha.Substring(99, 33);
            //dados.DataLancamento = DateTime.Parse(linha.Substring(1));
            dados.ValorPremioLiquido = decimal.Parse(linha.Substring(150, 8));
            //////////////dados.ValorComissão = decimal.Parse(linha.Substring(146,7));
            dados.NossoNumero = linha.Substring(158, 6);
            dados.NumeroCompanhia = linha.Substring(164, 15);
            //dados.Fatura = linha.Substring(1);

            //dados.ProdutorId_01 = int.Parse(linha.Substring(1));
            dados.ProdutorNome_01 = linha.Substring(190, 29);
            dados.ComissãoPC_01 = linha.Substring(240, 5);

            if (dados.ComissãoPC_01 == "     ")
            {
                dados.ComissãoPC_01 = "0,00";
            }

            if (linha.Substring(247, 7) == "       ")
            {
                dados.ValorComissão_01 = 0;
            }
            else
            {
                dados.ValorComissão_01 = decimal.Parse(linha.Substring(247, 7));
            }

            empresa = linha.Substring(515, 10);

            //dados.ProdutorId_02 = int.Parse(linha.Substring(1));
            //dados.ProdutorNome_02 = linha.Substring(1);
            //dados.ComissãoPC_02 = linha.Substring(1);
            //dados.ValorComissão_02 = int.Parse(linha.Substring(1));

            //dados.ProdutorId_03 = int.Parse(linha.Substring(1));
            //dados.ProdutorNome_03 = linha.Substring(1);
            //dados.ComissãoPC_03 = linha.Substring(1);
            //dados.ValorComissão_03 = int.Parse(linha.Substring(1));

            //dados.ProdutorId_04 = int.Parse(linha.Substring(1));
            //dados.ProdutorNome_04 = linha.Substring(1);
            //dados.ComissãoPC_04 = linha.Substring(1);
            //dados.ValorComissão_04 = int.Parse(linha.Substring(1));

            //dados.ProdutorId_05 = int.Parse(linha.Substring(1));
            //dados.ProdutorNome_05 = linha.Substring(1);
            //dados.ComissãoPC_05 = linha.Substring(1);
            //dados.ValorComissão_05 = int.Parse(linha.Substring(1));

            listadados.Add(dados);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Processa2(string linha)
        {
            TotaisRelatorio dados = new TotaisRelatorio();

            dados.TotalPremioLiquido1 = decimal.Parse(linha.Substring(1, 9));
            dados.TotalPremioLiquido2 = decimal.Parse(linha.Substring(09, 9));
            dados.ComissoesRecebidas = decimal.Parse(linha.Substring(20, 9));
            dados.ComissoesProdutores1 = decimal.Parse(linha.Substring(30, 9));

            dados.ComissoesProdutores2 = decimal.Parse(linha.Substring(30, 9));
            dados.ComissoesEstornadas = decimal.Parse(linha.Substring(0, 9));

            listatotais.Add(dados);
        }


        //********************************************************************************************

        //    private DataSetRelatorio CriarDataSet()
        //    {
        //        var ds = new DataSetRelatorio();

        //        for (int c = 1; c <= 200; c++)
        //        {
        //            ds.Item.AddItemRow(c, string.Format("Item {0}", c));
        //        }

        //        return ds;
        //    }

        //    private void BtImprimir_Click()
        //    {
        //        using (var ds = CriarDataSet())

        //        using (var relatorio = new LocalReport())
        //        {
        //            relatorio.ReportPath = "Relatorio.rdlc";
        //            relatorio.DataSources.Add(new ReportDataSource("DataSetRelatorio", (DataTable)ds.Item));

        //            Exportar(relatorio);
        //            Imprimir(relatorio);
        //        }
        //    }

        //    private void Exportar(Microsoft.Reporting.WinForms.LocalReport relatorio)
        //    {
        //        Microsoft.Reporting.WinForms.Warning[] warnings;
        //        LimparStreams();

        //        relatorio.Render("image", CriarDeviceInfo(relatorio), CreateStreamCallback, out warnings);
        //    }

        //    private void Imprimir(Microsoft.Reporting.WinForms.LocalReport relatorio)
        //    {
        //        using (var pd = new System.Drawing.Printing.PrintDocument())
        //        {
        //            pd.PrinterSettings.PrinterName = "PrimoPDF";
        //            var pageSettings = new System.Drawing.Printing.PageSettings();
        //            var pageSettingsRelatorio = relatorio.GetDefaultPageSettings();
        //            pageSettings.PaperSize = pageSettingsRelatorio.PaperSize;
        //            pageSettings.Margins = pageSettingsRelatorio.Margins;
        //            pd.DefaultPageSettings = pageSettings;

        //            pd.PrintPage += Pd_PrintPage;
        //            _streamAtual = 0;
        //            pd.Print();
        //        }
        //    }

        //    private int _streamAtual;

        //    private void Pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //    {
        //        var stream = _streams[_streamAtual];
        //        stream.Seek(0, System.IO.SeekOrigin.Begin);

        //        using (var metadata = new System.Drawing.Imaging.Metafile(stream))
        //        {
        //            e.Graphics.DrawImage(metadata, e.PageBounds);
        //        }

        //        _streamAtual++;
        //        e.HasMorePages = _streamAtual < _streams.Count;
        //    }

        //    private List<System.IO.Stream> _streams = new List<System.IO.Stream>();

        //    public System.IO.Stream CreateStreamCallback(string name, string extension, Encoding encoding, string mimeType, bool willSeek)
        //    {
        //        var stream = new System.IO.MemoryStream();
        //        _streams.Add(stream);
        //        return stream;
        //    }

        //    private string CriarDeviceInfo(Microsoft.Reporting.WinForms.LocalReport relatorio)
        //    {
        //        var pageSettings = relatorio.GetDefaultPageSettings();
        //        return string.Format(
        //            System.Globalization.CultureInfo.InvariantCulture,
        //            @"<DeviceInfo>
        //                    <OutputFormat>EMF</OutputFormat>
        //                    <PageWidth>{0}in</PageWidth>
        //                    <PageHeight>{1}in</PageHeight>
        //                    <MarginTop>{2}in</MarginTop>
        //                    <MarginLeft>{3}in</MarginLeft>
        //                    <MarginRight>{4}in</MarginRight>
        //                    <MarginBottom>{5}in</MarginBottom>
        //                </DeviceInfo>",
        //            pageSettings.PaperSize.Width / 100m, pageSettings.PaperSize.Height / 100m, pageSettings.Margins.Top / 100m, pageSettings.Margins.Left / 100m, pageSettings.Margins.Right / 100m, pageSettings.Margins.Bottom / 100m);
        //    }

        //    private void LimparStreams()
        //    {
        //        foreach (var stream in _streams)
        //        {
        //            stream.Dispose();
        //        }
        //        _streams.Clear();
        //    }
    }
}
