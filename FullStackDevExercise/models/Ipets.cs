using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public interface Ipets
  {
    public int id { get; set; }
    public int owner_id { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public int age { get; set; }

    public IEnumerable<Ipets> getAllpets();
    public Ipets getpets(string id);
    public Ipets updatepet(Ipets data);
    public string deletepet(string id);

    public Ipets createpet(Ipets data);
  }
}
