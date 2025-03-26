using System.Globalization;

namespace Application.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException() : base()
        {

        }

        public ApiException(string message) : base(message)
        {

        }

        public ApiException(string message, params object[] arg) : base(String.Format(CultureInfo.CurrentCulture, message, arg))
        {

        }
    }
}
