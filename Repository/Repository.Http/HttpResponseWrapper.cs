using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Http
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T response, bool success, string errorMessage, HttpStatusCode statusCode)
        {
            Response = response;
            Success = success;
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }

        public T Response { get; }
        public bool Success { get; }
        public string ErrorMessage { get; }
        public HttpStatusCode StatusCode { get; }
    }
}
