using System;
using System.Collections.Generic;
using System.Text;

namespace IndexCalculator.Service.Validators.Contract
{
    public interface IIndexCalculatorValidator
    {
        ValidationResult Validate(string subscriptionNumber);
    }
}
