using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class ParanthesisGeneration
    {
        public IList<String> GenerateParenthesis(int n)
        {
            List<String> ans = new List<string>();
            Backtrack(ans, "", 0, 0, n);
            return ans;
        }

        public void Backtrack(List<String> ans, String cur, int open, int close, int max)
        {
            if (cur.Length == max * 2)
            {
                ans.Add(cur);
                return;
            }

            if (open < max)
                Backtrack(ans, cur + "(", open + 1, close, max);
            if (close < open)
                Backtrack(ans, cur + ")", open, close + 1, max);
        }

        public void BackTrackParanthesis(List<string> answers, String cur, int open, int close, int max)
        {
            if (cur.Length == max * 2)
            {
                answers.Add(cur);
                return;
            }
            if (open < max)
            {
                cur += "(";
                BackTrackParanthesis(answers, cur,open+1,close,max);
            }
            if (close < open)
            {
                cur += ")";
                BackTrackParanthesis(answers, cur, open, close + 1, max);
            }

        }


        //public static void Main()
        //{
        //    var paranthesisGeneration = new ParanthesisGeneration();
        //    IList<string> list = paranthesisGeneration.GenerateParenthesis(3);
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        string paranthesis = list[i];
        //        Console.WriteLine("{0}-{1}", i, paranthesis);
        //    }

        //}

    }
}
