using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendenceManagementSystem.Attendence.Contexts;
using AttendenceManagementSystem.Attendence.Repositories;
using AttendenceManagementSystem.Data;
using Microsoft.EntityFrameworkCore;


namespace AttendenceManagementSystem.Attendence.UniteOfWork
{
    public class AttendenceUniteOfWork:UnitOfWork,IAttendenceUniteOfWork
    {
        public IStudentRepository Students { get; private set;}
        public IAttendenceRepository Attendences { get; private set;}

        public AttendenceUniteOfWork(IAttendenceDbContext context,
            IStudentRepository students,
            IAttendenceRepository attendences) : base((DbContext)context)
        {
            Students = students;
            Attendences = attendences;
        }
    }
}
