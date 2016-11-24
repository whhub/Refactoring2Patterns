namespace Calculator_SimpleFactory
{
    class SubtractOperator : Operator
    {
        public override double Operate(double numberA, double numberB)
        {
            return numberA-numberB;
        }
    }
}