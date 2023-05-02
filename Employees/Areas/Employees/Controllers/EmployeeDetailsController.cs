using Emp.DataAccess.Repository.IRepository;
using Emp.Model.Models;
using Emp.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employees.Areas.Employees.Controllers
{
    [Area("Employees")]
    public class EmployeeDetailsController : Controller
    {

        private readonly IUnitOfWork repo;

        public EmployeeDetailsController(IUnitOfWork empRepo)
        {
            repo = empRepo;
        }

        public IActionResult Index()
        {
            List<EmployeeDetails> categories = repo.employeeDetails.GetAll(includeProperties:"Department").ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            EmpDetailsVM empVM = new()
            {
                DeptList = repo.department.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DepartmentName,
                    Value = u.Id.ToString()
                }),
                EmployeeDetails = new EmployeeDetails()
            };
            return View(empVM);
        }

        [HttpPost]
        public IActionResult Create(EmpDetailsVM empVM)
        {

            if (ModelState.IsValid) //validations
            {
                repo.employeeDetails.Add(empVM.EmployeeDetails); // add emp 
                repo.Save(); //save
                TempData["success"] = "Product Created Successfully!";
                return RedirectToAction("Index"); // add the data into db
            }
            else
            {
                empVM.DeptList = repo.department.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DepartmentName,
                    Value = u.Id.ToString()
                });
                return View(empVM);
            }
        }

        public IActionResult Edit(int? id)
        {
            EmpDetailsVM empEditVM = new()
            {
                DeptList = repo.department.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DepartmentName,
                    Value = u.Id.ToString()
                }),
                EmployeeDetails = new EmployeeDetails()
            };

            empEditVM.EmployeeDetails = repo.employeeDetails.Get(u => u.Id == id);
            return View(empEditVM);
        }

        [HttpPost]
        public IActionResult Edit(EmpDetailsVM empEditVM)
        {
            if (ModelState.IsValid) //validations
            {
                repo.employeeDetails.Update(empEditVM.EmployeeDetails); // edit Employee 
                repo.Save(); //save
                TempData["success"] = "Product Updated Successfully!";
                return RedirectToAction("Index"); // add the data into db
            }
            else
            {
                empEditVM.DeptList = repo.department.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DepartmentName,
                    Value = u.Id.ToString()
                });
                return View(empEditVM);
            }
        }

        /* public IActionResult Create()

        {
            EmpDetailsVM empDetailsVM = new()
            {
                DeptList = repo.department.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DepartmentName,
                    Value = u.Id.ToString()
                }),
                EmployeeDetails = new EmployeeDetails()
            };

            return View();
        }

        [HttpPost]
        public IActionResult Create(EmpDetailsVM empDetailsVM)
        {

            if (ModelState.IsValid) //validations
            {
                repo.employeeDetails.Add(empDetailsVM.EmployeeDetails); // add EmployeeDetails 
                repo.Save(); //save
                TempData["success"] = "EmployeeDetails Created Successfully!";
                return RedirectToAction("Index"); // add the data into db
            }
            else
            {
                empDetailsVM.DeptList = repo.department.GetAll().Select(u => new SelectListItem
                {
                    Text = u.DepartmentName,
                    Value = u.Id.ToString()
                });
                return View(empDetailsVM);
            }

        } */

        /*  public IActionResult Edit(int? id)
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
         } */

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
