using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AttendenceManagementSystem.Attendence.BusinessObjects;
using AttendenceManagementSystem.Attendence.Services;
using Autofac;

namespace AttendenceManagementSystem.Areas.Admin.Models
{
    public class CreateStudentModel
    {
        [Required, MaxLength(200, ErrorMessage = "Name should be less than 200 charecters")]
        public string Name { get; set; }

        [Required, Range(1, 50000)]
        public int StudentRollNumber { get; set; }

        private readonly IAttendenceService _attendenceService;

        public CreateStudentModel()
        {
            _attendenceService = Startup.AutofacContainer.Resolve<IAttendenceService>();
        }

        public CreateStudentModel(IAttendenceService attendenceService)
        {
            _attendenceService = attendenceService;
        }

        internal void CreateStudent()
        {
            var student = new Student()
            {
                Name = Name,
                StudentRollNumber = StudentRollNumber
            };
            _attendenceService.CreateStudent(student);

        }
    }
}
