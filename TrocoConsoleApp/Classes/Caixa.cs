using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrocoConsoleApp.Classes
{
    class Caixa
    {
        public List<Dinheiro> Troco;

        public Caixa()
        {
            Troco = new List<Dinheiro>();
            AdicionaDinheiroPadrao();
        }

        public void AdicionaDinheiro(Dinheiro dinheiro)
        {
            if (!(Troco.Exists(d => d.tipoDinheiro == dinheiro.tipoDinheiro && d.Valor == dinheiro.Valor)))
            {
                Troco.Add(dinheiro);
            }
        }

        public void AdicionaDinheiroPadrao()
        {
            AdicionaDinheiro(new Dinheiro(TipoDinheiro.Cedula, 100, "100.00"));
            AdicionaDinheiro(new Dinheiro(TipoDinheiro.Cedula, 50, "50.00"));
            AdicionaDinheiro(new Dinheiro(TipoDinheiro.Cedula, 10, "10.00"));
            AdicionaDinheiro(new Dinheiro(TipoDinheiro.Cedula, 5, "5.00"));
            AdicionaDinheiro(new Dinheiro(TipoDinheiro.Cedula, 1, "1.00"));
            AdicionaDinheiro(new Dinheiro(TipoDinheiro.Moeda, 50, "0.50"));
            AdicionaDinheiro(new Dinheiro(TipoDinheiro.Moeda, 10, "0.10"));
            AdicionaDinheiro(new Dinheiro(TipoDinheiro.Moeda, 5, "0.05"));
            AdicionaDinheiro(new Dinheiro(TipoDinheiro.Moeda, 1, "0.01"));
        }

        public String calculaTroco(double valorDado, double valorDevido, Caixa caixa)
        {
            String resultado = "";
            double troco;
            int contaTroco = 0;
            int valorInteiro = 0;

            troco = valorDado - valorDevido;
            resultado = "\nTroco = R$   " + troco + "\n\n";
            valorInteiro = (int)troco;

            //Conta as Cedulas
            var cedulas = caixa.Troco.FindAll(d => d.tipoDinheiro == TipoDinheiro.Cedula);
            foreach (Dinheiro dinheiro in cedulas)
            {
                contaTroco = valorInteiro / dinheiro.Valor;

                if (contaTroco != 0)
                {
                    resultado = resultado + (contaTroco + " nota(s) de R$ " + dinheiro.ValorDescritivo + "\n");
                    valorInteiro = valorInteiro % dinheiro.Valor;
                }
            }

            //Conta as Moedas
            valorInteiro = (int)Math.Round((troco - (int)troco) * 100);

            var moedas = caixa.Troco.FindAll(d => d.tipoDinheiro == TipoDinheiro.Moeda);
            foreach (Dinheiro dinheiro in moedas)
            {
                contaTroco = valorInteiro / dinheiro.Valor;

                if (contaTroco != 0)
                {
                    resultado = resultado + (contaTroco + " Moedas(s) de R$ " + dinheiro.ValorDescritivo+ "\n");
                    valorInteiro = valorInteiro % dinheiro.Valor;
                }
            }

            return resultado;
        }
    }
}
