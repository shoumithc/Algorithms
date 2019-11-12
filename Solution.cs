using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace Algorithms
{
    public class Solution1
    {

        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }

        static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
        {
            while (node != null)
            {
                textWriter.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    textWriter.Write(sep);
                }
            }
        }

        // Complete the removeDuplicates function below.

        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        //static SinglyLinkedListNode removeDuplicates(SinglyLinkedListNode head)
        //{
        //    foreach (Dictionary<int,> dictionary in head)
        //    {

        //    }

        //}

        //static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //    int t = Convert.ToInt32(Console.ReadLine());

        //    for (int tItr = 0; tItr < t; tItr++)
        //    {
        //        SinglyLinkedList llist = new SinglyLinkedList();

        //        int llistCount = Convert.ToInt32(Console.ReadLine());

        //        for (int i = 0; i < llistCount; i++)
        //        {
        //            int llistItem = Convert.ToInt32(Console.ReadLine());
        //            llist.InsertNode(llistItem);
        //        }

        //        SinglyLinkedListNode llist1 = removeDuplicates(llist.head);

        //        PrintSinglyLinkedList(llist1, " ", textWriter);
        //        textWriter.WriteLine();
        //    }

        //    textWriter.Flush();
        //    textWriter.Close();
        //}

        //public static void Main()
        //{
        //    using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
        //        while (!reader.EndOfStream)
        //        {
        //            List<int> integers = new List<int>();
        //            string line = reader.ReadLine();
        //            string[] arrayofIntegers = line.Split(',');
        //            foreach (var arrayofInteger in arrayofIntegers)
        //            {
        //                if (!string.IsNullOrEmpty(arrayofInteger))
        //                {
        //                    integers.Add(Convert.ToInt32(arrayofInteger));
        //                }
        //            }
        //            int answer = CalculateClosestToZero(integers);
        //            Console.WriteLine(answer);
        //        }
        //}

        static Dictionary<int, string> RefDictionary = new Dictionary<int, string>()
        {
            {1, "A"},
            {2, "B"},
            {3, "C"},
            {4, "D"},
            {5, "E"},
            {6, "F"},
            {7, "G"},
            {8, "H"},
            {9, "I"},
            {10, "J"},
            {11, "K"},
            {12, "L"},
            {13, "M"},
            {14, "N"},
            {15, "O"},
            {16, "P"},
            {17, "Q"},
            {18, "R"},
            {19, "S"},
            {20, "T"},
            {21, "U"},
            {22, "V"},
            {23, "W"},
            {24, "X"},
            {25, "Y"},
            {26, "Z"},
            {27, "0"},
            {28, "1"},
            {29, "2"},
            {30, "3"},
            {31, "4"},
            {32, "5"},
            {33, "6"},
            {34, "7"},
            {35, "8"},
            {36, "9"}
        };
        public static string GenerateSequence(int col)
        {
            if (col >= 1 && col <= 36)
            {
                string schars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return schars[col - 1].ToString();
            }
            int div = col / 36;
            int mod = col % 36;
            if (mod == 0)
            {
                mod = 36; div--;
            }
            return GenerateSequence(div) + GenerateSequence(mod);
        }
        public static int GetCol(string refCol)
        {
            
            if (refCol.Length == 1)
            {
                int col = RefDictionary.FirstOrDefault(x => x.Value == refCol[0].ToString()).Key;
                return col;
            }
            if (refCol.Length == 2)
            { 
                int col = (RefDictionary.FirstOrDefault(x => x.Value == refCol[0].ToString()).Key * 36) + RefDictionary.FirstOrDefault(x => x.Value == refCol[1].ToString()).Key;
                return col;
            }
            
            return 0;
        }

        //static void Main(string[] args)
        //{

        //    for (int i = 1; i < 250; i++)
        //    {
        //        string refCol = GenerateSequence(i);
        //        Console.WriteLine(i + "---" + refCol + "---" + GetCol(refCol));
        //    }

        //}
        public static int CalculateClosestToZero(List<int> arrayofIntegers)
        {
            var nearest = arrayofIntegers.OrderBy(x => Math.Abs((int)x - 0)).First();
            return nearest;
        }
        
    }
        
}