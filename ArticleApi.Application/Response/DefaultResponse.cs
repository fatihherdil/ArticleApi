using System.Net;
using ArticleApi.Application.Interfaces;

namespace ArticleApi.Application.Response
{
    public struct DefaultResponse : IResponse
    {
        public string Status { get; set; }
        public int ResponseCode { get; set; }
        public object Response { get; set; }

        public DefaultResponse(string status, int responseCode, object response)
        {
            Status = status;
            ResponseCode = responseCode;
            Response = response;
        }
        public DefaultResponse(int responseCode, object response)
        {
            Status = "ok";
            ResponseCode = responseCode;
            Response = response;
        }

        public DefaultResponse(string status, object response)
        {
            Status = status;
            ResponseCode = 200;
            Response = response;
        }

        public DefaultResponse(object response)
        {
            Status = "ok";
            ResponseCode = 200;
            Response = response;
        }


        public DefaultResponse(HttpStatusCode statusCode, object response)
        {
            Status = statusCode.ToString();
            ResponseCode = (int) statusCode;
            Response = response;
        }
    }
}
