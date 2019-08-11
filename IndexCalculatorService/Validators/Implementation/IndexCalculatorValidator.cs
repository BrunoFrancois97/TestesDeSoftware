using IndexCalculator.Service.Validators.Contract;
using System;

namespace IndexCalculator.Service.Validators.Implementation
{
    public class IndexCalculatorValidator : IIndexCalculatorValidator
    {
        private readonly ValidationResult validationResult;
        public IndexCalculatorValidator()
        {
            validationResult = new ValidationResult();
        }
        public ValidationResult Validate(string subscriptionNumber)
        {
            try
            {
                var result = int.Parse(subscriptionNumber);
                //TODO: Add validation to see if the number has even digits
                if(result < 13579 || result > 97531)
                {
                    validationResult.AddError("Please enter a valid subscription number");
                }

                validationResult.Index = result;

                return validationResult;
            }

            catch(Exception)
            {
                throw new Exception($"Could not parse '{subscriptionNumber}' to int, please enter an integer number");
            }
        }
    }
}
