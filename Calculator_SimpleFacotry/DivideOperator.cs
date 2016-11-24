namespace Calculator_SimpleFactory
{
    class DivideOperator : Operator
    {
        public override double Operate(double numberA, double numberB)
        {
            return numberA / numberB;
        }
    }
}