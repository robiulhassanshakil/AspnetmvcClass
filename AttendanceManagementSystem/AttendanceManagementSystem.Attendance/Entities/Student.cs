using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceManagementSystem.Data;

namespace AttendanceManagementSystem.Attendance.Entities
{
    public class Student:IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentRollNumber { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}
