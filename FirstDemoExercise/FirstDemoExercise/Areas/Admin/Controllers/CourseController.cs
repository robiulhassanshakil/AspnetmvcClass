using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstDemoExercise.Areas.Admin.Models;

namespace FirstDemoExercise.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var model = new CourseListModel();
            return View();
        }
    }
}
