using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstDemo.Training.BusinessObjects;

namespace FirstDemo.Training.Services
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();
    }
}
