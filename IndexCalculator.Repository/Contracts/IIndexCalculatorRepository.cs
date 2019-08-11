using System;
using System.Collections.Generic;
using System.Text;

namespace IndexCalculator.Repository.Contracts
{
    public interface IIndexCalculatorRepository
    {
        int GetIndex(int subscriptionNumber);
    }
}
