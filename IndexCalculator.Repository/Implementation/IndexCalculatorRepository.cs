using IndexCalculator.Repository.Contracts;
using System;
using System.Collections.Generic;

namespace IndexCalculator.Repository.Implementation
{
    public class IndexCalculatorRepository : IIndexCalculatorRepository
    {
        private readonly IDictionary<int, int> dict;
        public IndexCalculatorRepository()
        {
            dict = new Dictionary<int, int>();
            PopulateDictionary();
        }
        //TODO: maybe change this method return to ValidationResult
        public int GetIndex(int subscriptionNumber)
        {
            int x;
            if(!dict.TryGetValue(subscriptionNumber, out x))
            {
                throw new Exception($"Value {subscriptionNumber} not found");
            }
            return x; 
        }

        private void PopulateDictionary()
        {
            dict.Add(13579, 1);
            dict.Add(13597, 2);
            dict.Add(97513, 3);
            dict.Add(97531, 3);
        }
    }
}
