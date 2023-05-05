using Emp.DataAccess.Repository;
using Emp.DataAccess.Repository.IRepository;
using Emp.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Employees.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork repo;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            repo = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<EmployeeDetails> employees = repo.employeeDetails.GetAll(includeProperties: "Department");
            return View(employees);
        }

        public IActionResult Details(int? employeeId)
        {
            EmployeeDetails emp = repo.employeeDetails.Get(u => u.Id == employeeId, includeProperties: "Department");
            return View(emp);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}