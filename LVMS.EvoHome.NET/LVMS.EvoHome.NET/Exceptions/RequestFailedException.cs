using System;
using System.Net;

namespace LVMS.EvoHome.Exceptions
{
    public class RequestFailedException : EvoHomeException
    {
        public HttpStatusCode StatusCode;

        public RequestFailedException(HttpStatusCode statusCode) : base()
        {
            StatusCode = statusCode;
        }

        public RequestFailedException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
