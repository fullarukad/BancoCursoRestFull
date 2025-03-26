using FluentValidation.Results;

namespace Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("Se han producido uno o más errores de validación")
        {
            Erros = new List<string>();
        }

        public List<string> Erros { get; }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Erros.Add(failure.ErrorMessage);
            }

        }
    }
}
