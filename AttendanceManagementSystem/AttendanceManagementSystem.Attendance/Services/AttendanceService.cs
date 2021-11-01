using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceManagementSystem.Attendance.BusinessObjects;
using AttendanceManagementSystem.Attendance.UniteOfWork;
using AutoMapper;

namespace AttendanceManagementSystem.Attendance.Services
{
    public class AttendanceService:IAttendanceService
    {
        private readonly IAttendanceUniteOfWork _attendenceUniteOfWork;
        private readonly IMapper _mapper;

        public AttendanceService(IAttendanceUniteOfWork attendenceUniteOfWork,IMapper mapper)
        {
            _attendenceUniteOfWork = attendenceUniteOfWork;
            _mapper = mapper;
        }

        public void CreateStudent(Student student)
        {
            _attendenceUniteOfWork.Students.Add(_mapper.Map<Entities.Student>(student));
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

            return _mapper.Map<Student>(student);
        }

        public (IList<Student> records, int total, int totalDisplay) GetStudents(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var studentData = _attendenceUniteOfWork.Students.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);
            var resultData = (from student in studentData.data
                select (_mapper.Map<Student>(student))).ToList();

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
                _mapper.Map(student, studentEntity);
                _attendenceUniteOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Couldn't find Student");
            }
        }
    }
}
