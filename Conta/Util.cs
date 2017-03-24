using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Conta.CaixaEletronico.Util
{
    public static class StringExtensions
    {
        public static string Pluralize(this string texto)
        {
            if (texto.EndsWith("s"))
                return texto;
            else
                return texto + "s";
        }
    }

    public static class ObjectExtensions
    {
        public static string AsXml(this DadosConta.Conta resource)
        {
            var stringWriter = new StringWriter();
            new XmlSerializer(resource.GetType()).Serialize(stringWriter, resource);
            return stringWriter.ToString();
        }
    }

    public static class ContaExtensions
    {
        public static void MudaSaldo(this DadosConta.Conta conta, double novoSaldo)
        {
            conta.Saldo = novoSaldo;
        }
    }
}
