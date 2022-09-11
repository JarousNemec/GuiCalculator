using System;
using GuiCalculator;
using NUnit.Framework;


namespace ICalculatorMathTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Plus()
        {
            CalculatorMath calculatorMath = new CalculatorMath();
            Assert.AreEqual(5, calculatorMath.Plus(2, 3));
        }

        [Test]
        public void Minus()
        {
            CalculatorMath calculatorMath = new CalculatorMath();
            Assert.AreEqual(10, calculatorMath.Minus(15, 5));
        }

        [Test]
        public void Times()
        {
            CalculatorMath calculatorMath = new CalculatorMath();
            Assert.AreEqual(25, calculatorMath.Times(5, 5));
        }

        [Test]
        public void Divide()
        {
            CalculatorMath calculatorMath = new CalculatorMath();
            Assert.AreEqual(23, calculatorMath.Divide(69, 3));
        }
        
        [Test]
        public void DivideByZero()
        {
            CalculatorMath calculatorMath = new CalculatorMath();
            Assert.Throws<Exception>(() => calculatorMath.Divide(69, 0));
        }        
        
    }
}