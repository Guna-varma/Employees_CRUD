using Emp.DataAccess.Repository.IRepository;
using Emp.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    public class EmployeeDetailsController : Controller
    {

        private readonly IUnitOfWork repo;

        public EmployeeDetailsController(IUnitOfWork empRepo)
        {
            repo = empRepo;
        }

        public IActionResult Index()
        {
            List<EmployeeDetails> categories = repo.employeeDetails.GetAll().ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDetails EmployeeDetails)
        {

            if (ModelState.IsValid) //validations
            {
                repo.employeeDetails.Add(EmployeeDetails); // add EmployeeDetails 
                repo.Save(); //save
                TempData["success"] = "EmployeeDetails Created Successfully!";
                return RedirectToAction("Index"); // add the data into db
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            EmployeeDetails EmployeeDetailsFromDb = repo.employeeDetails.Get(u => u.Id == id);
            if (EmployeeDetailsFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(EmployeeDetailsFromDb);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeDetails EmployeeDetails)
        {
            if (ModelState.IsValid) //validations
            {
                repo.employeeDetails.Update(EmployeeDetails);// add EmployeeDetails 
                repo.Save(); //save
                TempData["success"] = "EmployeeDetails Updated Successfully!";

                return RedirectToAction("Index"); // add the data into db
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            EmployeeDetails EmployeeDetailsFromDb = repo.employeeDetails.Get(u => u.Id == id);
            if (EmployeeDetailsFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(EmployeeDetailsFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            EmployeeDetails? obj = repo.employeeDetails.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound("Id:" + id + ", is not Found");
            }
            repo.employeeDetails.Remove(obj);
            repo.Save();  //save
            TempData["success"] = "EmployeeDetails Deleted Successfully!";

            return RedirectToAction("Index");
        }
    }
}
