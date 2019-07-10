using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloRadyaWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelloRadyaWebMVC.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<EmployeeViewModel> employeeList = GetEmployees().ToList();

            ViewBag.EmployeeList = employeeList;
            ViewBag.PositionOption = new SelectList(new List<EmployeePosition> { EmployeePosition.WEB, EmployeePosition.ANDROID });

            ViewData["EmployeeList"] = employeeList;

            return View(employeeList);
        }

        [HttpPost]
        public IActionResult Index(EmployeeFilterViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            if (model == null)
                return NotFound();

            if (string.IsNullOrEmpty(model.keyword))
                model.keyword = string.Empty;

            List<EmployeeViewModel> employeeList = GetEmployees()
                .Where(x=>x.PositionEnum == model.employeePosition 
                && x.Name.Contains(model.keyword)
                ).ToList();

            ViewBag.PositionOption = new SelectList(new List<EmployeePosition> { EmployeePosition.WEB, EmployeePosition.ANDROID }, model.employeePosition);
            ViewBag.Keyword = model.keyword;

            ViewData["EmployeeList"] = employeeList;

            return View(employeeList);
        }

        public IActionResult Detail(int? id)
        {
            //Guard Clause
            if (id == null)
                return NotFound();

            var detailEmployee = GetEmployees().FirstOrDefault(x => x.Id == id);
            //var detailEmployee = (from a in GetEmployees()
            //                      where a.Id == id
            //                      select a).FirstOrDefault();

            return View(detailEmployee);
        }

        public IActionResult Add(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        private IEnumerable<EmployeeViewModel> GetEmployees()
        {
            yield return new EmployeeViewModel { Id = 1, PositionEnum = EmployeePosition.WEB, Name = "Rudi", Position = "Web Developer" };
            yield return new EmployeeViewModel { Id = 2, PositionEnum = EmployeePosition.WEB, Name = "Hegi", Position = "Web Developer" };
            yield return new EmployeeViewModel { Id = 3, PositionEnum = EmployeePosition.ANDROID, Name = "Ade", Position = "Android Developer" };
            yield return new EmployeeViewModel { Id = 4, PositionEnum = EmployeePosition.ANDROID, Name = "Yunus", Position = "Android Developer" };
            yield return new EmployeeViewModel { Id = 5, PositionEnum = EmployeePosition.WEB, Name = "Asep", Position = "Web Developer" };
        }
    }
}