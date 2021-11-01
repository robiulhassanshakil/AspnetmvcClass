using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceManagementSystem.Data;

namespace AttendanceManagementSystem.Attendance.Repositories
{
    public interface IAttendanceRepository:IRepository<Entities.Attendance,int>
    {
    }
}
