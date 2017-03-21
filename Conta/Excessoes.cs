using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaaaX.CaixaEletronico.Excessao
{
    class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException(string message) : base(message)
        {
        }
    }
}
