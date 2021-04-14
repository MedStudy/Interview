using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FSDExercise.Common.Models
{
    public class HttpStatusCodeException : Exception
    {
      public HttpStatusCode StatusCode { get; set; }

      public HttpStatusCodeException(HttpStatusCode statusCode)
      {
        this.StatusCode = statusCode;
      }

      public HttpStatusCodeException(HttpStatusCode statusCode, string message) : base(message)
      {
        this.StatusCode = statusCode;
      }
    }
}
