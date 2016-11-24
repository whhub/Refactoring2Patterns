namespace Calculator_SimpleFactory
{
    class MultiplyOpertator : Operator
    {
        public override double Operate(double numberA, double numberB)
        {
            return numberA*numberB;
        }
    }
}