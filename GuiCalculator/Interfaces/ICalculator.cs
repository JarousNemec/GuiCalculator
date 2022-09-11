namespace GuiCalculator
{
    public interface ICalculator
    { 
        void Plus(double number);
        void Minus(double number);
        void Times(double number);
        void Divide(double number);
        double Equals(double number);
        void Clear();
    }
}