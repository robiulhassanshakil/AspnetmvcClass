using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendenceManagementSystem.Attendence.Entities;
using AttendenceManagementSystem.Data;

namespace AttendenceManagementSystem.Attendence.Repositories
{
    public interface IStudentRepository:IRepository<Student,int>
    {
    }
}
