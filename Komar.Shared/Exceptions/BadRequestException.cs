using System.Net;

namespace Komar.Shared.Exceptions
{
    public class BadRequestException : HttpException
    {
        public BadRequestException(string message) : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
