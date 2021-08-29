using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    public static class FindOrderCourse
    {
        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            int[] indegres = new int[numCourses];
            int[] result = new int[numCourses];
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            Queue<int> queue = new Queue<int>();

            for(int i = 0; i < prerequisites.Length; i++)
            {
                int src = prerequisites[i][1];
                int dest = prerequisites[i][0];

                var list = adjList.GetValueOrDefault(src,new List<int>());

                list.Add(dest);

                adjList[src] = list;


                /// add indegres 
                /// 

                indegres[dest] += 1;
            }


            for(int i = 0; i < numCourses; i++)
            {
                if(indegres[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            int incr = 0;

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();

                result[incr++] = current;

                if(adjList.ContainsKey(current))
                {
                    foreach(var course in adjList[current])
                    {
                        indegres[course] -= 1;

                        if (indegres[course] == 0)
                        {
                            queue.Enqueue(course);
                        }
                    }
                }
            }

            if (incr == numCourses)
            {

                return result;
            }
            return new int[0];
        }
    }
}
