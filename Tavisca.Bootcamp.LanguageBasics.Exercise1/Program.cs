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
                if (eqArr[0].Contains("?"))
                {
                    return findAns(eqArr[2], eqArr[1], eqArr[0], "/");
                }
                else if (eqArr[1].Contains("?"))
                {
                    return findAns(eqArr[2], eqArr[0], eqArr[1], "/");
                }
                else
                {
                    return findAns(eqArr[0], eqArr[1], eqArr[2], "*");
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw new NotImplementedException();
            }
        }

        public static int findAns(string equation1, string equation2, string equation3, string operation)
        {
            int result = 0;
            switch (operation)
            {
                case "/":
                    result = int.Parse(equation1) / int.Parse(equation2);
                    if (int.Parse(equation1) % int.Parse(equation2) != 0 || equation3.Contains(result.ToString()))
                    {
                        return -1;
                    }
                    break;

                case "*":
                    result = int.Parse(equation1) * int.Parse(equation2);
                    break;

                default: return -1;

            }
            char result_string = ((int)result).ToString()[equation3.IndexOf('?')];
            return int.Parse(result_string.ToString());
        }
    }
}
