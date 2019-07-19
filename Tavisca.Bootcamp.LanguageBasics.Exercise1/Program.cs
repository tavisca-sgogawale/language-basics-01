using System;

using System.Text.RegularExpressions;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);

            //If user wants to test new data or equation
            Console.WriteLine("Enter Equation in the Form of 'A*B=C' With One '?' at Any Numeric Position");
            string equation = Console.ReadLine();
            Console.WriteLine("Enter Result Value of '?' in The Above Equation");
            int num = Convert.ToInt32(Console.ReadLine());
            Test(equation, num);
            
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            try
            {
                equation = equation.Replace('*', '=');
                string[] SplitedEquation = Regex.Split(equation, "=");
                string Operand1 = SplitedEquation[0];
                string Operand2 = SplitedEquation[1];
                string RHS_Result = SplitedEquation[2]; //RightHandSight resut
                int Result = 0;
                if (Operand1.Contains("?"))
                {
                    Result = int.Parse(RHS_Result) / int.Parse(Operand2);
                    if (int.Parse(RHS_Result) % int.Parse(Operand2) !=0 || Operand1.Length != Result.ToString().Length)
                    {
                        return -1;
                    }
                    else
                    {
                        char result_string = ((int)Result).ToString()[Operand1.IndexOf('?')];
                        return int.Parse(result_string.ToString());
                    }
                 }
                else if (Operand2.Contains("?"))
                {
                    Result = int.Parse(RHS_Result) / int.Parse(Operand1);
                    if (int.Parse(RHS_Result) % int.Parse(Operand1) != 0 || Operand2.Length!=Result.ToString().Length)
                    {
                        return -1;
                    }
                    else
                    {
                        char DigitToFind = ((int)Result).ToString()[Operand2.IndexOf('?')];
                        return int.Parse(DigitToFind.ToString());
                    }
                }
                else
                {
                    Result = int.Parse(Operand1) * int.Parse(Operand2);
                    char DigitToFind = ((int)Result).ToString()[RHS_Result.IndexOf('?')];
                    return int.Parse(DigitToFind.ToString());
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw new NotImplementedException();
            }
        }
    }
}
