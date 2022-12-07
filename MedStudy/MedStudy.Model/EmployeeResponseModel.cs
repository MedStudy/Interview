using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedStudy.Model
{
    public class EmployeeResponseModel
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Year { get; set; }
        public string? State { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Zipcode { get; set; }
        public string? Country { get; set; }

    }
}
