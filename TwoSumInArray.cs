using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    class TwoSumInArray
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            var numAndIndex = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var curNumber = nums[i];
                var numberA = target - curNumber;

                if (numAndIndex.ContainsKey(numberA))
                {
                    return new int[] { numAndIndex[numberA], i };
                }

                numAndIndex[curNumber] = i;
            }
            return null;
        }

        public static void Main()
        {
            var result = TwoSum(new int[] { 11, 15, 2, 7 }, 9);
        }
    }
}
