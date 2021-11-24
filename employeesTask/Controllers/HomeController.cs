using employeesTask.Data;
using employeesTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace employeesTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _db;

        public HomeController(ILogger<HomeController> logger,ApplicationContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            // this is only for task purposes
            if (_db.Departments.Count() == 0)
            {
                _db.Departments.Add(new DepartmentModel { Name_Ar = "المحاسبة", Name_En = "Accounting" });
                _db.Departments.Add(new DepartmentModel { Name_Ar = "تكنولوجيا المعلومات", Name_En = "IT" });
                _db.SaveChanges();
            }
            return View();
        }

        

        public IActionResult AddEmployee()
        {
            ViewBag.Departments = _db.Departments.Select(a => new { Value = a.Id, Text = a.Name_Ar }).ToList();
            return View();
        }

        public IActionResult EditEmployee()
        {
            ViewBag.Departments = _db.Departments.Select(a => new { Value = a.Id, Text = a.Name_Ar }).ToList();
            return View();
        }

    }
}
