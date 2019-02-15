using System;
using System.Collections.Generic;
using Utility.Business.Core.Exceptions;

namespace Utility.Business.Core.Responses
{
    public class JsonResponse
    {
        public JsonResponseStatus Status { get; set; }

        public object Data { get; set; }

        public List<JsonResponseStatus> Errors { get; set; }

        public JsonResponse()
        {
            Status = new JsonResponseStatus();
            Errors = new List<JsonResponseStatus>();
        }

        public static JsonResponse CreateSuccess(string message = null)
        {
            return new JsonResponse
            {
                Status = JsonResponseStatus.CreateSuccess(message),
                Errors = new List<JsonResponseStatus>()
            };
        }

        public static JsonResponse CreateSuccess(object data, string message = null)
        {
            return new JsonResponse
            {
                Status = JsonResponseStatus.CreateSuccess(message),
                Data = data,
                Errors = new List<JsonResponseStatus>()
            };
        }

        public static JsonResponse CreateError(string message = null)
        {
            return new JsonResponse
            {
                Status = JsonResponseStatus.CreateError(message),
                Errors = new List<JsonResponseStatus>()
            };
        }

        public static JsonResponse CreateError(Exception exception)
        {
            var mes = ExceptionDictionary.Instance.GetUserFriendlyMessage(exception);

            if (exception is ValidationException)
            {
                return new JsonResponse
                {
                    Status = JsonResponseStatus.CreateError(mes),
                    Errors = (exception as ValidationException).Filds
                };
            }

            return new JsonResponse
            {
                Status = JsonResponseStatus.CreateError(mes),
                Errors = new List<JsonResponseStatus>()
            };
        }

        public static JsonResponse CreateError(JsonResponseStatus status)
        {
            return new JsonResponse
            {
                Status = status,
                Errors = new List<JsonResponseStatus>()
            };
        }

        public static JsonResponse CreateError(object data, string message = null)
        {
            return new JsonResponse
            {
                Status = JsonResponseStatus.CreateError(message),
                Data = data,
                Errors = new List<JsonResponseStatus>()
            };
        }

        public static JsonResponse CreateError(object data, JsonResponseStatus status)
        {
            return new JsonResponse
            {
                Status = status,
                Data = data,
                Errors = new List<JsonResponseStatus>()
            };
        }
    }

    public class JsonResponse<T>
    {
        public JsonResponseStatus Status { get; set; }

        public T Data { get; set; }

        public List<JsonResponseStatus> Errors { get; set; }

        public JsonResponse()
        {
            Status = new JsonResponseStatus
            {
                Code = JsonResponseStatusCode.Success
            };
            Errors = new List<JsonResponseStatus>();
        }
    }
}
