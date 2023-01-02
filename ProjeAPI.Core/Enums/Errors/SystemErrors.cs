using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Core.Enums.Errors
{
    public class SystemErrors : ISystemError
    {
        public string ErrorMessage { get; set; } = "";
        public SystemErrorNumbers ErrorNumber { get; set; }

        public static SystemErrors INVALID_INPUT
        {
            get
            {
                return new SystemErrors()
                {
                    ErrorMessage = nameof(INVALID_INPUT),
                    ErrorNumber = SystemErrorNumbers.INVALID_INPUT,
                };
            }
        }
        public static SystemErrors NOT_FOUND
        {
            get
            {
                return new SystemErrors()
                {
                    ErrorMessage = nameof(NOT_FOUND),
                    ErrorNumber = SystemErrorNumbers.NOT_FOUND,
                };
            }
        }
        public static SystemErrors COMPANY_NOT_FOUND
        {
            get
            {
                return new SystemErrors()
                {
                    ErrorMessage = nameof(COMPANY_NOT_FOUND),
                    ErrorNumber = SystemErrorNumbers.COMPANY_NOT_FOUND,
                };
            }
        }
        public static SystemErrors PRODUCT_NOT_FOUND
        {
            get
            {
                return new SystemErrors()
                {
                    ErrorMessage = nameof(PRODUCT_NOT_FOUND),
                    ErrorNumber = SystemErrorNumbers.PRODUCT_NOT_FOUND,
                };
            }
        }
        public static SystemErrors ORDER_NOT_FOUND
        {
            get
            {
                return new SystemErrors()
                {
                    ErrorMessage = nameof(ORDER_NOT_FOUND),
                    ErrorNumber = SystemErrorNumbers.ORDER_NOT_FOUND,
                };
            }
        }
        public static SystemErrors INTERNAL_SERVER_ERROR
        {
            get
            {
                return new SystemErrors()
                {
                    ErrorMessage = nameof(INTERNAL_SERVER_ERROR),
                    ErrorNumber = SystemErrorNumbers.INTERNAL_SERVER_ERROR,
                };
            }
        }
        public static SystemErrors YOU_CAN_NOT_MAKE_ORDER_BECAUSE_COMPANY_STATUS_NOT_APPROVED
        {
            get
            {
                return new SystemErrors()
                {
                    ErrorMessage = nameof(YOU_CAN_NOT_MAKE_ORDER_BECAUSE_COMPANY_STATUS_NOT_APPROVED),
                    ErrorNumber = SystemErrorNumbers.YOU_CAN_NOT_MAKE_ORDER_BECAUSE_COMPANY_STATUS_NOT_APPROVED,
                };
            }
        }
        public static SystemErrors YOU_CAN_NOT_MAKE_ORDER_BECAUSE_COMPANY_IS_CLOSED_NOW
        {
            get
            {
                return new SystemErrors()
                {
                    ErrorMessage = nameof(YOU_CAN_NOT_MAKE_ORDER_BECAUSE_COMPANY_IS_CLOSED_NOW),
                    ErrorNumber = SystemErrorNumbers.YOU_CAN_NOT_MAKE_ORDER_BECAUSE_COMPANY_IS_CLOSED_NOW,
                };
            }
        }
    }
    public enum SystemErrorNumbers
    {
        INVALID_INPUT = 1,
        INTERNAL_SERVER_ERROR = 2,
        NOT_FOUND = 3,
        COMPANY_NOT_FOUND = 4,
        PRODUCT_NOT_FOUND = 5,
        ORDER_NOT_FOUND = 6,
        YOU_CAN_NOT_MAKE_ORDER_BECAUSE_COMPANY_STATUS_NOT_APPROVED = 7,
        YOU_CAN_NOT_MAKE_ORDER_BECAUSE_COMPANY_IS_CLOSED_NOW = 8,
    }
}
