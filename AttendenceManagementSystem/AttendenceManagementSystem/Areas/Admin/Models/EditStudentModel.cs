using AttendenceManagementSystem.Attendence.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AttendenceManagementSystem.Attendence.BusinessObjects;
using Autofac;

namespace AttendenceManagementSystem.Areas.Admin.Models
{
    public class EditStudentModel
    {
        [Required, Range(1, 50000)]
        public int? Id { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Name should be less than 200 charecters")]
        public string Name { get; set; }

        public int? StudentRollName { get; set; }

        private readonly IAttendenceService _attendenceservice;
        public EditStudentModel()
        {
            _attendenceservice = Startup.AutofacContainer.Resolve<IAttendenceService>();
        }

        internal void LoadModelData(int id)
        {
            var student = _attendenceservice.GetStudent(id);

            Id = student?.Id;
            Name = student.Name;
            StudentRollName = student?.StudentRollNumber;
        }

        internal void Update()
        {
            var student = new Student()
            {
                Id = Id.Value,
                Name = Name,
                StudentRollNumber = StudentRollName.HasValue ? StudentRollName.Value : 0
            };
            _attendenceservice.UpdateStudent(student);
        }
    }
   
}
