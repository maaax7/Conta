using Conta.CaixaEletronico.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conta.CaixaEletronico.CadastroConta
{
    public partial class CadastroDeConta : Form
    {
        private Form1 aplicacaoPrincipal;

        public CadastroDeConta(Form1 aplicacaoPrincipal)
        {
            this.aplicacaoPrincipal = aplicacaoPrincipal;
            InitializeComponent();

            cbTipoConta.Items.Add(new { Text = "Corrente", Value = 3 });
            cbTipoConta.Items.Add(new { Text = "Poupanca", Value = 3 });
            cbTipoConta.Items.Add(new { Text = "Investimento", Value = 3 });
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            DadosConta.Conta novaConta = null;

            if (cbTipoConta.Text == "Corrente")
                novaConta = new DadosConta.ContaCorrente();
            else if (cbTipoConta.Text == "Poupanca")
                novaConta = new DadosConta.ContaPoupanca();
            else
                novaConta = new DadosConta.ContaInvestimento();

            novaConta.Titular = txtTitular.Text;
            novaConta.Numero = Convert.ToInt32(txtNumeroConta.Text);

            this.aplicacaoPrincipal.AdicionaConta(novaConta);
            this.Close();
        }
    }
}
