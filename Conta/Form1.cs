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
            Conta c = new Conta();
            ContaCorrente cc = new ContaCorrente();
            ContaPoupanca cp = new ContaPoupanca();

            c.Deposita(1000.0);
            cc.Deposita(1000.0);
            cp.Deposita(1000.0);

            AtualizadorDeContas atualizador = new AtualizadorDeContas(0.01);
            atualizador.Roda(c);
            atualizador.Roda(cc);
            atualizador.Roda(cp);

            TotalizadorDeContas t = new TotalizadorDeContas();
            t.Adiciona(cp);

            MessageBox.Show("c = " + c.Saldo);
            MessageBox.Show("cc = " + cc.Saldo);
            MessageBox.Show("cp = " + cp.Saldo);
        }
    }
}
