using MaaaX.CaixaEletronico.Excessao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaaaX.CaixaEletronico.Investimento
{
    public abstract class Conta
    {
        public double Saldo { get; protected set; }
        public int Numero { get; set; }
        public string Titular { get; set; }

        public virtual void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public abstract void Saca(double valor);

        public virtual void Atualiza(double taxa)
        {
            this.Saldo += this.Saldo * taxa;
        }
    }

    class ContaPoupanca : Conta, ITributavel
    {
        public override void Atualiza(double taxa)
        {
            base.Atualiza(3 * taxa);
        }

        public override void Saca(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException();
            }

            if (valor > this.Saldo)
            {
                throw new SaldoInsuficienteException("Valor do saque maior que o saldo");
            }

            this.Saldo -= (valor + 0.10);
        }

        public double CalculaTributo()
        {
            return this.Saldo * 0.02;
        }
    }

    class ContaCorrente : Conta
    {
        //Outros atributos da classe
        private static int totalDeContas = 0;

        public ContaCorrente()
        {
            totalDeContas++;
        }

        public static int ProximaConta()
        {
            return totalDeContas + 1;
        }

        public override void Atualiza(double taxa)
        {
            base.Atualiza(2 * taxa);
        }

        public override void Saca(double valor)
        {
            this.Saldo -= valor;
        }
    }

    class ContaInvestimento : Conta, ITributavel
    {
        public override void Saca(double valor)
        {
            throw new NotImplementedException();
        }

        public double CalculaTributo()
        {
            return this.Saldo * 0.03;
        }
    }
}
