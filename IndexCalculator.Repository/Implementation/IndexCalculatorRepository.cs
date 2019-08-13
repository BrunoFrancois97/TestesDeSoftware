using IndexCalculator.Repository.Contracts;
using System;
using System.Collections.Generic;

namespace IndexCalculator.Repository.Implementation
{
    public class IndexCalculatorRepository : IIndexCalculatorRepository
    {
        private readonly IDictionary<int, int> dict;
        private List<int> allSubscriptions;

        public IndexCalculatorRepository()
        {
            dict = new Dictionary<int, int>();
            allSubscriptions = new List<int>();
            PopulateDictionary();
        }

        public int GetIndex(int subscriptionNumber)
        {
            if (!dict.TryGetValue(subscriptionNumber, out int x))
            {
                throw new Exception($"Value {subscriptionNumber} not found");
            }
            return x; 
        }

        private void PopulateDictionary()
        {
            var str = "13579";
            var chr = str.ToCharArray();
            GetPer(chr);
            allSubscriptions.Sort();
            for(var i = 0; i < allSubscriptions.Count; i++)
            {
                dict.Add(allSubscriptions[i], i + 1);
            }
        }

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }

        private void GetPer(char[] list)
        {
            int x = list.Length - 1;
            GetPer(list, 0, x);
        }

        private void GetPer(char[] list, int k, int m)
        {
            if (k == m)
            {
                var subscription = new string(list);
                allSubscriptions.Add(int.Parse(subscription));
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
        }
    }
}
