using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta.CaixaEletronico.DadosConta
{
    class AtualizadorDeContas
    {
        public double Taxa { get; private set; }

        public AtualizadorDeContas(double taxa)
        {
            this.Taxa = taxa;
        }

        public void Roda(Conta c)
        {
            c.Atualiza(this.Taxa);
        }
    }
}
