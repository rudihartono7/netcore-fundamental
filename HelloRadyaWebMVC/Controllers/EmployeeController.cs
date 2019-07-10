using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloRadyaWebMVC.Data;
using HelloRadyaWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelloRadyaWebMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CompanyDbContext _db;
        public EmployeeController(CompanyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //List<EmployeeViewModel> employeeList = GetEmployees().ToList();

            List<EmployeeViewModel> employeeList = GetEmployeeFromDb();

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

            //List<EmployeeViewModel> employeeList = GetEmployees()
            //    .Where(x=>x.PositionEnum == model.employeePosition 
            //    && x.Name.Contains(model.keyword)
            //    ).ToList();

            List<EmployeeViewModel> employeeList = GetEmployeeFromDbWithWhereClause(model.employeePosition, model.keyword);

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

            var detailEmployee = GetDetailEmployee((int)id);

            //var detailEmployee = (from a in GetEmployees()
            //                      where a.Id == id
            //                      select a).FirstOrDefault();

            return View(detailEmployee);
        }

        private EmployeeViewModel GetDetailEmployee(int id)
        {
            return _db.Employees.Select(a => new EmployeeViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Position = a.Position,
                PositionEnum = a.PositionEnum,
            }).FirstOrDefault(x => x.Id == id);
        }

        public IActionResult Add(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AddEmployeeToDb(model);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var detailEmployee = GetDetailEmployee((int)id);

            ViewBag.PositionOption = new SelectList(new List<EmployeePosition>
            {
                EmployeePosition.WEB,
                EmployeePosition.ANDROID,
                EmployeePosition.ANALYST,
                EmployeePosition.DESIGNER,
                EmployeePosition.TESTER,
                EmployeePosition.PM
            }, detailEmployee.PositionEnum);

            return View(detailEmployee);
        }

        [HttpPost]
        public IActionResult Edit(int? id, EmployeeViewModel model)
        {
            if (id == null)
                return NotFound();

            var employee = _db.Employees.FirstOrDefault(x => x.Id == id);

            employee.Name = model.Name;
            employee.Position = model.Position;
            employee.PositionEnum = model.PositionEnum;

            _db.Update(employee);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        private void AddEmployeeToDb(EmployeeViewModel model)
        {
            Employee newEmployee = new Employee
            {
                Name = model.Name,
                Position = model.Position,
                PositionEnum = model.PositionEnum,
                IsActive = true
            };

            _db.Add<Employee>(newEmployee);
            _db.SaveChanges();
        }
        private List<EmployeeViewModel> GetEmployeeFromDbWithWhereClause(EmployeePosition employeePosition, string keyword)
        {
            return (from a in _db.Employees
                    where a.PositionEnum == employeePosition &&
                    a.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    select new EmployeeViewModel
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Position = a.Position,
                        PositionEnum = a.PositionEnum,
                    }).ToList();
        }
        private List<EmployeeViewModel> GetEmployeeFromDb()
        {
            return (from a in _db.Employees
                    select new EmployeeViewModel
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Position = a.Position,
                        PositionEnum = a.PositionEnum,
                    }).ToList();
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