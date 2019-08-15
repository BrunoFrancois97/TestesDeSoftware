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
                const int mininumValue = 13579;
                const int maximumValue = 97531;

                var result = int.Parse(subscriptionNumber);
                //TODO: Add validation to see if the number has even digits
                if(result < mininumValue || result > maximumValue)
                {
                    validationResult.AddError("Please enter a valid subscription number");
                }

                if(HasEvenDigit(result))
                {
                    validationResult.AddError("Number has even digits");
                }

                validationResult.Index = result;

                return validationResult;
            }

            catch(Exception)
            {
                throw new Exception($"Could not parse '{subscriptionNumber}' to int, please enter an integer number");
            }
        }

        private bool HasEvenDigit(int subscriptionNumber)
        {
            const int divisor = 10;

            while (subscriptionNumber > 0)
            {
                if ((subscriptionNumber % divisor) % 2 == 0)
                {
                    return true;
                }
                subscriptionNumber /= divisor;
            }
            return false;
        }
    }
}
