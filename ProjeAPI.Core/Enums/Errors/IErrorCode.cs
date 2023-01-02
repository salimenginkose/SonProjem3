using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Core.Enums.Errors
{
    //Sistemde Sorun Çıktığında Bildiri Atmaya Yarayan Fonksiyon
    public interface ISystemError
    {
        public string ErrorMessage { get; set; }
        public SystemErrorNumbers ErrorNumber { get; set; }
    }
}
