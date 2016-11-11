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

            MessageBox.Show("Numero: " + conta.numero + "\nTitular: " + conta.titular + "\nSaldo: " + conta.saldo);
        }
    }
}
