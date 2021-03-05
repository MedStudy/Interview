using System;
using System.Collections.Generic;

namespace FullStackDevExercise.DataAccess
{
    public partial class Appointments
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public long PetId { get; set; }
        public long VetId { get; set; }
        public string ScheduledDate { get; set; }

        public virtual Owners Owner { get; set; }
        public virtual Pets Pet { get; set; }
        public virtual Vets Vet { get; set; }
    }
}
