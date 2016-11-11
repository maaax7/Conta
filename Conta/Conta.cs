using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta
{
    public class Conta
    {
        public double saldo { get; set; }
        public Cliente titular { get; set; }
        public int numero { get; set; }
        public int agencia { get; set; }

        public bool Sacar(double valorASacar)
        {
            double saqueMaximoMenorIdade = 200.0;
            bool permiteSacar = (this.titular != null && this.titular.EhMaiorDeIdade()) ? true : valorASacar <= saqueMaximoMenorIdade ? true : false;

            if (valorASacar <= this.saldo && valorASacar >= 0 && permiteSacar)
            {
                this.saldo -= valorASacar;
                return true;
            }

            return false;
        }

        public void Depositar(double valorADepositar)
        {
            if (valorADepositar >= 0)
            {
                this.saldo += valorADepositar;
            }
        }

        public void Transferir(double valorASerTransferido, Conta destino)
        {
            this.Sacar(valorASerTransferido);
            destino.Depositar(valorASerTransferido);
        }

        public double CalcularRendimentoAnual()
        {
            double saldoNaqueleMes = this.saldo;

            for (int i = 0; i < 12; i++)
            {
                saldoNaqueleMes = saldoNaqueleMes * 1.007;
            }

            double rendimento = saldoNaqueleMes - this.saldo;

            return rendimento;
        }
    }
}
