using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDevExercise.Contracts
{
  public interface IBootstrapper
  {
    public Task BootstrapWithOptions(string[] args);
  }
}
