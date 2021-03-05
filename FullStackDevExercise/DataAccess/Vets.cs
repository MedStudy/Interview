using System;
using System.Collections.Generic;

namespace FullStackDevExercise.DataAccess
{
    public partial class Vets
    {
        public Vets()
        {
            Appointments = new HashSet<Appointments>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
    }
}
