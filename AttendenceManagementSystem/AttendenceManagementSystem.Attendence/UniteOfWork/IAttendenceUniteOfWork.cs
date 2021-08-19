using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendenceManagementSystem.Attendence.Repositories;
using AttendenceManagementSystem.Data;

namespace AttendenceManagementSystem.Attendence.UniteOfWork
{
    public interface IAttendenceUniteOfWork:IUnitOfWork
    {
         IStudentRepository Students { get; }
         IAttendenceRepository Attendences { get; }
    }
}
