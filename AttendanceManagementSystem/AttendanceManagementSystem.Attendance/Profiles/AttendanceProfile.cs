using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceManagementSystem.Attendance.Entities;
using AutoMapper;
using EO = AttendanceManagementSystem.Attendance.Entities;
using BO = AttendanceManagementSystem.Attendance.BusinessObjects;

namespace AttendanceManagementSystem.Attendance.Profiles
{
    public class AttendanceProfile : Profile
    {
        public AttendanceProfile()
        {
            CreateMap<Student, BusinessObjects.Student>().ReverseMap();
        }
    }
}
