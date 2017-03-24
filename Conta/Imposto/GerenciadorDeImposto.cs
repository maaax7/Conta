using Conta.CaixaEletronico.DadosConta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta.CaixaEletronico.Imposto
{
    public class GerenciadorDeImposto
    {
        public double Total { get; private set; }

        public void Adiciona(ITributavel tributavel)
        {
            this.Total += tributavel.CalculaTributo();
        }
    }

    public class CalculadorDeImpostos
    {
        public void RealizaCalculo(Orcamento orcamento, Imposto imposto)
        {
            double retorno = imposto.Calcula(orcamento);
        }
    }

    public class ICMS : Imposto
    {
        public double Calcula(Orcamento orcamento)
        {
            return (orcamento.Valor * 0.05) + 50;
        }
    }

    public class ISS : Imposto
    {
        public double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }
    }

    public class ICCC : Imposto
    {
        public double Calcula(Orcamento orcamento)
        {
            double retorno = 0;

            if (orcamento.Valor < 1000)
                retorno = orcamento.Valor * 0.05;
            else if (orcamento.Valor < 3000)
                retorno = orcamento.Valor * 0.07;
            else
                retorno = orcamento.Valor * 0.08 + 30;

            return retorno;
        }
    }
}
