namespace GuiCalculator
{
    public class Calculator : ICalculator

    {
        private readonly CalculatorMath _calculatorMath;
        private bool _isFirstNumberInitialized;
        private MathOperation? _lastChooseMathOperation;
        private double _firstNumber;
        private double _secondNumber;

        public Calculator()
        {
            _calculatorMath = new CalculatorMath();
        }

        private bool NumberManipulator(double number)
        {
            if (!_isFirstNumberInitialized)
            {
                _firstNumber = number;
                _isFirstNumberInitialized = true;
                return false;
            }

            _secondNumber = number;
            return true;
        }

        public void Plus(double number)
        {
            GetResult(number);
            _lastChooseMathOperation = MathOperation.Plus;
        }

        public void Minus(double number)
        {
            GetResult(number);
            _lastChooseMathOperation = MathOperation.Minus;
        }

        public void Times(double number)
        {
            GetResult(number);
            _lastChooseMathOperation = MathOperation.Times;
        }

        public void Divide(double number)
        {
            GetResult(number);
            _lastChooseMathOperation = MathOperation.Divide;
        }

        public double Equals(double number)
        {
            GetResult(number);
            _isFirstNumberInitialized = false;
            return _firstNumber;
        }

        private void GetResult(double number)
        {
            if (NumberManipulator(number))
            {
                switch (_lastChooseMathOperation)
                {
                    case MathOperation.Plus:
                        _firstNumber = _calculatorMath.Plus(_firstNumber, _secondNumber);
                        break;
                    case MathOperation.Minus:
                        _firstNumber = _calculatorMath.Minus(_firstNumber, _secondNumber);
                        break;
                    case MathOperation.Divide:
                        if (_secondNumber != 0)
                            _firstNumber = _calculatorMath.Divide(_firstNumber, _secondNumber);
                        break;
                    case MathOperation.Times:
                        _firstNumber = _calculatorMath.Times(_firstNumber, _secondNumber);
                        break;
                }
            }
        }

        public void Clear()
        {
            _isFirstNumberInitialized = false;
            _lastChooseMathOperation = null;
            _firstNumber = 0;
            _secondNumber = 0;
        }
    }
}