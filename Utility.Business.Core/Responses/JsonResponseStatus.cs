namespace Utility.Business.Core.Responses
{
    public class JsonResponseStatus
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public static JsonResponseStatus CreateError(string message, string code)
        {
            return new JsonResponseStatus { Code = code, Message = message };
        }

        public static JsonResponseStatus CreateSuccess(string message = null)
        {
            return new JsonResponseStatus { Code = JsonResponseStatusCode.Success, Message = message };
        }

        public static JsonResponseStatus CreateError(string message = null)
        {
            return new JsonResponseStatus { Code = JsonResponseStatusCode.Error, Message = message };
        }
    }
}
