using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
   public static class ItineraryFlight
    {
        static List<string> routes = new List<string>();
        static int totalFlights = 0;

        static Dictionary<string, bool[]> visitMap = new Dictionary<string, bool[]>();
        public static IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            totalFlights = tickets.Count;
            // adjList
            Dictionary<string, List<string>> adjList = new Dictionary<string, List<string>>();
            for (var  i = 0; i < tickets.Count; i++)
            {
                var src = tickets[i][0];
                var dest = tickets[i][1];

                var list = adjList.GetValueOrDefault(src, new List<string>());

                list.Add(dest);
                list.Sort();

                adjList[src] = list;
            }

            foreach(var flight in adjList)
            {
                visitMap.Add(flight.Key, new bool[adjList[flight.Key].Count]);
            }

            // call backtracking
            routes.Add("JFK");
            BackTracking(adjList, "JFK");

            return routes;
        }

        public static bool BackTracking(Dictionary<string, List<string>> tickets,string destination)
        {
            if(routes.Count == totalFlights + 1)
            {
                return true;
            }

            if(!tickets.ContainsKey(destination))
            {
                return false;
            }

           var visited = visitMap[destination];
            int i = 0;
            foreach(var flight in tickets[destination])
            {
                if(!visited[i])
                {
                    visited[i] = true;
                    routes.Add(flight);
                    var result = BackTracking(tickets, flight);
                    if (result)
                    {
                        return true;
                    }
                    routes.RemoveAt(routes.Count - 1);
                    visited[i] = false;
                
                  
                }
                i++;


            }

            return false;
        }
    }
}
