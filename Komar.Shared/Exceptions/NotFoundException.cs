using System.Net;

namespace Komar.Shared.Exceptions
{
    public class NotFoundException : HttpException
    {
        public NotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }

        public NotFoundException(string entityName, int id) : this($"{entityName} with Id \"{id}\" not found.")
        {
        }
    }
}
