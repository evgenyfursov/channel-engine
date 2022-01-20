namespace ChannelEngineApi.BusinessLogic.Models
{
    public class Response<T>
    {
        public int StatusCode { get; set; }

        public T Item { get; set; }
        public string Error { get; set; }

        public void SetStatusCodeAndError(int statusCode, string error = null)
        {
            StatusCode = statusCode;
            Error = error;
        }
    }
}