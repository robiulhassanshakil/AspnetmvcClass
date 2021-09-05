using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendenceManagementSystem.Areas.Admin.Models;
using AttendenceManagementSystem.Attendence.BusinessObjects;
using AutoMapper;


namespace AttendenceManagementSystem.Profiles
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
