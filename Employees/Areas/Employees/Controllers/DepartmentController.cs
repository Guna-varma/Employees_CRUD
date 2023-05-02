using Emp.DataAccess.Repository.IRepository;
using Emp.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Areas.Employees.Controllers
{
    [Area("Employees")]
    public class DepartmentController : Controller
    {

        private readonly IUnitOfWork repo;

        public DepartmentController(IUnitOfWork deptRepo)
        {
            repo = deptRepo;
        }

        public IActionResult Index()
        {
            List<Department> departments = repo.department.GetAll().ToList();

            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department Department)
        {

            if (ModelState.IsValid) //validations
            {
                repo.department.Add(Department); // add Department 
                repo.Save(); //save
                TempData["success"] = "Department Created Successfully!";
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
            Department DepartmentFromDb = repo.department.Get(u => u.Id == id);
            if (DepartmentFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(DepartmentFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Department Department)
        {
            if (ModelState.IsValid) //validations
            {
                repo.department.Update(Department);// add Department 
                repo.Save(); //save
                TempData["success"] = "Department Updated Successfully!";

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
            Department DepartmentFromDb = repo.department.Get(u => u.Id == id);
            if (DepartmentFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(DepartmentFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Department? obj = repo.department.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound("Id:" + id + ", is not Found");
            }
            repo.department.Remove(obj);
            repo.Save();  //save
            TempData["success"] = "Department Deleted Successfully!";

            return RedirectToAction("Index");
        }
    }
}
