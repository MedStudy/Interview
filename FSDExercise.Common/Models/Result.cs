using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDExercise.Common.Models
{
    public class Result
    {
        public bool isSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public Result(bool status)
        {
          isSuccess = status;
        }

        public Result(bool status , string message)
        {
          isSuccess = status;
          ErrorMessage = message;
        }
    }
}
