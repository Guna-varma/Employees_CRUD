using Emp.DataAccess.Repository.IRepository;
using Emp.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Areas.Employees.Controllers
{
    [Area("Employees")]
    public class BankDetailsController : Controller
    {

        private readonly IUnitOfWork repo;

        public BankDetailsController(IUnitOfWork bankRepo)
        {
            repo = bankRepo;
        }

        public IActionResult Index()
        {
            List<BankDetails> bankDetails = repo.bankDetails.GetAll().ToList();

            return View(bankDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BankDetails BankDetails)
        {

            if (ModelState.IsValid) //validations
            {
                repo.bankDetails.Add(BankDetails); // add BankDetails 
                repo.Save(); //save
                TempData["success"] = "BankDetails Created Successfully!";
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
            BankDetails BankDetailsFromDb = repo.bankDetails.Get(u => u.Id == id);
            if (BankDetailsFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(BankDetailsFromDb);
        }

        [HttpPost]
        public IActionResult Edit(BankDetails BankDetails)
        {
            if (ModelState.IsValid) //validations
            {
                repo.bankDetails.Update(BankDetails);// add BankDetails 
                repo.Save(); //save
                TempData["success"] = "BankDetails Updated Successfully!";

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
