using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrocoConsoleApp.Classes;

namespace TrocoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool encerraPrograma = false;

            while (!encerraPrograma)
            {
                double valorCompra = 0.00;
                double valorDinheiroDado = 0.00;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("=================================================");
                Console.WriteLine("|   Programa para calculo de Cédulas e Moedas   |");
                Console.WriteLine("=================================================");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Regras:");
                Console.WriteLine("Apenas Valores Numéricos Válidos");
                Console.WriteLine("O valor da dinheiro dado precisa ser maior que o valor da compra");
                Console.WriteLine("");
                

                while (valorCompra == 0.00)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Por favor, digite o valor da compra:");

                    if (!double.TryParse(Console.ReadLine(), out valorCompra))
                    {
                        valorCompra = 0.00;
                    }
                }

                while (valorDinheiroDado == 0.00)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Por favor, digite o valor da dinheiro fornecido:");

                    if (!double.TryParse(Console.ReadLine(), out valorDinheiroDado))
                    {
                        valorDinheiroDado = 0.00;
                    }
                }

                if (valorDinheiroDado < valorCompra)
                {
                    Console.WriteLine("Infelizmente não será possivel calcular o troco, pois o dinheiro fornecido é menor que o valor da compra");
                    Console.WriteLine("Por favor, verifique.");
                }
                else if (valorDinheiroDado == valorCompra)
                {
                    Console.WriteLine("Não existe troco a ser calculado");
                    Console.ReadKey();
                }
                else
                {
                    Caixa caixa = new Caixa();
                    caixa.AdicionaDinheiroPadrao();
                    Console.WriteLine(caixa.calculaTroco(valorDinheiroDado, valorCompra, caixa)); ;
                };

                Console.WriteLine("Pressione uma tecla para reiniciar o processo");
                Console.ReadKey();
            }
            Console.ReadKey();
        }
    }
}
