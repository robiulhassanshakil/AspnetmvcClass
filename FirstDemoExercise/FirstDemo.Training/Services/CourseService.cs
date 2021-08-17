using FirstDemo.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstDemo.Training.Contexts;

namespace FirstDemo.Training.Services
{
    public class CourseService : ICourseService
    {
        private readonly TrainingDbContext _trainingDbContext;
        public CourseService(TrainingDbContext trainingDbContext)
        {
            _trainingDbContext = trainingDbContext;
        }
        public List<Course> GetAllCourses()
        {
            var coursesEntities = _trainingDbContext.Courses.ToList();

            var Courses = new List<Course>();
            foreach (var entity in coursesEntities)
            {
                var course = new Course();
                course.Title = entity.Title;
                course.Fees = entity.Fees;

                Courses.Add(course);
            }

            return Courses;
        }
    }
}
