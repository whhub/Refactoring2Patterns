using System;

namespace Calculator_SimpleFacotry
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("请输入数字A：");
            var strNumberA = Console.ReadLine();
            Console.WriteLine("请输入运算符号（+、-、*、/）：");
            var strOperate = Console.ReadLine();
            Console.WriteLine("请输入数字B：");
            var strNumberB = Console.ReadLine();
            var strResult = "";

            try
            {
                switch (strOperate)
                {
                    case "+":
                        strResult = Convert.ToString(Convert.ToDouble(strNumberA) + Convert.ToDouble(strNumberB));
                        break;
                    case "-":
                        strResult = Convert.ToString(Convert.ToDouble(strNumberA) - Convert.ToDouble(strNumberB));
                        break;
                    case "*":
                        strResult = Convert.ToString(Convert.ToDouble(strNumberA)*Convert.ToDouble(strNumberB));
                        break;
                    case "/":
                        if (strNumberB != "0")
                            strResult = Convert.ToString(Convert.ToDouble(strNumberA)/Convert.ToDouble(strNumberB));
                        else
                            strResult = "除数不能为零";
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("您的输入有错：" + e.Message);
            }
            Console.WriteLine("结果是：" + strResult);
        }
    }
}