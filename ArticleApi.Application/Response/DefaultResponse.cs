using ArticleApi.Application.Interfaces;

namespace ArticleApi.Application.Response
{
    public struct DefaultResponse : IResponse
    {
        public string Status { get; set; }
        public int ResponseCode { get; set; }
        public object Response { get; set; }

        public DefaultResponse(object response)
        {
            Status = "ok";
            ResponseCode = 200;
            Response = response;
        }
    }
}
