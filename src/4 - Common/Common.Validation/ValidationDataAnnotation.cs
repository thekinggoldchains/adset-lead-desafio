using System.ComponentModel.DataAnnotations;

namespace Common.Validation
{
    public static class ValidationDataAnnotation
    {
        public static bool Validate(object model, out List<string> errors)
        {
            errors = [];

            var results = ValidateModel(model);
            if (results.Count > 0)
            {
                foreach (var item in results)
                    errors.Add(item.ErrorMessage);

                return false;
            }
            else
                return true;
        }

        public static bool Validate(object model, ValidationContract validation)
        {
            var results = ValidateModel(model);
            if (results.Count > 0)
            {
                foreach (var item in results.Select(_ => _.ErrorMessage))
                    validation.Add(item);

                return false;
            }
            else
                return true;
        }

        private static List<ValidationResult> ValidateModel(object model)
        {
            var ctx = new ValidationContext(model);
            var results = new List<ValidationResult>();

            Validator.TryValidateObject(model, ctx, results, true);
            return results;
        }
    }
}
