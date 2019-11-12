using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class NCRConbination
    {
        public static string[] array;
        public static List<Combination> conbinationList;

        public static int[] arrayInt;
        public static List<CombinationInt> conbinationListInt;
        private static IEnumerable<string[]> Combinations(int start, int level)
        {
            for (int i = start; i < array.Length; i++)
                if (level == 1)
                    yield return new string[] {array[i]};
                else
                    foreach (string[] combination in Combinations(i + 1, level - 1))
                    {

                        var z = new string[combination.Length + 1];
                        z[0] = array[i];
                        combination.CopyTo(z,1);
                        yield return  z;
                    }
                       
        }

        //private static IEnumerable<int[]> CombinationsInt(int start, int level)
        //{
        //    for (int i = start; i < arrayInt.Length; i++)
        //        if (level == 1)
        //            yield return new int[] { arrayInt[i] };
        //        else
        //            foreach (int[] combination in CombinationsInt(i + 1, level - 1))
        //            {

        //                var z = new int[combination.Length + 1];
        //                z[0] = arrayInt[i];
        //                combination.CopyTo(z, 1);
        //                yield return z;
        //            }

        //}


        public static IEnumerable<IEnumerable<int>> CombinationsInt(int start, int level, int[] arrayInt)
        {
            for (int i = start; i < arrayInt.Length; i++)
            {
                if (level == 1)
                {
                    IEnumerable<int> temp = new List<int> {arrayInt[i]};
                    yield return temp;
                }
                else
                    foreach (var combination in CombinationsInt(i + 1, level - 1,arrayInt))
                    {

                        List<int> z = new List<int>{ arrayInt[i] };
                        z.AddRange(combination);
                        yield return z;
                    }
            }
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            int r = 3;
            IList<IList<int>> result = new List<IList<int>>(); 
            var combinations = CombinationsInt(0, r, nums);
            conbinationListInt = new List<CombinationInt>();
            foreach (var item in combinations)
            {
                int sum = 0;
                foreach (var i in item)
                {
                    sum += i;
                }
                if (sum == 0)
                {
                    var res = item.ToList().OrderBy(x=>x).ToList();
                    bool isduplicate = false;
                    foreach (var uniqueEl in result)
                    {
                        int countduplicates = 0;
                        for (var index = 0; index < uniqueEl.Count; index++)
                        {
                            if (res[index] == uniqueEl[index])
                                countduplicates++;
                        }
                        if (countduplicates == res.Count)
                            isduplicate = true;
                    }
                    if(!isduplicate)
                    result.Add(res);
                }
            }
       //     result = RemoveDuplicates(result);
            return result;

        }


        public static IList<IList<int>> RemoveDuplicates(IList<IList<int>> integerArray)
        {
            Dictionary<IList<int>, int> uniqueNumbers = new Dictionary<IList<int>, int>();
            if (integerArray.Count == 0 || integerArray.Count == 1)
            {
                return integerArray;
            }
            for (var index = 0; index < integerArray.Count; index++)
            {
                var val = integerArray[index];
                if (!uniqueNumbers.ContainsKey(val))
                    uniqueNumbers.Add(val, 1);
            }
            return uniqueNumbers.Keys.ToArray();
        }

        public static int[] RemoveDuplicates(int[] integerArray)
        {
            Dictionary<int,int> uniqueNumbers = new Dictionary<int, int>();
            if (integerArray.Length == 0 || integerArray.Length == 1)
            {
                return integerArray;
            }
            for (var index = 0; index < integerArray.Length; index++)
            {
                var val = integerArray[index];
                if (!uniqueNumbers.ContainsKey(val))
                    uniqueNumbers.Add(val, 1);
            }
            return uniqueNumbers.Keys.ToArray();
        }

      //  public static void Main(string[] args)
      //  {
      //      //int r = 2;
      //      //array = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10"};
      //      //var combinations = Combinations(0, r);
      //      //conbinationList = new List<Combination>();
      //      //foreach (var item in combinations)
      //      //{
      //      //    var Combination = new Combination(r);
      //      //    Combination.SizeCombination = item;
      //      //    Console.WriteLine(item.First()+","+item.Last());
      //      //    conbinationList.Add(Combination);
      //      //}

      //      int r = 3;
      //      arrayInt = new int[]{-1, 0, 1, 2, -1, -4};
      //      var combinations = CombinationsInt(0, r,arrayInt);
      //      conbinationListInt = new List<CombinationInt>();
      //      foreach (var item in combinations)
      //      {
      //          var Combination = new CombinationInt(r);
      //          Combination.SizeCombination = item.ToArray();
      //          Console.WriteLine(item.First() + "," + item.Last());
      //          conbinationListInt.Add(Combination);
      //      }

      ////      arrayInt = RemoveDuplicates(arrayInt);
      //      var result = ThreeSum(arrayInt);

      //  }
    }

    public class Combination
    {
        public Combination(int size)
        {
            SizeCombination = new string[size];
        }
        public string[] SizeCombination { get; set; }
    }

    public class CombinationInt
    {
        public CombinationInt(int size)
        {
            SizeCombination = new int[size];
        }
        public int[] SizeCombination { get; set; }
    }
}
