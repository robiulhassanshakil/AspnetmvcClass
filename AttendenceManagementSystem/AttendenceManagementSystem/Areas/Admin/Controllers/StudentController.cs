using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendenceManagementSystem.Areas.Admin.Models;
using AttendenceManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace AttendenceManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model = new StudentListModel();
            return View(model);
        }

        public JsonResult GetStudentData()
        {
            var DataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new StudentListModel();
            var data = model.GetStudentData(DataTableModel);
            return Json(data);
        }

        public IActionResult Create()
        {
            var model = new CreateStudentModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateStudentModel model)
        {
            try
            {
                model.CreateStudent();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Failed To Create Student");
                _logger.LogError(ex, "Create Student Failed");

            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditStudentModel();
            model.LoadModelData(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditStudentModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new StudentListModel();
            model.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
