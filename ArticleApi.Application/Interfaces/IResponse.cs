namespace ArticleApi.Application.Interfaces
{
    public interface IResponse
    {
        string Status { get; set; }

        int ResponseCode { get; set; }

        object Response { get; set; }
    }
}
