using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceManagementSystem.Attendance.Services;
using AttendanceManagementSystem.Common.Utilities;
using Autofac;
using Microsoft.AspNetCore.Http;

namespace AttendanceManagementSystem.Api.Models
{
    public class StudentListModel
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StudentListModel()
        {
            _attendanceService = Startup.AutofacContainer.Resolve<IAttendanceService>();
            _httpContextAccessor= Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }
        public StudentListModel(IAttendanceService attendanceService, IHttpContextAccessor httpContextAccessor)
        {
            _attendanceService = attendanceService;
            _httpContextAccessor = httpContextAccessor;
        }

        internal object GetStudentData(DataTablesAjaxRequestModel dataTableModel)
        {
            var PageIndex = 1;
            var PageSize = 10;
            var SearchText = string.Empty;
            var SortText = "Name";
            /* var data = _attendanceService.GetStudents(
                 dataTableModel.PageIndex,
                 dataTableModel.PageSize,
                 dataTableModel.SearchText,
                 dataTableModel.GetSortText(new string[] {"Name", "StudentRollNumber"}));*/
            var data = _attendanceService.GetStudents(
                PageIndex,
                PageSize,
                SearchText,
                SortText);

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.StudentRollNumber.ToString(),
                            record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void Delete(int id)
        {
            _attendanceService.DeleteStudent(id);
        }
    }
}
