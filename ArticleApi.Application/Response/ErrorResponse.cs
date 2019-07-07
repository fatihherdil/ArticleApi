using System.Net;
using ArticleApi.Application.Interfaces;

namespace ArticleApi.Application.Response
{
    public struct ErrorResponse : IResponse
    {
        public string Status { get; set; }
        public int ResponseCode { get; set; }
        public object Response { get; set; }

        public ErrorResponse(HttpStatusCode statusCode, object response)
        {
            Status = statusCode.ToString();
            ResponseCode = (int)statusCode;
            Response = response;
        }
    }
}
