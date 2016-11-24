using System;

namespace Calculator_SimpleFacotry
{
    class OperatorFactory
    {
        public static Operator CreateOperator(string strOperate)
        {
            switch (strOperate)
            {
                case "+": return new AddOperator();
                case "-": return new SubtractOperator();
                case "*": return new MultiplyOpertator();
                case "/": return new DivideOperator();
                default:  throw new NotImplementedException();
            }
        }
    }
}