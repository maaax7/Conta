using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conta
{
    public partial class Form1 : Form
    {
        Conta[] contas;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var contaDoVictor = new ContaCorrente();
            contaDoVictor.Titular = "Victor";
            contaDoVictor.Numero = 1;

            var contaDoMario = new ContaCorrente();
            contaDoMario.Titular = "Mario";
            contaDoMario.Numero = 2;

            this.contas = new Conta[2];
            this.contas[0] = contaDoVictor;
            this.contas[1] = contaDoMario;

            foreach (Conta conta in contas)
            {
                comboContas.Items.Add(conta.Titular);
                destinoDaTransferencia.Items.Add(conta.Titular);
            }
        }

        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conta contaSelecionada = this.GetConta(sender);
            this.MostraConta(contaSelecionada);
        }

        private void MostraConta(Conta c)
        {
            txtTitular.Text = c.Titular;
            txtSaldo.Text = c.Saldo.ToString();
            txtNumero.Text = c.Numero.ToString();
        }

        private Conta GetConta(object sender)
        {
            int indiceContaSelecionada = 0;
            if (sender.GetType() == typeof(ComboBox))
            {
                ComboBox combo = (ComboBox)sender;
                indiceContaSelecionada = combo.SelectedIndex;
            }
            return contas[indiceContaSelecionada];
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            Conta contaSelecionada = this.GetConta(comboContas);
            double valor = Convert.ToDouble(txtValor.Text);

            contaSelecionada.Deposita(valor);
            this.MostraConta(contaSelecionada);
        }

        private void btnSaque_Click(object sender, EventArgs e)
        {
            Conta contaSelecionada = this.GetConta(comboContas);
            double valor = Convert.ToDouble(txtValor.Text);

            contaSelecionada.Saca(valor);
            this.MostraConta(contaSelecionada);
        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            Conta contaDe = this.GetConta(comboContas);
            Conta contaPara = this.GetConta(destinoDaTransferencia);
            double valor = Convert.ToDouble(txtValor.Text);

            contaDe.Saca(valor);
            contaPara.Deposita(valor);

            this.MostraConta(contaPara);
        }
    }
}
