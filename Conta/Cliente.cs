using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta
{
    public class Cliente
    {
        //nome (string), rg (string), cpf (string) e endereco (string). 
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public int Idade { get; set; }

        public Cliente(string nome)
        {
            this.Nome = nome;
        }

        public Cliente() { }

        public bool EhMaiorDeIdade
        {
            get
            {
                return this.Idade >= 18;
            }
        }
    }
}
