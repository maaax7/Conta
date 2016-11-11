using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conta conta = new Conta();
            conta.numero = 1;
            conta.saldo = 1500.0;
            conta.titular = "Jabidailsom";

            Conta conta1 = new Conta();
            conta1.numero = 2;
            conta1.saldo = 2000.0;
            conta1.titular = "Pereira";
            conta1.agencia = 23234;
            conta1.cpf = "342332432";

            MessageBox.Show("Numero: " + conta1.numero + "\nTitular: " + conta1.titular + "\nSaldo: " + conta1.saldo + 
                            "\nAgencia" + conta1.agencia + "\nCPF: " + conta1.cpf);
        }
    }
}
