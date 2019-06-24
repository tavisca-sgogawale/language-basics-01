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
            string eqn = Console.ReadLine();
            Console.WriteLine("Enter Result Value of '?' in The Above Equation");
            int num = Convert.ToInt32(Console.ReadLine());
            Test(eqn, num);
            
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
                string[] eqArr = Regex.Split(equation, "=");
                string a = eqArr[0];
                string b = eqArr[1];
                string c = eqArr[2];
                int result = 0;
                if (a.Contains("?"))
                {
                    result = int.Parse(c) / int.Parse(b);
                    if (int.Parse(c) % int.Parse(b) !=0 || a.Length != result.ToString().Length)
                    {
                        return -1;
                    }
                    else
                    {
                        char result_string = ((int)result).ToString()[a.IndexOf('?')];
                        return int.Parse(result_string.ToString());
                    }
                 }
                else if (b.Contains("?"))
                {
                    result = int.Parse(c) / int.Parse(a);
                    if (int.Parse(c) % int.Parse(a) != 0 || b.Length!=result.ToString().Length)
                    {
                        return -1;
                    }
                    else
                    {
                        char result_string = ((int)result).ToString()[b.IndexOf('?')];
                        return int.Parse(result_string.ToString());
                    }
                }
                else
                {
                    result = int.Parse(a) * int.Parse(b);
                    char result_string = ((int)result).ToString()[c.IndexOf('?')];
                    return int.Parse(result_string.ToString());
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
