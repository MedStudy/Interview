using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDExercise.Common.Models
{
    public class OwnerRequest
    {
        [Required(ErrorMessage = "First Name is required")]
        [MinLength(3,ErrorMessage = "First Name should be of minimum 3 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(3, ErrorMessage = "Last Name should be of minimum 3 characters")]
        public string LastName { get; set; }

        public bool IsValid()
        {
          if (string.IsNullOrEmpty(FirstName) ||
              string.IsNullOrEmpty(LastName))
            return false;

          return true;

        }
    }
}
