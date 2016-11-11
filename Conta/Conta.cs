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
        public string titular { get; set; }
        public int numero { get; set; }
        public int agencia { get; set; }
        public string cpf { get; set; }

        public void Sacar(double valorASacar)
        {
            if (valorASacar <= this.saldo && valorASacar >= 0)
            {
                this.saldo -= valorASacar;
            }
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

        public double CalculaRendimentoAnual()
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
