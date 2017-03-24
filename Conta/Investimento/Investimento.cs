using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta.CaixaEletronico.DadosConta
{
    public interface Investimento
    {
        double CalculaInvestimento(double saldo);
    }
}
