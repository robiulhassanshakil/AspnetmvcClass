using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AttendanceManagementSystem.Attendance.BusinessObjects;
using AttendanceManagementSystem.Attendance.Services;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AttendanceManagementSystem.Areas.Admin.Models
{
    public class CreateStudentModel
    {
        [Required, MaxLength(200, ErrorMessage = "Name should be less than 200 charecters")]
        public string Name { get; set; }

        [Required, Range(1, 50000)]
        public int StudentRollNumber { get; set; }

        private readonly IAttendanceService _attendanceService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CreateStudentModel()
        {
            _attendanceService = Startup.AutofacContainer.Resolve<IAttendanceService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
            _mapper= Startup.AutofacContainer.Resolve<IMapper>();
        }

        public CreateStudentModel(IAttendanceService attendanceService, IHttpContextAccessor httpContextAccessor,IMapper mapper)
        {
            _attendanceService = attendanceService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        internal void CreateStudent()
        {
            var student = _mapper.Map<Student>(this);
            _attendanceService.CreateStudent(student);

        }
    }
}
