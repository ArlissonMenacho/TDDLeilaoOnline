using System;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTestes
    {
        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void VerificaLanceLeilao(double valorEsperado, double[] ofertas)
        {
            //Arange - cenário
            //Dado leilão com 3 clientes e lances realizados
            var leilao = new Leilao("Van Gogh");
            var Arlisson = new Interessada("Arlisson", leilao);
            foreach (var valor in ofertas)
            {
                leilao.ReceberLance(Arlisson, valor);
            }

            // Act - Ação a ser Testada
            //Quando o leilão terminar
            leilao.TerminaPregao();

            //Assert - O que é esperado quando o resultado ocorrer.
            //Então o valor esperado é o maior lance dado pelo cliente.
            //O cliente Vencedor deve ser o com maior lance.
            var ValorRecebido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, ValorRecebido);
        }
        [Fact]
        public void LeilaoSemLance()
        {
            //Arange - cenário
            var leilao = new Leilao("Van Gogh");


            // Act - Ação a ser Testada
            leilao.TerminaPregao();

            //Assert - O que é esperado quando o resultado ocorrer.
            var valorEsperado = 0;
            var ValorRecebido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, ValorRecebido);
        }
    }
}
