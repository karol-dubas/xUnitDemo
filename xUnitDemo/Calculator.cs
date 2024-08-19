namespace xUnitDemo
{
    enum CalculatorState
    {
        Cleared,
        Active
    }

    public class Calculator
    {
        private CalculatorState _state = CalculatorState.Cleared;

        public decimal Value { get; private set; } = 0;

        public decimal Add(decimal value)
        {
            _state = CalculatorState.Active;
            return Value += value;
        }

        public decimal Substract(decimal value)
        {
            _state = CalculatorState.Active;
            return Value -= value;
        }

        public decimal Multiply(decimal value)
        {
            if (Value != 0 || _state != CalculatorState.Cleared)
                return Value *= value;
            
            _state = CalculatorState.Active;
            return Value = value;
        }

        public decimal Divide(decimal value)
        {
            if (Value != 0 || _state != CalculatorState.Cleared)
                return Value /= value;
            
            _state = CalculatorState.Active;
            return Value = value;
        }
    }
}
