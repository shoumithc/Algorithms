using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{

    class RallyHealth
    {
        public int solution(string[] T, string[] R)
        {
            int result = 0;
            Dictionary<double, bool> tests = new Dictionary<double, bool>();

            for (var index = 0; index < T.Length; index++)
            {
                string testName = T[index];
                string testResult = R[index];
                bool testResultValue = testResult == "OK";
                double testNumber = GetTestNumber(testName);
                if (tests.ContainsKey(testNumber))
                {
                    tests[testNumber] = tests[testNumber] && testResultValue;
                }
                else
                {
                    tests.Add(testNumber,testResultValue);
                }
            }
            result = tests.Count(x => x.Value);
            return result * 100 / tests.Count;
        }

        public double GetTestNumber(string testName)
        {
            double testNumber = 0;
            var charArray = testName.ToCharArray();
            int firstIndex = GetFirstIndexOfNUmber(testName);
            if (firstIndex >= 0)
            {
                testNumber = Char.GetNumericValue(charArray[firstIndex]);
                for (int i = firstIndex+1; i < charArray.Length; i++)
                {
                    if (Char.IsDigit(charArray[i]))
                    {
                        double val = Char.GetNumericValue(charArray[i]) ;
                        testNumber = testNumber * 10 + val;
                    }
                }
            }
            return testNumber;
        }

        public int GetFirstIndexOfNUmber(string testName)
        {
            var charArray = testName.ToCharArray();
            for (var index = 0; index < charArray.Length; index++)
            {
                var val = charArray[index];
                if (Char.IsDigit(val))
                {
                    return index;
                }
            }
            return 0;
        }

        //public static void Main()
        //{
        //    string[] testNames = {"test1a", "test2", "test1b", "test1c", "test3"};
        //    string[] testResults = { "Wrong answer", "OK", "Runtime error", "OK", "Time limit exceeded"};
        //    RallyHealth r = new RallyHealth();
        //    int result = r.solution(testNames, testResults);
        //}
    }
}
