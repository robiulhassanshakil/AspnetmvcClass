using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendenceManagementSystem.Attendence.Contexts;
using AttendenceManagementSystem.Attendence.Entities;
using AttendenceManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendenceManagementSystem.Attendence.Repositories
{
    public class StudentRepository:Repository<Student,int>,
        IStudentRepository
    {
        public StudentRepository(IAttendenceDbContext context)
            : base((DbContext)context)
        {

        }

    }
}
