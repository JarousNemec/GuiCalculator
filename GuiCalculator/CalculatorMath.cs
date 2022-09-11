using System;

namespace GuiCalculator
{
    public class CalculatorMath : ICalculatorMath
    {
        public double Plus(double n1, double n2)
        {
            return n1 + n2;
        }

        public double Minus(double n1, double n2)
        {
            return n1 - n2;
        }

        public double Times(double n1, double n2)
        {
            return n1 * n2;
        }

        public double Divide(double n1, double n2)
        {
            
            if (n2 == 0)
            {
                throw new Exception("Can not divide by Zero");
            }

            return n1 / n2;
        }
    }
}