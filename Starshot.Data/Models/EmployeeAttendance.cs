using System;
using Starshot.Data.Models.Base;

namespace Starshot.Data.Models
{
    public class EmployeeAttendance : BaseEntity
    {
        public EmployeeAttendance()
        {
        }

        public int EmployeeId { get; set; }
        public DateTime? ClockIn { get; set; }
        public DateTime? ClockOut { get; set; }

        public Employee Employee { get; set; }
    }
}
