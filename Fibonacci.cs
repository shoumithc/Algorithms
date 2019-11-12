using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class Fibonacci
    {
        public static int Fib(int N)
        {
            if (N == 0) return 0;

            int a = 0, b = 1;

            for (var i = 2; i < N; i++)
            {
                var c = a + b;
                a = b;
                b = c;
            }

            return a + b;
        }

        public static string AllFibonacci(int N)
        {
            string fibonaseque = "0";
            if (N == 0) return fibonaseque;

            int a = 0, b = 1;
            fibonaseque= $"{fibonaseque},1";
            if (N == 1)
                return fibonaseque;
            for (var i = 2; i < N; i++)
            {
                var c = a + b;
                fibonaseque = $"{fibonaseque},{c}";
                a = b;
                b = c;
            }

            return fibonaseque;
        }

        //public static void Main()
        //{
        //   // var fibon=Fib(10);
        //    var fibon = AllFibonacci(10);
        //}
    }
}
