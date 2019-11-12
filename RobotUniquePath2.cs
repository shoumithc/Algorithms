using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    class RobotUniquePath2
    {
        public static string path = string.Empty;
        public static int UniquePathsWithObstaclesBFS(int[,] obstacleGrid)
        {
            int totalNumberOfPaths = 0;
            int totalRows = obstacleGrid.GetLength(0);
            int totalColumns = obstacleGrid.GetLength(1);
            Queue<int> pathQueue = new Queue<int>();
            if(obstacleGrid[0, 0] == 0)
            pathQueue.Enqueue(0);
            while (pathQueue.Any())
            {
                int position = pathQueue.Dequeue();
                int row = position / totalColumns;
                int col = position % totalColumns;
                if (row == totalRows - 1 && col == totalColumns - 1)
                    totalNumberOfPaths += 1;
                if (col+1 < totalColumns)
                {
                    if(obstacleGrid[row,col+1]==0)
                    pathQueue.Enqueue(position+1);
                }
                if (row + 1 < totalRows)
                {
                    if (obstacleGrid[row+1, col] == 0)
                        pathQueue.Enqueue(position + totalColumns);
                }
            }
            return totalNumberOfPaths;
        }

        public static string UniquePathsWithObstaclesDFS(int[,] obstacleGrid)
        {
            int totalRows = obstacleGrid.GetLength(0);
            int totalColumns = obstacleGrid.GetLength(1);
            String path;
            bool hasPath;
            path = DfsPathCalculator(obstacleGrid,0,0,totalRows,totalColumns,out hasPath);
            if(hasPath)
            return path;
            return String.Empty;
        }

        public static string DfsPathCalculator(int[,] obstacleGrid,int row, int col, int totalRows, int totalColumns,out bool hasPath)
        {
            hasPath = false;
            path+=(row*totalColumns+col);
            if (row == totalRows - 1 && col == totalColumns - 1 || hasPath)
            {
                hasPath = true;
                return path;
            }
            if (col + 1 < totalColumns)
            {
                if (obstacleGrid[row, col + 1] == 0)
                   return DfsPathCalculator(obstacleGrid,row, col+1, totalRows, totalColumns, out hasPath);
            }
            else if(row + 1 < totalRows)
            {
                if (obstacleGrid[row + 1, col] == 0)
                  return DfsPathCalculator(obstacleGrid,row+1, col, totalRows, totalColumns, out hasPath);
            }
            return path;
        }


        public static List<string> UniquePathsWithObstaclesDFS1(int[,] obstacleGrid)
        {
            int totalRows = obstacleGrid.GetLength(0);
            int totalColumns = obstacleGrid.GetLength(1);
            List<string> paths = new List<string>();            
            DfsPathCalculator1(obstacleGrid, 0, 0, totalRows, totalColumns, string.Empty,paths);
            return paths;
        }

        public static void DfsPathCalculator1(int[,] obstacleGrid, int row, int col, int totalRows, int totalColumns, string path, List<string> paths)
        {
            path += "-"+(row * totalColumns + col);
            if (row == totalRows - 1 && col == totalColumns - 1)
            {
                paths.Add(path);
                //path = string.Empty;
               // return;
            }
            if (col + 1 < totalColumns)
            {
                if (obstacleGrid[row, col + 1] == 0)
                    DfsPathCalculator1(obstacleGrid, row, col + 1, totalRows, totalColumns, path,paths);
            }
            else if (row + 1 < totalRows)
            {
                if (obstacleGrid[row + 1, col] == 0)
                    DfsPathCalculator1(obstacleGrid, row + 1, col, totalRows, totalColumns, path, paths);
            }
        }



        //public static void Main()
        //{
        //    int[,] intarray = new int[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        //    //int numberofPaths = UniquePathsWithObstaclesBFS(intarray);
        //    var path = UniquePathsWithObstaclesDFS1(intarray);
        //}





    }
}
