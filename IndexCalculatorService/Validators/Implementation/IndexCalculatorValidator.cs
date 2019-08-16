using IndexCalculator.Service.Validators.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

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

                if(HasRepeatedDigit(result))
                {
                    validationResult.AddError("Number has repeated digits");
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

        private bool HasRepeatedDigit(int subscriptionNumber)
        {
            var listOfInts = new List<int>();

            while (subscriptionNumber > 0)
            {
                listOfInts.Add(subscriptionNumber % 10);
                subscriptionNumber /= 10;
            }

            return listOfInts
              .GroupBy(i => i)
              .Any(g => g.Count() > 1);
        }
    }
}
