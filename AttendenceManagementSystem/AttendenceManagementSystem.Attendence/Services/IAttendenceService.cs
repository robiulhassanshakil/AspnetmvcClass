using AttendenceManagementSystem.Attendence.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendenceManagementSystem.Attendence.Services
{
    public interface IAttendenceService
    {
        void CreateStudent(Student student);
        (IList<Student> records,int total,int totalDisplay) GetStudents(int pageIndex, int pageSize, string searchText, string sortText);
    }
}
