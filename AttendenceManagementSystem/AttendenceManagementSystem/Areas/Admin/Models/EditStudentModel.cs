using AttendenceManagementSystem.Attendence.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AttendenceManagementSystem.Attendence.BusinessObjects;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AttendenceManagementSystem.Areas.Admin.Models
{
    public class EditStudentModel
    {
        [Required, Range(1, 50000)]
        public int? Id { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Name should be less than 200 charecters")]
        public string Name { get; set; }
        [Required, Range(1, 50000)]
        public int StudentRollNumber { get; set; }

        private readonly IAttendenceService _attendenceService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public EditStudentModel()
        {
            _attendenceService = Startup.AutofacContainer.Resolve<IAttendenceService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
            _mapper= Startup.AutofacContainer.Resolve<IMapper>();
        }
        public EditStudentModel(IAttendenceService attendenceService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _attendenceService = attendenceService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        internal void LoadModelData(int id)
        {
            var student = _attendenceService.GetStudent(id);

            _mapper.Map(student, this);
        }

        internal void Update()
        {
            var student = _mapper.Map<Student>(this);
            _attendenceService.UpdateStudent(student);
        }
    }
   
}
