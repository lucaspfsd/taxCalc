using System;
using TaxCalc.Core;
using Xunit;

namespace TaxCalc.Test
{
    public class CalculadoraJurosTest
    {
        [Fact]
        public void CalcTest()
        {
            var valorIncial = 100;
            var meses = 5;
            var jurosCalculadoEsperado = 105.10d;

            var calculadoraJuros = new CalculadoraJuros();
            var jurosCalculado = calculadoraJuros.Calcular(valorIncial, meses);

            Assert.Equal(jurosCalculadoEsperado, jurosCalculado);
        }
    }
}
