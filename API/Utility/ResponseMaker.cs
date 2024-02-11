

namespace API.Utility
{
    public class ResponseMaker
    {
        public static AppResponse<T> MakeResponse<T>(T data) where T : class
        {
            return new AppResponse<T>()
            {
                Data = data,
                Meta = new Meta() { IsSucceeded = true, Message = "Operation Succeeded", }
            };
        }

        public static AppResponse<T> MakeResponse<T>(T data, Meta meta) where T : class
        {
            return new AppResponse<T>()
            {
                Data = data,
                Meta = meta
            };
        }

        public static AppResponse<T> MakeCustomResponse<T>(T data) where T : class
        {
            return new AppResponse<T>()
            {
                Data = data,
                Meta = new Meta() { IsSucceeded = true, Message = "Operation Succeeded", }
            };
        }

        public static AppResponse<T> MakeCustomResponse<T>(T data, Meta meta) where T : class
        {
            return new AppResponse<T>()
            {
                Data = data,
                Meta = meta
            };
        }
    }
}
