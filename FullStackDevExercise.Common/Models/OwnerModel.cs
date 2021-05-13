using System;
using System.Collections.Generic;
using System.Text;

namespace FullStackDevExercise.Common.Models
{
    public class OwnerModel : ModelBase
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<PetModel> Pets { get; set; }
    }
}
