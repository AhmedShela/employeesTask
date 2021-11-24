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
