using System;
using IndexCalculator.Repository.Contracts;
using IndexCalculator.Service.Contracts;
using IndexCalculator.Service.Validators.Contract;

namespace IndexCalculator.Service.Implementation
{
    public class IndexCalculatorService : IIndexCalculatorService
    {
        private readonly IIndexCalculatorRepository repository;
        private readonly IIndexCalculatorValidator validator;
        public IndexCalculatorService(IIndexCalculatorRepository repository, IIndexCalculatorValidator validator)
        {
            this.repository = repository;
            this.validator = validator;
        }
        public int GetIndex(string subscriptionNumber)
        {
            var subscription = validator.Validate(subscriptionNumber);
            if(subscription.HasErrors())
            {
                string errorMessage = " ";
                foreach(var error in subscription.GetErrors())
                {
                    errorMessage = string.Concat(error, " ");
                }
                throw new Exception(errorMessage);
            }
            return repository.GetIndex(subscription.Index);
        }
    }
}
