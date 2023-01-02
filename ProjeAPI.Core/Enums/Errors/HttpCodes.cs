using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Core.Enums.Errors
{
    public enum HttpCodes
    {
        Succeded = 200, //Başarılı
        NotFound = 404, //Bulunamadı
        ServerError = 500, //Server Sorunu (Bağlanamama/Erişim Hatası)
    }
}
