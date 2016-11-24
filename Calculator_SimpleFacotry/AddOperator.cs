namespace Calculator_SimpleFacotry
{
    class AddOperator : Operator
    {
        public override double Operate(double numberA, double numberB)
        {
            return (numberA + numberB);
        }
    }
}