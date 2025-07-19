using Flunt.Notifications;
using System.Net;

namespace Common.Api
{
    public class HttpResult<T>
    {
        public HttpResult(T result)
        { 
        
        }

        public HttpResult(T result, IEnumerable<Notification> errors)
        {
            StatusCode = HttpStatusCode.OK;

            if (!EqualityComparer<T>.Default.Equals(result, default))
                Result = result;

            if (errors is not null && errors.Any())
            {
                StatusCode = HttpStatusCode.InternalServerError;
                Errors = errors.Select(_ => new Error(_.Key, _.Message));
            }
        }

        public HttpResult(T result, string[] errors)
        {
            StatusCode = HttpStatusCode.OK;

            if (!EqualityComparer<T>.Default.Equals(result, default))
                Result = result;

            if (errors is not null && errors.Any())
            {
                StatusCode = HttpStatusCode.InternalServerError;
                Errors = errors.Select(msg => new Error(msg));
            }
        }

        public HttpStatusCode StatusCode { get; set; }
        public T Result { get; set; }
        public IEnumerable<Error> Errors { get; set; }

        public class Error
        {
            public Error(string code, string message)
            {
                this.Code = code;
                this.Message = message;
            }

            public Error(string message)
            {
                this.Code = "ERROR";
                this.Message = message;
            }

            public string Code { get; protected set; }
            public string Message { get; protected set; }
        }
    }
}
