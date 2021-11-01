using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceManagementSystem.Attendance.Contexts;
using AttendanceManagementSystem.Attendance.Repositories;
using AttendanceManagementSystem.Data;
using Microsoft.EntityFrameworkCore;


namespace AttendanceManagementSystem.Attendance.UniteOfWork
{
    public class AttendanceUniteOfWork : UnitOfWork,IAttendanceUniteOfWork
    {
        public IStudentRepository Students { get; private set;}
        public IAttendanceRepository Attendances { get; private set;}

        public AttendanceUniteOfWork(IAttendanceDbContext context,
            IStudentRepository students,
            IAttendanceRepository attendances) : base((DbContext)context)
        {
            Students = students;
            Attendances = attendances;
        }
    }
}
