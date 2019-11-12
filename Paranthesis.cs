using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class Paranthesis
    {
        public static int MinAddToMakeValid(string S)
        {
            Stack<char> paranthesisStack = new Stack<char>();
            int missingParanthesisCount = 0;
            foreach (char paranthesis in S)
            {
                if (paranthesis == '(')
                {
                    paranthesisStack.Push(paranthesis);
                }
                if (paranthesis == ')')
                {
                    char closingParanthesis;
                    if (paranthesisStack.TryPop(out closingParanthesis))
                    {

                    }
                    else
                    {
                        missingParanthesisCount += 1;
                    }
                }
            }
            return missingParanthesisCount+paranthesisStack.Count;
        }

        //public static void Main()
        //{
        //    int count = MinAddToMakeValid("()()()(((())))()())))())()()()()))()(()");
        //}
    }
}
