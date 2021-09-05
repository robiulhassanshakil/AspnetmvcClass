using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EO = AttendenceManagementSystem.Attendence.Entities;
using BO = AttendenceManagementSystem.Attendence.BusinessObjects;

namespace AttendenceManagementSystem.Attendence.Profiles
{
    public class AttendenceProfile : Profile
    {
        public AttendenceProfile()
        {
            CreateMap<EO.Student, BO.Student>().ReverseMap();
        }
    }
}
