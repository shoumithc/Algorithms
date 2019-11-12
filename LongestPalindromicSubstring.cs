using System;
using System.Linq;

namespace Algorithms
{
    public class LongestPalindromicSubstring
    {
        public string LongestPalindrome(string s)
        {
            var len = s.Length;
            if (len == 1 || string.IsNullOrEmpty(s)) return s;
            int[] p = new int[2 * len + 1];
            for (int i = 1; i < 2 * len; i++)
            {
                if (i % 2 != 0)
                {
                    var pivot = (i - 1) / 2;
                    for (int j = 1; pivot - j > -1 && pivot + j < len; j++)
                    {
                        if (s[pivot - j] == s[pivot + j]) p[i] = 2 * j + 1;
                        else break;
                    }
                }
                else
                {
                    var R = i / 2;
                    var L = R - 1;
                    for (int j = 0; L - j > -1 && R + j < len; j++)
                    {
                        if (s[L - j] == s[R + j]) p[i] = 2 * j + 2;
                        else break;
                    }
                }
            }
            int maxValue = p.Max();
            // return string.Join("", p);
            int maxIndex = p.ToList().IndexOf(maxValue);
            return s.Substring((maxIndex - maxValue) / 2, Math.Max(1, maxValue));
        }

        //public static void Main()
        //{
        //    LongestPalindromicSubstring longestPalindromicSubstring = new LongestPalindromicSubstring();
        //    var palindrome = longestPalindromicSubstring.LongestPalindrome("abaxabaxabybaxabyb");
        //}
    }
}