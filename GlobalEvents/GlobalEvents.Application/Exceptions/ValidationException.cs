using FluentValidation.Results;
using GlobalEvents.Application.Responses;

namespace GlobalEvents.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; }


        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();
            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }

        public ValidationException(ValidationResult validationResult, BaseResponse response)
        {
            ValidationErrors = new List<string>();
            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }

    }
}
