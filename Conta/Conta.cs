using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta
{
    class Conta
    {
        public int Numero { get; set; }
        public double Saldo { get; private set; }
        public Cliente Titular { get; set; }

        public bool Sacar(double valorASacar)
        {
            double saqueMaximoMenorIdade = 200.0;
            bool permiteSacar = (this.Titular != null && this.Titular.EhMaiorDeIdade) ? true : valorASacar <= saqueMaximoMenorIdade ? true : false;

            if (valorASacar <= this.Saldo && valorASacar >= 0 && permiteSacar)
            {
                this.Saldo -= valorASacar;
                return true;
            }

            return false;
        }

        public void Depositar(double valorADepositar)
        {
            if (valorADepositar >= 0)
            {
                this.Saldo += valorADepositar;
            }
        }

        public void Transferir(double valorASerTransferido, Conta destino)
        {
            this.Sacar(valorASerTransferido);
            destino.Depositar(valorASerTransferido);
        }

        public double CalcularRendimentoAnual()
        {
            double saldoNaqueleMes = this.Saldo;

            for (int i = 0; i < 12; i++)
            {
                saldoNaqueleMes = saldoNaqueleMes * 1.007;
            }

            double rendimento = saldoNaqueleMes - this.Saldo;

            return rendimento;
        }
    }
}
