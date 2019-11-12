using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class Argumnt
    {
        public string ArgName { get; set; }
        public string ArgValue { get; set; }
    }
    public class Overlapper
    {
        public DateRange FindOverlap(DateRange dateRange1, DateRange dateRange2)
        {
            if (dateRange1.End > dateRange2.End ||
                dateRange1.End == dateRange2.End && dateRange2.Begin > dateRange1.Begin)
            {
                return FindOverlap(dateRange2, dateRange1);
            }
            var duration2 = (dateRange2.End - dateRange2.Begin);
            var duration1 = (dateRange2.End - dateRange1.End);
            if (duration2 > duration1)
            {
                var overlap = new DateRange(dateRange2.Begin > dateRange1.Begin ? dateRange2.Begin : dateRange1.Begin, dateRange1.End);
                return overlap;
            }
            throw new Exception("The Date is in the future");
        }

        public string Format(DateTime date, DateTime current)
        {
            string timeElapsed = string.Empty;
            if (current >= date)
            {

                if ((current - date).Days == 0)
                {
                    if ((current - date).Hours == 0)
                    {
                        if ((current - date).Minutes == 0)
                        {
                            timeElapsed = "now";
                            return timeElapsed;
                        }
                        timeElapsed = (current - date).Minutes + " minute(s) ago";
                        return timeElapsed;

                    }
                    timeElapsed = (current - date).Hours + " hour(s) ago";
                    return timeElapsed;
                }
                int days = (current - date).Days;
                if (days >= 7)
                    timeElapsed = date.ToString(@"yyyy-MM-dd");
                else
                    timeElapsed = timeElapsed + " day(s) ago";
                return timeElapsed;
            }
            throw new Exception("The Date is in the future");
        }

        

        public int Validate(string[] args)
        {
          List<Argumnt>  argumentNameList = new List<Argumnt>();
            if (args.Any(x => x.ToLower() == "help"))
                return 0;
            for (var index = 0; index < args.Length; index++)
            {
                string arg = args[index];
                if (arg.StartsWith("-"))
                {
                    if ((index + 1) >= args.Length)
                        return -1;
                    string argval = args[index + 1];
                    if (string.IsNullOrEmpty(argval))
                        return -1;
                    var argumentName  = new Argumnt
                    {
                        ArgName = arg.ToLower(),
                        ArgValue = argval
                    };
                    argumentNameList.Add(argumentName);
                }
            }
            if (argumentNameList.Any())
            {
                foreach (var argumnt in argumentNameList)
                {
                    if (argumnt.ArgName.Contains("name"))
                    {
                        int length = argumnt.ArgValue.Length;
                        if (length >= 3 && length <= 10)
                        {
                            for (int i = 0; i < argumnt.ArgValue.Length; i++)
                            {
                                if (!Char.IsLetter(argumnt.ArgValue[i]))
                                    return -1;
                            }
                            return 0;
                        }
                    }

                    if (argumnt.ArgName.Contains("count"))
                    {
                            for (int i = 0; i < argumnt.ArgValue.Length; i++)
                            {
                                if (!Char.IsDigit(argumnt.ArgValue[i]))
                                    return -1;
                            }
                        int count = Convert.ToInt32(argumnt.ArgName);
                        if(count>=10 && count<=100)
                            return 0;
                        return -1;
                    }
                }
            }
            return -1;
        }

        //public static void Main()
        //{
        //    String data = "abc.bcd?sdd!lldf";

        //    //1. Build sentances array by splitting at . or ? or !
        //    String[] sentances = data.Split("\\.|\\?|\\!");
        //    Console.WriteLine(sentances);

        //    // 2. build word hash with size
        //    Dictionary<String, int> wordsHash = new Dictionary<String, int>();

        //    /**
        //     * Splitting sentance into words
        //     * and remove empty spaces for 
        //     * valid words.
        //     */
        //    int i = 1;
        //    foreach (String sent in sentances)
        //    {
        //        int count = 0;
        //        String[] words = sent.Split("\\s+");

        //        /**
        //         * Building hash to hold length of
        //         * the words, and respective word 
        //         * array.
        //         */
        //        foreach (String key in words)
        //        {
        //            if (key.Trim().Length > 0)
        //            {
        //                if (wordsHash.ContainsKey(i + ""))
        //                {
        //                    wordsHash.Add(i + "", wordsHash[i + ""] + 1);
        //                }
        //                else
        //                {
        //                    wordsHash.Add(i + "", count + 1);
        //                }
        //            }
        //        }
        //        i++;
        //    }

        //    // 3. Determine the maxium words
        //    int maxCount = wordsHash.Count().stream().max(Map.Entry.comparingByValue()).get().getValue();

        //   // return maxCount;

        //}
    }

    public class DateRange : IEquatable<DateRange>
    {
        public DateTime Begin { get; private set; }
        public DateTime End { get; private set; }

        public DateRange(DateTime begin, DateTime end)
        {
            Begin = begin;
            End = end;
        }

        public bool Equals(DateRange other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            return Begin == other.Begin && End == other.End;
        }
    }


    

}
