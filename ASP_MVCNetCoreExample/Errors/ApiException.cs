using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MVCNetCoreExample.Errors
{
    public class ApiException
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public ApiException(int statusCode, string message = null, string details = null)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }
    }
}
