namespace HangFireDemo.Helper
{
    public interface IResponseHelper
    {
        Response GetResponseTemplate();    
    }

    public class ResponseHelper : IResponseHelper
    {
        public Response GetResponseTemplate()
        {
            return new Response();
        }
    }

    public class Response
    {
        public string Message { get; set; } = "";
        public int StatusCode { get; set; } = 200;
    }
}
