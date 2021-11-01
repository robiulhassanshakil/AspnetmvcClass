using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceManagementSystem.Attendance.Contexts;
using AttendanceManagementSystem.Attendance.Entities;
using AttendanceManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceManagementSystem.Attendance.Repositories
{
    public class StudentRepository:Repository<Student,int>,
        IStudentRepository
    {
        public StudentRepository(IAttendanceDbContext context)
            : base((DbContext)context)
        {

        }

    }
}
