using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class AllCombinationsOfAString
    {
        public static void Permutation(string permutation, int left, int right, List<string> permutations)
        {
            if(left==right)
                permutations.Add(permutation);
            for (int i = left; i <= right; i++)
            {
                permutation = Swap(permutation, left, i);
                Permutation(permutation,left+1,right,permutations);
                permutation = Swap(permutation, left, i);
            }
        }

        public static string Swap(string permutation, int i, int j)
        {
            var chararray = permutation.ToCharArray();
            var temp = chararray[i];
            chararray[i] = chararray[j];
            chararray[j] = temp;
            return new string(chararray);
        }

        // Driver Code 
        //static public void Main()
        //{
        //    Console.WriteLine("First Test");
        //    string name = "shou";
        //    List<string> permutations = new List<string>();
        //    int right = name.Length - 1;
        //    Permutation(name,0,right,permutations);
        //}
    }
}
