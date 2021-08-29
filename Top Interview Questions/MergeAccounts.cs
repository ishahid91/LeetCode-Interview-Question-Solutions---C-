using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codetest
{
    public static class MergeAccounts
    {
        public static IList<IList<string>> accountsMerge(List<List<String>> accounts)
        {
            Dictionary<string,List<int>> EmailAdjList = new Dictionary<string, List<int>>();

            for(var i = 0; i < accounts.Count; i++)
            {
                var emails = accounts[i];

                for(var j = 1; j < emails.Count; j++)
                {
                    var email = emails[j];
                    var list = EmailAdjList.GetValueOrDefault(email, new List<int>());
                    list.Add(i);
                    EmailAdjList[email] = list;
                }
            }

            var result = new List<IList<string>>();

            //visited
            HashSet<string> visited = new HashSet<string>();
            foreach(var email in EmailAdjList)
            {
                var list = dfs(accounts, EmailAdjList, email.Key, visited);
                if(list != null)
                {
                    list.OrderBy(s => s);
                    list.Insert(0,accounts[EmailAdjList[email.Key][0]][0]);

                    result.Add(list);
                }
            }
            return result;
        }

        public static List<string> dfs(List<List<String>> accounts, Dictionary<string, List<int>> EmailAdjList, string email, HashSet<string> visited)
        {
            if(visited.Contains(email))
            {
                return null;
            }

            List<string> returnList = new List<string>();
            returnList.Add(email);
            visited.Add(email);
            foreach(var idx in EmailAdjList[email]) // All accounts for same email
            {
                for(int i = 1; i < accounts[idx].Count; i++) // loop account
                {
                    var siblingEmail = accounts[idx][i];
                    var emails = dfs(accounts, EmailAdjList, siblingEmail, visited);
                    if(emails != null)
                    {
                        returnList.AddRange(emails);
                    }
                }
            }

            return returnList;
        }
    }
}
