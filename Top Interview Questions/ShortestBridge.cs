using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class ShortestBridge
    {
        Queue<int[]> queue = new Queue<int[]>();
        int[][] dirs = new int[][] { 
            new int[] { 1, 0 },
            new int[] { -1, 0 },
            new int[] { 0, 1 },
            new int [] { 0, -1 } 
        };
        public int shortestBridge(int[][] A)
        {
            HashSet<string> visited = new HashSet<string>();


            int rows = A.Length;
            int cols = A[0].Length;

            bool found = false;

            for (int i = 0; i < rows; i++)
            {
                if(found)
                {
                    break;
                }
                for (int j = 0; j < cols; j++)
                {
                    if (A[i][j] == 1)
                    {
                        if (dfs(A, i, j, visited))
                        {
                            found = true;
                            break;
                        }
                    }
                }
            }


            // BFS

            var size = 0;
            int step = 0;
            while(queue.Count > 0)
            {
                size = queue.Count;
                while(size-- > 0)
                {
                    var dim = queue.Dequeue();
                    var row = dim[0];
                    var col = dim[1];

                    foreach(var dir in dirs)
                    {
                        var i = row + dir[0];
                        var j = col + dir[1];

                        if(i >= 0 && j >= 0 && i < rows && j < rows && !visited.Contains(i + "," + j) )
                        {
                            if (A[i][j] == 1)
                            {
                                return step;
                            }

                            queue.Enqueue(new int[] { i, j });
                            visited.Add(i + "," + j);
                        }
                    }
                }
                step++;
            }

            return -1;

        }

        public bool dfs(int[][] A, int row, int col, HashSet<string> visited)
        {
            string key = row + "," + col;
            if (visited.Contains(key))
            {
                return false;
            }

            if (row < 0 || col < 0 || row >= A.Length || col > A[0].Length || A[row][col] == 0)
            {
                return false;
            }

            visited.Add(key);
            queue.Enqueue(new[] { row, col });
            dfs(A, row, col + 1, visited);
            dfs(A, row, col - 1, visited);
            dfs(A, row + 1, col, visited);
            dfs(A, row - 1, col, visited);

            return true;

        }
    }
}
