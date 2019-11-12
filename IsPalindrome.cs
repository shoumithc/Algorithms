using System;
using System.Text;

namespace Algorithms
{
    public class IsPalindrome
    {
        public static bool IsaPalindrome(int x)
        {
            // Special cases:
            // As discussed above, when x < 0, x is not a palindrome.
            // Also if the last digit of the number is 0, in order to be a palindrome,
            // the first digit of the number also needs to be 0.
            // Only 0 satisfy this property.
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            int reverted = 0;
            while (x > reverted)
            {
                reverted = reverted * 10 + (x % 10);
                x = x / 10;
            }
            return x == reverted || x == reverted / 10;
        }

        public static bool IsaPalindrome(string str)
        {
            // Special cases:
            // As discussed above, when x < 0, x is not a palindrome.
            // Also if the last digit of the number is 0, in order to be a palindrome,
            // the first digit of the number also needs to be 0.
            // Only 0 satisfy this property.
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            
            int lengthToRevert = str.Length / 2;
            int i = str.Length-1;
            StringBuilder revertedString = new StringBuilder();
            while (lengthToRevert>0)
            {
                revertedString.Append(str[i]);
                i--;
                lengthToRevert--;
            }
            return revertedString.ToString() == str.Substring(0, str.Length / 2);
        }


        public static bool IsaPalindrome1(string str)
        {
            int lengthToBeReversed = str.Length / 2;
            int stringLength = str.Length - 1;
            System.Text.StringBuilder reversedString = new StringBuilder();
            while (lengthToBeReversed > 0)
            {
                reversedString.Append(str[stringLength]);
                stringLength--;
                lengthToBeReversed--;
            }
            return str.Substring(0, str.Length / 2) == reversedString.ToString();
        }

        //public static void Main()
        //{
        //    bool isPalindromeNumber = IsaPalindrome(1222221);
        //    var isapalindrome = IsaPalindrome1("abswefewrbba");
        //}



    }
}