using System;

namespace TaxCalc.Core
{
    public class CalculadoraJuros
    {
        public const double TAXA = 0.01d;

        public double Calcular(double valorInicial, double meses)
        {
            var valorComJuros = valorInicial * Math.Pow((1 + TAXA), meses);
            return Double.Parse(valorComJuros.ToString("0.00"));
        }
    }
}