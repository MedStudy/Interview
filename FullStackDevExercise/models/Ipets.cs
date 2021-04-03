using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.models
{
  public interface Ipets
  {

    public IEnumerable<PetsList> getAllpets();
    public PetsList getpets(string id);
    public Pets updatepet(Pets data);
    public string deletepet(string id);

    public Pets createpet(Pets data);
  }
}
