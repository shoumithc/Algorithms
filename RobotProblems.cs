using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class RobotProblems
    {
        public static int UniquePaths(int m, int n)
        {
            return GetAllUniquePaths(1, 1, m, n);
            
        }

        public static int GetAllUniquePaths(int m, int n, int mMax, int nMax)
        {
            if (m == mMax || n == nMax)
                return 1;
            return (GetAllUniquePaths(m + 1, n, mMax, nMax) + GetAllUniquePaths(m, n + 1, mMax, nMax));
        }

        public static int CountPaths(int m, int n)
        {
            int[,] T = new int[m,n];
            for(int i=0; i<m; i++){
                T[i,0] = 1;
            }
        
            for(int i=0; i<n; i++){
                T[0,i] = 1;
            }
            for(int i=1; i<m; i++){
                for(int j=1; j<n; j++){
                    T[i,j] = T[i - 1,j] + T[i,j - 1];
                }
            }
            return T[m - 1,n- 1];
        }

        //public static void Main()
        //{
        //    Console.WriteLine("recursive way using Backtracking, not efficient" +UniquePaths(3, 2));
        //    Console.WriteLine("Matrix Dynamic Programming, efficient" + CountPaths(3, 2));
        //}
    }
}
