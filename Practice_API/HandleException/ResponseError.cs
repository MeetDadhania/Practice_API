using Amazon.Runtime;
using System.Net;

namespace Practice_API.HandleException
{
    public class ResponseError
    {
        public ErrorType Type { get; set; }

        //
        // Summary:
        //     Name of the exception class to return
        public string Code { get; set; }

        //
        // Summary:
        //     Error message
        public string Message { get; set; }

        //
        // Summary:
        //     RequestId of the error. Only applies to XML-based services.
        public string RequestId { get; set; }

        public Exception InnerException { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
