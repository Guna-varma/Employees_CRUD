using Emp.DataAccess.Repository.IRepository;
using Emp.Model.Models;
using Emp.Model.ViewModels;
using Emp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employees.Areas.Employees.Controllers
{
    [Area("Employees")]
    [Authorize(Roles = KEYS.Role_ADMIN)]
    public class BankDetailsController : Controller
    {

        private readonly IUnitOfWork repo;

        public BankDetailsController(IUnitOfWork bankRepo)
        {
            repo = bankRepo;
        }

        public IActionResult Index()
        {
            List<BankDetails> bankDetails = repo.bankDetails.GetAll(includeProperties: "EmployeeDetails").ToList();

            return View(bankDetails);
        }

        public IActionResult Create()
        {
            BankDetailsVM bankVM = new()
            {
                EmpList = repo.employeeDetails.GetAll().Select(u => new SelectListItem
                {
                    Text = u.EmployeeCode,
                    Value = u.Id.ToString()
                }),
                BankDetails = new BankDetails()
            };
            return View(bankVM);
        }

        [HttpPost]
        public IActionResult Create(BankDetailsVM bankVM)
        {
            if (ModelState.IsValid) //validations
            {
                repo.bankDetails.Add(bankVM.BankDetails); // add emp 
                repo.Save(); //save
                TempData["success"] = "Product Created Successfully!";
                return RedirectToAction("Index"); // add the data into db
            }
            else
            {
                bankVM.EmpList = repo.employeeDetails.GetAll().Select(u => new SelectListItem
                {
                    Text = u.EmployeeCode,
                    Value = u.Id.ToString()
                });
                return View(bankVM);
            }
        }

        public IActionResult Edit(int? id)
        {
            BankDetailsVM bankEditVM = new()
            {
                EmpList = repo.employeeDetails.GetAll().Select(u => new SelectListItem
                {
                    Text = u.EmployeeCode,
                    Value = u.Id.ToString()
                }),
                BankDetails = new BankDetails()
            };

            bankEditVM.BankDetails = repo.bankDetails.Get(u => u.Id == id);
            return View(bankEditVM);
        }

        [HttpPost]
        public IActionResult Edit(BankDetailsVM bankEditVM)
        {
            if (ModelState.IsValid) //validations
            {
                repo.bankDetails.Update(bankEditVM.BankDetails); // edit Employee 
                repo.Save(); //save
                TempData["success"] = "Product Updated Successfully!";
                return RedirectToAction("Index"); // add the data into db
            }
            else
            {
                bankEditVM.EmpList = repo.employeeDetails.GetAll().Select(u => new SelectListItem
                {
                    Text = u.EmployeeCode,
                    Value = u.Id.ToString()
                });
                return View(bankEditVM);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null | id <= 0)
            {
                return NotFound("No Id is found");
            }
            BankDetails BankDetailsFromDb = repo.bankDetails.Get(u => u.Id == id);
            if (BankDetailsFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(BankDetailsFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            BankDetails? obj = repo.bankDetails.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound("Id:" + id + ", is not Found");
            }
            repo.bankDetails.Remove(obj);
            repo.Save();  //save
            TempData["success"] = "BankDetails Deleted Successfully!";

            return RedirectToAction("Index");
        }
    }
}
