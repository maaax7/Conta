﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta
{
    public class TotalizadorDeContas
    {
        public double Saldo { get; private set; }

        public void Adiciona(Conta c)
        {
            this.Saldo += c.Saldo;
        }
    }
}
