using Conta.CaixaEletronico.DadosConta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta.CaixaEletronico.Imposto
{
    public interface Imposto
    {
        double Calcula(Orcamento orcamento);
    }
}
