using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta.CaixaEletronico.Usuarios
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public int Idade { get; set; }
        public string[] documentos { get; set; }
        public bool PodeAbrirContaSozinho
        {
            get
            {
                return (this.Idade >= 18 ||
                this.documentos.Contains("emancipacao")) &&
                !string.IsNullOrEmpty(this.CPF);
            }
        }
        public bool EhMaiorDeIdade
        {
            get
            {
                return this.Idade >= 18;
            }
        }

        public Cliente(string nome)
        {
            this.Nome = nome;
        }

        public Cliente() { }

        public override bool Equals(object obj)
        {
            Cliente outroCliente = (Cliente)obj;
            return this.Rg == outroCliente.Rg;
        }

        public override string ToString()
        {
            return "Nome: " + this.Nome + "RG: " + this.Rg;
        }
    }
}
