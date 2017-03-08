﻿using System;
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
            Conta[] contas = new Conta[5];
            contas[0] = new Conta();
            contas[1] = new ContaPoupanca();

            foreach (Conta c in contas)
            {
                MessageBox.Show(c.Saldo.ToString());
            }
        }
    }
}
