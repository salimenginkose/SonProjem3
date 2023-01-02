using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Core.API
{
    public class ControllerProcess : ControllerBase
    {
        public IActionResult ProccessResult<T>(OperationResult<T> res)
        {
            if (res is null)
                return this.StatusCode(500, new { Message = "İşlem gerçekleştirilirken bir sorun yaşandı." });

            if (res.IsSucceded)
                return this.Ok(res.Data);
            else
                return this.StatusCode((int)res.HttpCode, new { ErrorMessage = res.Error.ErrorMessage, ErrorNumber = res.Error.ErrorNumber });
        }

    }
}
