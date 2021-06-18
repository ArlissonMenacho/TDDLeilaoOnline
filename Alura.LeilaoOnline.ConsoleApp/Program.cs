using System;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            VerificaLanceLeilao();
            LeilaoApenasUmLance();
        }

        private static void VerificaLancesObtido(double valorEsperado, double ValorRecebido)
        {
            var corDoConsoleOriginal = Console.ForegroundColor;
            if (valorEsperado == ValorRecebido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sucesso! Código está OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Falha! Verifique o Código, Valor Esperado era: {valorEsperado}, e o valor recebido foi: {ValorRecebido}");
            }
            Console.ForegroundColor = corDoConsoleOriginal;
        }

        private static void VerificaLanceLeilao()
        {
            //Arange - cenário
            var leilao = new Leilao("Van Gogh");
            var Arlisson = new Interessada("Arlisson", leilao);
            var Lucy = new Interessada("Lucy", leilao);

            leilao.ReceberLance(Arlisson, 800);
            leilao.ReceberLance(Lucy, 900);
            //leilao.ReceberLance(Arlisson, 1000);

            // Act - Ação a ser Testada
            leilao.TerminaPregao();

            //Assert - O que é esperado quando o resultado ocorrer.

            var valorEsperado = 1000;
            var ValorRecebido = leilao.Ganhador.Valor;
            VerificaLancesObtido(valorEsperado, ValorRecebido);
        }

        private static void LeilaoApenasUmLance()
        {
            //Arange - cenário
            var leilao = new Leilao("Van Gogh");
            var Arlisson = new Interessada("Arlisson", leilao);

            leilao.ReceberLance(Arlisson, 800);

            // Act - Ação a ser Testada
            leilao.TerminaPregao();

            //Assert - O que é esperado quando o resultado ocorrer.
            var valorEsperado = 800;
            var ValorRecebido = leilao.Ganhador.Valor;
            VerificaLancesObtido(valorEsperado, ValorRecebido);
        }

    }
}
