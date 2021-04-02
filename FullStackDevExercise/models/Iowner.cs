using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public interface Iowner
  {
    public int id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }

    public IEnumerable<Iowner> getAllowners();
    public Iowner getowners(string id);
    public Iowner updateowner(Iowner data);
    public string deleteowner(string id);

    public Iowner createowner(Iowner data);

  }
}
