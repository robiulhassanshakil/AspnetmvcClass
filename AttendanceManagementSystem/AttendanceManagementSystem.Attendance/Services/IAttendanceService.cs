using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceManagementSystem.Attendance.BusinessObjects;

namespace AttendanceManagementSystem.Attendance.Services
{
    public interface IAttendanceService
    {
        void CreateStudent(Student student);
        (IList<Student> records,int total,int totalDisplay) GetStudents(int pageIndex, int pageSize, string searchText, string sortText);
        Student GetStudent(int id);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
