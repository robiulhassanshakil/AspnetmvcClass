using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceManagementSystem.Attendance.Repositories;
using AttendanceManagementSystem.Data;

namespace AttendanceManagementSystem.Attendance.UniteOfWork
{
    public interface IAttendanceUniteOfWork:IUnitOfWork
    {
         IStudentRepository Students { get; }
         IAttendanceRepository Attendances { get; }
    }
}
