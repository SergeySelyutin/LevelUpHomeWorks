using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20161110_Arithmeticparser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите арифметическое выражение:");
            string expr = Console.ReadLine();
            MatchParser p = new MatchParser();
            Console.WriteLine("Результат = {0}", p.Parse(expr));
            Console.ReadKey();
        }
    }

    class Result
    {

        public double acc;
        public string rest;

        public Result(double acc, string rest)
        {
            this.acc = acc;
            this.rest = rest;
        }
    }

    public class MatchParser
    {
        private Dictionary<string, double> variables;

        public MatchParser()
        {
            variables = new Dictionary<string, double>();
        }

        public void setVariable(string variableName, double variableValue)
        {
            variables.Add(variableName, variableValue);
        }

        public double getVariable(string variableName)
        {
            if (!variables.ContainsKey(variableName))
            {
                Console.WriteLine("Error: Try get unexists variable '" + variableName + "'");
                return 0.0;
            }
            return variables[variableName];
        }

        public double Parse(string s)
        {
            Result result = PlusMinus(s);
            if (result.rest.Length != 0)
            {
                Console.WriteLine("Error: can't full parse");
                Console.WriteLine("rest: " + result.rest);
            }
            return result.acc;
        }

        private Result PlusMinus(string s)
        {
            Result current = MulDiv(s);
            double acc = current.acc;

            while (current.rest.Length > 0)
            {
                if (!(current.rest[0] == '+' || current.rest[0] == '-')) break;

                char sign = current.rest[0];
                string next = current.rest.Substring(1);

                current = MulDiv(next);
                if (sign == '+')
                {
                    acc += current.acc;
                }
                else
                {
                    acc -= current.acc;
                }
            }
            return new Result(acc, current.rest);
        }

        private Result Bracket(string s)
        {
            char zeroChar = s[0];
            if (zeroChar == '(')
            {
                Result r = PlusMinus(s.Substring(1));
                if (r.rest.Length != 0 && r.rest[0] == ')')
                {
                    r.rest = r.rest.Substring(1);
                }
                else
                {
                    Console.WriteLine("Error: not close bracket");
                }
                return r;
            }
            return FunctionVariable(s);
        }

        private Result FunctionVariable(string s)
        {
            string f = "";
            int i = 0;

            while (i < s.Length && (Char.IsLetter(s[i]) || (Char.IsDigit(s[i]) && i > 0)))
            {
                f += s[i];
                i++;
            }
            if (f.Length != 0)
            {
                if (s.Length > i && s[i] != '(')
                {
                    return new Result(getVariable(f), s.Substring(f.Length));
                }
            }
            return Num(s);
        }

        private Result MulDiv(string s)
        {
            Result current = Bracket(s);

            double acc = current.acc;
            while (true)
            {
                if (current.rest.Length == 0)
                {
                    return current;
                }
                char sign = current.rest[0];
                if ((sign != '*' && sign != '/')) return current;

                string next = current.rest.Substring(1);
                Result right = Bracket(next);

                if (sign == '*')
                {
                    acc *= right.acc;
                }
                else
                {
                    acc /= right.acc;
                }

                current = new Result(acc, right.rest);
            }
        }

        private Result Num(string s)
        {
            int i = 0;
            int dot_cnt = 0;
            bool negative = false;
            if (s[0] == '-')
            {
                negative = true;
                s = s.Substring(1);
            }
            while (i < s.Length && (Char.IsDigit(s[i]) || s[i] == '.'))
            {
                if (s[i] == '.' && ++dot_cnt > 1)
                {
                    throw new Exception("not valid number '" + s.Substring(0, i + 1) + "'");
                }
                i++;
            }
            if (i == 0)
            {
                throw new Exception("can't get valid number in '" + s + "'");
            }

            double dPart = double.Parse(s.Substring(0, i));
            if (negative) dPart = -dPart;
            string restPart = s.Substring(i);

            return new Result(dPart, restPart);
        }
    }
} 
