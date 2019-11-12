using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class Solution
    {
        public int MyAtoi(string str)
        {
            Queue<char> charQueue = new Queue<char>();
            StringBuilder strBuilder = new StringBuilder();
            long res = 0;
            var sign = 1;
            str = str.Trim();
            if (string.IsNullOrEmpty(str)) return 0;
            var index = 0;
            if (str[0] == '+' || str[0] == '-')
            {
                sign = str[0] == '+' ? 1 : -1;
                index++;
            }
            while (index < str.Length)
            {
                if (!char.IsNumber(str[index]))
                {
                    break;
                }
                //  res = res*10 + str[index] - '0';                 
                //  if (res * sign > int.MaxValue) return int.MaxValue;
                //  if (res * sign < int.MinValue) return int.MinValue;
                charQueue.Enqueue(str[index]);
                index++;
            }
            if (charQueue.Count > 0)
            {
                for (int i = 0; charQueue.Count > 0; i++)
                {
                    strBuilder.Append(charQueue.Dequeue());
                }
                if (Convert.ToDouble(strBuilder.ToString()) * sign > int.MaxValue) return int.MaxValue;
                if (Convert.ToDouble(strBuilder.ToString()) * sign < int.MinValue) return int.MinValue;
                res = Convert.ToInt64(strBuilder.ToString());              
            }
            return (int)res * sign;
        }
        public double findMedianSortedArrays(int[] input1, int[] input2)
        {
            //if input1 length is greater than switch them so that input1 is smaller than input2.
            if (input1.Length > input2.Length)
            {
                return findMedianSortedArrays(input2, input1);
            }
            int x = input1.Length;
            int y = input2.Length;

            int low = 0;
            int high = x;
            while (low <= high)
            {
                int partitionX = (low + high) / 2;
                int partitionY = (x + y + 1) / 2 - partitionX;

                //if partitionX is 0 it means nothing is there on left side. Use -INF for maxLeftX
                //if partitionX is length of input then there is nothing on right side. Use +INF for minRightX
                int maxLeftX = (partitionX == 0) ? Int32.MinValue : input1[partitionX - 1];
                int minRightX = (partitionX == x) ? Int32.MaxValue : input1[partitionX];

                int maxLeftY = (partitionY == 0) ? Int32.MinValue : input2[partitionY - 1];
                int minRightY = (partitionY == y) ? Int32.MaxValue : input2[partitionY];

                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {
                    //We have partitioned array at correct place
                    // Now get max of left elements and min of right elements to get the median in case of even length combined array size
                    // or get max of left for odd length combined array size.
                    if ((x + y) % 2 == 0)
                    {
                        return ((double)Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2;
                    }
                    else
                    {
                        return (double)Math.Max(maxLeftX, maxLeftY);
                    }
                }
                else if (maxLeftX > minRightY)
                { //we are too far on right side for partitionX. Go on left side.
                    high = partitionX - 1;
                }
                else
                { //we are too far on left side for partitionX. Go on right side.
                    low = partitionX + 1;
                }
            }

            //Only we we can come here is if input arrays were not sorted. Throw in that scenario.
            throw new ArgumentException();
        }

        //public static void Main(string[] args)
        //{
        //    Solution solution = new Solution();
        //    // solution.MyAtoi("20000000000000000000");
        //    int[] A = { 1, 3, 8, 9, 15 };
        //    int[] B = { 7, 11, 19, 21, 18, 25 };
        //   // double result = solution.findMedianSortedArrays(A, B);
        //  //   var answers = Combinations.CombinationsRosettaWoRecursion(B, 2);
        //    int total = DiverseDeputation(3, 2);
        //}
        //public static IEnumerable<T[]> CombinationsRosettaWoRecursion<T>(T[] array, int m)
        //{
        //    if (array.Length < m)
        //        throw new ArgumentException("Array length can't be less than number of selected elements");
        //    if (m < 1)
        //        throw new ArgumentException("Number of selected elements can't be less than 1");
        //    T[] result = new T[m];
        //    foreach (int[] j in CombinationsRosettaWoRecursion(m, array.Length))
        //    {
        //        for (int i = 0; i < m; i++)
        //        {
        //            result[i] = array[j[i]];
        //        }
        //        yield return result;
        //    }
        //}

        public static int DiverseDeputation(int m, int w)
        {
            int total = 0;
            if (m > 0 && w > 0 && (m + w) >= 3)
            {
                total = nCr(m + w, 3) - ((m >= 3 ? nCr(m, 3) : 0) + (w >= 3 ? nCr(w, 3) : 0));
            }
            return total;
        }

        static int nCr(int n, int r)
        {
            return fact(n) / (fact(r) *
                              fact(n - r));
        }

        // Returns factorial of n 
        static int fact(int n)
        {
            int res = 1;
            for (int i = 2; i <= n; i++)
                res = res * i;
            return res;
        }
    }

    static class Combinations
    {
        // Enumerate all possible m-size combinations of [0, 1, ..., n-1] array
        // in lexicographic order (first [0, 1, 2, ..., m-1]).
        private static IEnumerable<int[]> CombinationsRosettaWoRecursion(int m, int n)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>(m);
            stack.Push(0);
            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();
                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index != m) continue;
                    yield return (int[])result.Clone(); // thanks to @xanatos
                    //yield return result;
                    break;
                }
            }
        }
    }
}
