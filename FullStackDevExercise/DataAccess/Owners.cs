using System;
using System.Collections.Generic;

namespace FullStackDevExercise.DataAccess
{
    public partial class Owners
    {
        public Owners()
        {
            Appointments = new HashSet<Appointments>();
            Pets = new HashSet<Pets>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<Pets> Pets { get; set; }
    }
}
