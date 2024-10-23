using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException() : base("İstifadəçi adı və ya şifrə yanlışdır.")
        {
        }

        public BaseException(string message) : base(message)
        {
        }

        public BaseException(string message, Exception? innerException) : base(message, innerException)
        {

        }

        public HttpStatusCode StatusCode { get; set; }
        public BaseException(string msg, HttpStatusCode statuscode = HttpStatusCode.InternalServerError)
        {
            StatusCode = statuscode;
        }
    }
}
