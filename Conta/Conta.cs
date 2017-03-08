﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta
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

    class ContaPoupanca : Conta
    {
        public override void Atualiza(double taxa)
        {
            base.Atualiza(3 * taxa);
        }

        public override void Saca(double valor)
        {
            this.Saldo -= (valor + 0.10);
        }
    }

    class ContaCorrente : Conta
    {
        public override void Atualiza(double taxa)
        {
            base.Atualiza(2 * taxa);
        }

        public override void Saca(double valor)
        {
            this.Saldo -= valor;
        }
    }
}
