using ArticleApi.Application.Interfaces;

namespace ArticleApi.Application.Response
{
    public struct ErrorResponse : IResponse
    {
        public string Status { get; set; }
        public int ResponseCode { get; set; }
        public object Response { get; set; }

        public ErrorResponse(int responseCode, object response)
        {
            Status = "error";
            ResponseCode = responseCode;
            Response = response;
        }
    }
}
