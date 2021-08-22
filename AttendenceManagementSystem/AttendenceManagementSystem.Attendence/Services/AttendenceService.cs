using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendenceManagementSystem.Attendence.BusinessObjects;
using AttendenceManagementSystem.Attendence.UniteOfWork;

namespace AttendenceManagementSystem.Attendence.Services
{
    public class AttendenceService:IAttendenceService
    {
        private readonly IAttendenceUniteOfWork _attendenceUniteOfWork;

        public AttendenceService(IAttendenceUniteOfWork attendenceUniteOfWork)
        {
            _attendenceUniteOfWork = attendenceUniteOfWork;
        }

        public void CreateStudent(Student student)
        {
            _attendenceUniteOfWork.Students.Add(new Entities.Student()
            {
                Name = student.Name,
                StudentRollNumber = student.StudentRollNumber
            });
            _attendenceUniteOfWork.Save();
        }

        public void DeleteStudent(int id)
        {
            _attendenceUniteOfWork.Students.Remove(id);
            _attendenceUniteOfWork.Save();
        }

        public Student GetStudent(int id)
        {
            var student = _attendenceUniteOfWork.Students.GetById(id);

            if (student == null) return null;

            return new Student()
            {
                Id = student.Id,
                Name = student.Name,
                StudentRollNumber = student.StudentRollNumber

            };
        }

        public (IList<Student> records, int total, int totalDisplay) GetStudents(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var studentData = _attendenceUniteOfWork.Students.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);
            var resultData = (from student in studentData.data
                select (new Student()
                {
                    Id = student.Id,
                    Name = student.Name,
                    StudentRollNumber = student.StudentRollNumber
                })).ToList();

            return (resultData, studentData.total, studentData.totalDisplay);
        }

        public void UpdateStudent(Student student)
        {
            if (student==null)
            {
                throw new InvalidOperationException("Student is messing");
            }

            var studentEntity = _attendenceUniteOfWork.Students.GetById(student.Id);
            if (studentEntity != null)
            {
                studentEntity.Name = student.Name;
                studentEntity.StudentRollNumber = student.StudentRollNumber;
                
                _attendenceUniteOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Couldn't find Student");
            }
        }
    }
}
