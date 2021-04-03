using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public interface Iowner
  {
    public IEnumerable<owners> getAllowners();
    public owners getowners(string id);
    public owners updateowner(owners data);
    public string deleteowner(string id);

    public owners createowner(owners data);

  }
}
