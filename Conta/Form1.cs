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
using System.IO;

namespace MaaaX.CaixaEletronico.Main
{
    public partial class Form1 : Form
    {
        HashSet<Investimento.Conta> contas;

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

            //HashSet nao permite inserir conteudo duplicado
            this.contas = new HashSet<Investimento.Conta>();
            this.contas.Add(contaDoVictor);
            this.contas.Add(contaDoVictor);

            //this.contas.Clear();
            //MessageBox.Show(this.contas.Count.ToString());

            //Utilizando SortedSet - ordena itens em ordem crescente
            //SortedSet<string> palavras = new SortedSet<string>();
            //palavras.Add("vida");
            //palavras.Add("furadeira");
            //palavras.Add("maçã");
            //foreach (string palavra in palavras)
            //{
            //    MessageBox.Show(palavra);
            //}

            //Utilizando Dictionary
            //Dictionary<string, string> nomesEPalavras = new Dictionary<string, string>();
            //nomesEPalavras.Add("Erich", "vida");
            //nomesEPalavras.Add("Alberto", "delicia");
            //foreach (var i in nomesEPalavras)
            //{
            //    MessageBox.Show(i.Key + "->" + i.Value);
            //}

            //Utilizando sortedDictionary
            //SortedDictionary<string, string> nomes = new SortedDictionary<string, string>();
            //nomes.Add("Adriano", "Almeida");
            //nomes.Add("Mario", "Amaral");
            //nomes.Add("Eric", "Torti");
            //nomes.Add("Guilherme", "Silveira");
            //foreach (var i in nomes)
            //{
            //    MessageBox.Show(i.Key + " " + i.Value);
            //}

            if (File.Exists("entrada.txt"))
            {
                using (Stream entrada = File.Open("entrada.txt", FileMode.Open))
                using (StreamReader leitor = new StreamReader(entrada))
                {
                    //ler byte do stream
                    //byte b = (byte)entrada.ReadByte();
                    string linha = leitor.ReadToEnd();
                    MessageBox.Show(linha);
                }

            }

            using (Stream saida = File.Open("saida.txt", FileMode.Create))
            using (StreamWriter escritor = new StreamWriter(saida))
                escritor.WriteLine(txtTitular.Text);

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

            return contas.FirstOrDefault(); //contas[indiceContaSelecionada];
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
