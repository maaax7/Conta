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
            Conta contaGuilherme = new Conta();
            
            Cliente clienteGuilherme = new Cliente();
            clienteGuilherme.nome = "Guilherme";
            clienteGuilherme.Idade = 17;

            bool sacou = contaGuilherme.Sacar(300.0);
            if (sacou)
                MessageBox.Show("Saldo da Conta do Guilherme após saque: ");
            else
                MessageBox.Show("Não foi possível sacar da conta do Guilherme");
        }
    }
}
