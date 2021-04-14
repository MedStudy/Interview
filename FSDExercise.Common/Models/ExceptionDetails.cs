using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace FSDExercise.Common.Models
{
  [ExcludeFromCodeCoverage]
  public class ExceptionDetails
  {
      public int StatusCode { get; set; }
      public string Message { get; set; }      

      [ExcludeFromCodeCoverage]
      public override string ToString()
      {
        return JsonConvert.SerializeObject(this);
      }
  }
}
