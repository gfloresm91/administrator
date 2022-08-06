using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace Administrator.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; }
        public List<string> ErrorsIdentity { get; }

        public ValidationException(): base("Se presentaron uno o más errores de validación")
        {
            Errors = new Dictionary<string, string[]>();
            ErrorsIdentity = new List<string>();

        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy( e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public ValidationException(IEnumerable<string> failures) : this()
        {
            foreach (var failure in failures.ToArray())
            {
                ErrorsIdentity.Add(failure);
            }
        }
    }
}
