using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta.CaixaEletronico.DadosConta
{
    /*
     * Muitas pessoas optam por investir o dinheiro das suas contas bancárias. 
     * Existem diversos tipos de investimentos, desde investimentos conservadores até mais arrojados.
     * Independente do investimento escolhido, o titular da conta recebe apenas 75% do lucro do investimento, pois 25% é imposto.
     * Implemente um mecanismo que invista o valor do saldo dela em um dos vários tipos de investimento e, 
     * dado o retorno desse investimento, 75% do valor é adicionado no saldo da conta.
     * Crie a classe RealizadorDeInvestimentos que recebe uma estratégia de investimento, a executa sobre uma conta bancária, 
     * e adiciona o resultado seguindo a regra acima no saldo da conta. 
     * Os possíveis tipos de investimento são:
     * "CONSERVADOR", que sempre retorna 0.8% do valor investido;
     * "MODERADO", que tem 50% de chances de retornar 2.5%, e 50% de chances de retornar 0.7%;
     * "ARROJADO", que tem 20% de chances de retornar 5%, 30% de chances de retornar 3%, e 50% de chances de retornar 0.6%.
     */

    public class RealizadorDeInvestimentos
    {
        public void Investir(Conta conta, Investimento investimento)
        {
            var calculo = investimento.CalculaInvestimento(conta.Saldo);
            conta.Deposita(calculo * 0.75);
        }
    }

    public class Conservador : Investimento
    {
        public double CalculaInvestimento(double saldo)
        {
            return saldo * (0.8 / 100);
        }
    }

    public class Moderado : Investimento
    {
        private Random random;

        public Moderado()
        {
            this.random = new Random();
        }

        public double CalculaInvestimento(double saldo)
        {
            if (random.Next(2) == 0)
                return saldo * 0.025;
            else
                return saldo * 0.007;
        }
    }

    public class Arrojado : Investimento
    {
        private Random random;

        public Arrojado()
        {
            this.random = new Random();
        }

        public double CalculaInvestimento(double saldo)
        {
            int chute = random.Next(10);
            if (chute >= 0 && chute <= 1) return saldo * 0.5;
            else if (chute >= 2 && chute <= 4) return saldo * 0.3;
            else return saldo * 0.006;
        }
    }
}
