using System;
using System.Collections.Generic;

namespace FullStackDevExercise.DataAccess
{
    public partial class Pets
    {
        public Pets()
        {
            Appointments = new HashSet<Appointments>();
        }

        public long Id { get; set; }
        public long OwnerId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public long Age { get; set; }

        public virtual Owners Owner { get; set; }
        public virtual ICollection<Appointments> Appointments { get; set; }
    }
}
