using System;

namespace Calculator_SimpleFacotry
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("请输入数字A：");
            var A = Console.ReadLine();
            Console.WriteLine("请输入运算符号（+、-、*、/）：");
            var B = Console.ReadLine();
            Console.WriteLine("请输入数字B：");
            var C = Console.ReadLine();
            var D = "";

            if (B == "+")
                D = Convert.ToString(Convert.ToDouble(A) + Convert.ToDouble(C));
            if (B == "-")
                D = Convert.ToString(Convert.ToDouble(A) - Convert.ToDouble(C));
            if (B == "*")
                D = Convert.ToString(Convert.ToDouble(A)*Convert.ToDouble(C));
            if (B == "/")
                D = Convert.ToString(Convert.ToDouble(A)/Convert.ToDouble(C));

            Console.WriteLine("结果是：" + D);
        }
    }
}