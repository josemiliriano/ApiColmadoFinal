using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Eceptions
{
    public class BusinessException : Exception
    {
        public int StatusCode { get; }

        protected BusinessException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
