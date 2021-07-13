using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FirstDemo.Training.BusinessObjects;
using FirstDemo.Training.Services;

namespace FirstDemoExercise.Areas.Admin.Models
{
    public class CourseListModel
    {
        private readonly ICourseService _courseService;

        public List<Course> Courses { get; set; }
        public CourseListModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }

        public CourseListModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void LoadModelData()
        {
            Courses = _courseService.GetAllCourses();

        }
    }
}
