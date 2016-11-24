namespace Calculator_SimpleFactory
{
    class AddOperator : Operator
    {
        public override double Operate(double numberA, double numberB)
        {
            return (numberA + numberB);
        }
    }
}