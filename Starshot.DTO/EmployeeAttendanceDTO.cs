using System;
namespace Starshot.DTO
{
    public class EmployeeAttendanceDTO
    {
        public EmployeeAttendanceDTO()
        {
        }

        public DateTime ClockIn { get; set; }
        public DateTime ClockOut { get; set; }

        public EmployeeDTO Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
