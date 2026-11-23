using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Application.Common.Exceptions
{
    public  class AppException:Exception
    {
        public string Code { get; }
        public AppException(string message,string code="App_ERROR"):base(message)
        {
            Code = code;
        }
        public AppException(string message,Exception innerException,string code="APP_ERROR"):base(message,innerException)
        {
            Code = code;
        }
    }
}
