using System;
using System.Collections.Generic;
using System.Text;

namespace FullStackDevExercise.Common.Models
{
    public class AppointmentModel : ModelBase
    {
        public long PetId { get; set; }
        public DateTime SlotFrom { get; set; }
        public DateTime SlotTo { get; set; }
        public string Summary { get; set; }
    }
}
