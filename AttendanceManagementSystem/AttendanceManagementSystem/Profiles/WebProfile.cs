using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceManagementSystem.Areas.Admin.Models;
using AttendanceManagementSystem.Attendance.BusinessObjects;
using AutoMapper;


namespace AttendanceManagementSystem.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<CreateStudentModel, Student>().ReverseMap();
            CreateMap<EditStudentModel, Student>().ReverseMap();
            CreateMap<StudentListModel, Student>().ReverseMap();
        }
    }
}
