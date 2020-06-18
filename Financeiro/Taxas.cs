using System;

namespace Financeiro
{
    public class Taxas
    {
        //https://www3.bcb.gov.br/CALCIDADAO/publico/exibirMetodologiaFinanciamentoPrestacoesFixas.do?method=exibirMetodologiaFinanciamentoPrestacoesFixas
        public decimal CalcularTaxaJuros(decimal valorFinanciamento, decimal parcelaDesejada, int prazoEmMeses, double margemErro = 0.000001)
        {
            double taxaJuros = margemErro; //O calculo inicia sempre com a margem de erro
            double taxaJurosSimulada = 1;

            //O cálculo não prevê taxa de juros 0
            if (valorFinanciamento == parcelaDesejada * prazoEmMeses)
                return 0;

            while (Math.Abs(taxaJuros - taxaJurosSimulada) > margemErro && taxaJuros > double.MinValue)
            {
                taxaJurosSimulada = taxaJuros;

                double taxaCorrecao = Math.Pow(1.0 + taxaJurosSimulada, -prazoEmMeses);

                double funcaoTaxaJuros = (1 - taxaCorrecao) * ((double)parcelaDesejada / taxaJurosSimulada) - (double)valorFinanciamento;
                double derivadaFuncaoTaxaJuros = (double)parcelaDesejada * ((prazoEmMeses * (Math.Pow(1 + taxaJurosSimulada, -prazoEmMeses - 1))) / taxaJurosSimulada - (1 - taxaCorrecao) / Math.Pow(taxaJurosSimulada, 2));
                taxaJuros = taxaJurosSimulada - (funcaoTaxaJuros / derivadaFuncaoTaxaJuros);
            }

            return Math.Round(Convert.ToDecimal(taxaJuros) * 100, 6, MidpointRounding.AwayFromZero);
        }

        public decimal TIR()
        {
            throw new NotImplementedException();
        }
    }
}
