namespace AsuDemo.Common.Response
{
    public class AppResponse
    {

        public AppResponse()
        {

        }

        public bool IsSuccess => Errors.Count == 0;
        public List<string> Errors { get; set; } = new();

        public static AppResponse Error(params string[] Errors)
        {
            return new AppResponse() { Errors = Errors.ToList() };
        }

        public static AppResponse Success()
        {
            return new AppResponse();
        }
    }

    public class AppResponse<T> : AppResponse
    {
        public AppResponse()
        {

        }

        public AppResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public static AppResponse<T> Success(T Data)
        {
            return new AppResponse<T>(Data);
        }
    }

}
