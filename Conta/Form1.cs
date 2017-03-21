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
using MaaaX.CaixaEletronico.Investimento;
using MaaaX.CaixaEletronico.Excessao;
using MaaaX.CaixaEletronico.CadastroConta;

namespace MaaaX.CaixaEletronico.Main
{
    public partial class Form1 : Form
    {
        List<Investimento.Conta> contas;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GerenciadorDeImposto gi = new GerenciadorDeImposto();
            ContaInvestimento ci = new ContaInvestimento();
            ContaPoupanca cp = new ContaPoupanca();

            ci.Deposita(100.0);
            cp.Deposita(100.0);

            gi.Adiciona(ci);
            gi.Adiciona(cp);

            var contaDoVictor = new ContaPoupanca();
            contaDoVictor.Titular = "Victor";
            contaDoVictor.Numero = 1;

            var contaDoMario = new ContaCorrente();
            contaDoMario.Titular = "Mario";
            contaDoMario.Numero = 2;

            this.contas = new List<Investimento.Conta>();
            this.contas.Add(contaDoVictor);
            this.contas.Add(contaDoMario);

            foreach (Investimento.Conta conta in contas)
            {
                comboContas.Items.Add(conta);
                destinoDaTransferencia.Items.Add(conta);
            }
        }

        public void AdicionaConta(Investimento.Conta conta)
        {
            this.contas.Add(conta);

            comboContas.Items.Add(conta);
            destinoDaTransferencia.Items.Add(conta);
        }

        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Investimento.Conta contaSelecionada = this.GetConta(sender);
            this.MostraConta(contaSelecionada);
        }

        private void MostraConta(Investimento.Conta c)
        {
            txtTitular.Text = c.Titular;
            txtSaldo.Text = c.Saldo.ToString();
            txtNumero.Text = c.Numero.ToString();
        }

        private Investimento.Conta GetConta(object sender)
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
            Investimento.Conta contaSelecionada = this.GetConta(comboContas);
            double valor = Convert.ToDouble(txtValor.Text);

            contaSelecionada.Deposita(valor);
            this.MostraConta(contaSelecionada);
        }

        private void btnSaque_Click(object sender, EventArgs e)
        {
            Investimento.Conta contaSelecionada = this.GetConta(comboContas);
            double valor = Convert.ToDouble(txtValor.Text);

            try
            {
                contaSelecionada.Saca(valor);
                MessageBox.Show("Dinheiro Liberado");
            }
            catch (SaldoInsuficienteException ex)
            {
                MessageBox.Show("Saldo insuficiente");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Não é possível sacar um valor negativo");
            }

            this.MostraConta(contaSelecionada);
        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            Investimento.Conta contaDe = this.GetConta(comboContas);
            Investimento.Conta contaPara = this.GetConta(destinoDaTransferencia);
            double valor = Convert.ToDouble(txtValor.Text);

            contaDe.Saca(valor);
            contaPara.Deposita(valor);

            this.MostraConta(contaPara);
        }

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            CadastroDeConta formularioDeCadastro = new CadastroDeConta(this);
            formularioDeCadastro.ShowDialog();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            var contaSelecionada = (Investimento.Conta)comboContas.SelectedItem;

            this.contas.Remove(contaSelecionada);
            comboContas.Items.Remove(contaSelecionada);
            destinoDaTransferencia.Items.Remove(contaSelecionada);
        }
    }
}
