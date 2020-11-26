using System;
using System.Collections.Generic;

namespace Starshot.DTO
{
    public class AttendanceDTO
    {
        public DateTime date { get; set; }
        public IEnumerable<EmployeeDTO> Employees { get; set; }
        public IEnumerable<EmployeeAttendanceDTO> TimedInEmployees { get; set; }
        public IEnumerable<EmployeeAttendanceDTO> TimeOutEmployees { get; set; }

    }
}
