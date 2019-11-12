using System.Collections.Generic;

namespace Algorithms
{
    public class LongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> uniqueChars = new Dictionary<char, int>();
            int longestSubstring = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (uniqueChars.ContainsKey(s[i]))
                {
                    longestSubstring = longestSubstring < uniqueChars.Count ? uniqueChars.Count : longestSubstring;
                    int index = uniqueChars[s[i]];
                    uniqueChars = new Dictionary<char, int>();
                    uniqueChars.Add(s[index + 1], index + 1);
                    i = index + 1;
                    continue;
                }
                uniqueChars.Add(s[i],i);
            }
            return longestSubstring < uniqueChars.Count ? uniqueChars.Count : longestSubstring;
        }

        //public static void Main()
        //{
        //    LongestSubstring longestSubstring = new LongestSubstring();
        //    int x = longestSubstring.LengthOfLongestSubstring("dddddd");
        //}

    }
}