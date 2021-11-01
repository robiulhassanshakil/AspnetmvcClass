using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceManagementSystem.Attendance.Entities;
using AttendanceManagementSystem.Data;

namespace AttendanceManagementSystem.Attendance.Entities
{
    public class Attendance:IEntity<int>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
