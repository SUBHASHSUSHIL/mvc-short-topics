using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Coding_CRUD.Models
{
    public class EmployeeClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public long Salary { get; set; }
        public long MobileNo { get; set; }
        public string Address { get; set; }

    }
}