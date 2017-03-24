using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta.CaixaEletronico.Imposto
{
    public interface ITributavel
    {
        double CalculaTributo();
    }
}
