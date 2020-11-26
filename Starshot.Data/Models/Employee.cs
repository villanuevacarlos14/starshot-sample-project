using System;
using System.Collections;
using System.Collections.Generic;
using Starshot.Data.Models.Base;

namespace Starshot.Data.Models
{
    public class Employee : BaseEntity
    {
        public Employee()
        {
        }

        public string Name { get; set; }
        public bool Active { get; set; }

        public IEnumerable<EmployeeAttendance> EmployeAttendance { get; set; }
    }
}
