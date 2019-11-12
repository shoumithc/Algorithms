using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Algorithms
{
    public class BFS
    {
            public int NumIslands(char[,] grid)
            {
                if (grid == null || grid.Length == 0)
                {
                    return 0;
                }

                int nr = grid.GetLength(0);
                int nc = grid.GetLength(1);
                int num_islands = 0;

                for (int r = 0; r < nr; ++r)
                {
                    for (int c = 0; c < nc; ++c)
                    {
                        if (grid[r,c] == '1')
                        {
                            ++num_islands;
                            grid[r,c] = '0'; // mark as visited
                            Queue<int> neighbors = new Queue<int>();
                            neighbors.Enqueue(r * nc + c);    //Calculate position
                            while (neighbors.Any())
                            {
                                int id = neighbors.Dequeue();
                                int row = id / nc;
                                int col = id % nc;
                                if (row - 1 >= 0 && grid[row - 1,col] == '1')
                                {
                                    neighbors.Enqueue((row - 1) * nc + col);
                                    grid[row - 1,col] = '0';
                                }
                                if (row + 1 < nr && grid[row + 1,col] == '1')
                                {
                                    neighbors.Enqueue((row + 1) * nc + col);
                                    grid[row + 1,col] = '0';
                                }
                                if (col - 1 >= 0 && grid[row,col - 1] == '1')
                                {
                                    neighbors.Enqueue(row * nc + col - 1);
                                    grid[row,col - 1] = '0';
                                }
                                if (col + 1 < nc && grid[row,col + 1] == '1')
                                {
                                    neighbors.Enqueue(row * nc + col + 1);
                                    grid[row,col + 1] = '0';
                                }
                            }
                        }
                    }
                }

                return num_islands;
            }

        //public static void Main()
        //{
        //    BFS bfs = new BFS();
        //    char[,] grid =
        //    {
        //        {'1', '1', '1', '1', '0'},
        //        {'1', '1', '0', '1', '0'},
        //        {'1', '1', '0', '0', '0'},
        //        {'0', '0', '0', '1', '0'}
        //    };
        //    int island = bfs.NumIslands(grid);
        //}
    }
}