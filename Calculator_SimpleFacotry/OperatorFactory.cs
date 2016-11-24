using System;
using Calculator_SimpleFactory;

namespace Calculator_SimpleFactory
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