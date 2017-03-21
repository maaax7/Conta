﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaaaX.CaixaEletronico.Investimento
{
    class TotalizadorDeTributos
    {
        public double Total { get; private set; }

        public void Acumula(ITributavel t)
        {
            Total += t.CalculaTributo();
        }
    }
}
