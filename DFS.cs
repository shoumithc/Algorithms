namespace Algorithms
{
    public class DFS
    {
        void dfs(char[,] grid, int r, int c)
        {
            int nr = grid.GetLength(0);
            int nc = grid.GetLength(1);

            if (r < 0 || c < 0 || r >= nr || c >= nc || grid[r,c] == '0')
            {
                return;
            }

            grid[r,c] = '0';
            dfs(grid, r - 1, c);
            dfs(grid, r + 1, c);
            dfs(grid, r, c - 1);
            dfs(grid, r, c + 1);
        }

        public int numIslands(char[,] grid)
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
                        dfs(grid, r, c);
                    }
                }
            }

            return num_islands;
        }

        //public static void Main()
        //{
        //    DFS dfs = new DFS();
        //    char[,] grid =
        //    {
        //         {'1', '1', '1', '1', '0'},
        //         {'1', '1', '0', '1', '0'},
        //         {'1', '1', '0', '0', '0'},
        //         {'0', '0', '0', '0', '0'}
        //    };
        //    int island = dfs.numIslands(grid);
        //}
    }
}