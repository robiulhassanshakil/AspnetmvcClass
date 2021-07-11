using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstDemoExercise.Models;

namespace FirstDemoExercise.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult PersonData()
        {
            var person1 = new Person();
            return View(person1);
        }
    }
}
