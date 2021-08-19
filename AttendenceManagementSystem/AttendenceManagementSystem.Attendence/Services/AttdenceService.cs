using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendenceManagementSystem.Attendence.UniteOfWork;

namespace AttendenceManagementSystem.Attendence.Services
{
    public class AttdenceService:IAttdenceService
    {
        private readonly IAttendenceUniteOfWork _attendenceUniteOfWork;

        public AttdenceService(IAttendenceUniteOfWork attendenceUniteOfWork)
        {
            _attendenceUniteOfWork = attendenceUniteOfWork;
        }
    }
}
