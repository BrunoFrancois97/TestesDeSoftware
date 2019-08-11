using System.Collections.Generic;
using System.Linq;

namespace IndexCalculator.Service.Validators
{
    public class ValidationResult
    {
        public IList<string> errors;
        public int Index { get; set; }
        public ValidationResult()
        {
            errors = new List<string>();
        }

        public void AddError(string error)
        {
            errors.Add(error);
        }

        public IList<string> GetErrors()
        {
            return errors;
        }

        public bool HasErrors()
        {
            return errors.Any();
        }
    }
}
