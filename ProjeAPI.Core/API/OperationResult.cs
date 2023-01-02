using ProjeAPI.Core.Enums.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Core.API
{
    public class OperationResult<T>
    {
        public HttpCodes HttpCode { get; set; }
        public bool IsSucceded { get; set; }
        public T Data { get; set; }
        public ISystemError Error { get; set; }
        public string ErrorMessage { get; set; } = "";

        public static OperationResult<T> Success(T data)
        {
            return new OperationResult<T>()
            {
                IsSucceded = true,
                HttpCode = HttpCodes.Succeded,
                Data = data,
                Error = null,
                ErrorMessage = string.Empty
            };
        }
        public static OperationResult<T> Fail(HttpCodes code, ISystemError error, string errorMessage = "")
        {
            return new OperationResult<T>()
            {
                IsSucceded = false,
                HttpCode = code,
                Data = default(T),
                Error = error,
                ErrorMessage = errorMessage
            };
        }
    }
}
