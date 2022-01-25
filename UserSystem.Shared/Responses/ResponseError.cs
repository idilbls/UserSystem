using System;

namespace UserSystem.Shared.Responses
{
    public class ResponseError : Exception
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
