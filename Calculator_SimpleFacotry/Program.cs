using System;

namespace Calculator_SimpleFacotry
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("请输入数字A：");
            var strNumberA = Console.ReadLine();
            Console.WriteLine("请输入运算符号（+、-、*、/）：");
            var strOperate = Console.ReadLine();
            Console.WriteLine("请输入数字B：");
            var strNumberB = Console.ReadLine();
            double result = 0;

            try
            {
                var numberA = Convert.ToDouble(strNumberA);
                var numberB = Convert.ToDouble(strNumberB);
                var operater = OperatorFactory.CreateOperator(strOperate);
                result = operater.Operate(numberA, numberB);
            }
            catch (Exception e)
            {
                Console.WriteLine("您的输入有错：" + e.Message);
            }
            Console.WriteLine("结果是：" + result);
        }
    }
}