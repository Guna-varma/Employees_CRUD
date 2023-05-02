using Emp.DataAccess.Repository.IRepository;
using Emp.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Areas.Employees.Controllers
{
    [Area("Employees")]
    public class ProjectController : Controller
    {

        private readonly IUnitOfWork repo;

        public ProjectController(IUnitOfWork projRepo)
        {
            repo = projRepo;
        }

        public IActionResult Index()
        {
            List<Project> projects = repo.project.GetAll().ToList();

            return View(projects);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project Project)
        {

            if (ModelState.IsValid) //validations
            {
                repo.project.Add(Project); // add Project 
                repo.Save(); //save
                TempData["success"] = "Project Created Successfully!";
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
            Project ProjectFromDb = repo.project.Get(u => u.Id == id);
            if (ProjectFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(ProjectFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Project Project)
        {
            if (ModelState.IsValid) //validations
            {
                repo.project.Update(Project);// add Project 
                repo.Save(); //save
                TempData["success"] = "Project Updated Successfully!";

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
            Project ProjectFromDb = repo.project.Get(u => u.Id == id);
            if (ProjectFromDb == null)
            {
                return NotFound("id: " + id + ", is not found!");
            }
            return View(ProjectFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Project? obj = repo.project.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound("Id:" + id + ", is not Found");
            }
            repo.project.Remove(obj);
            repo.Save();  //save
            TempData["success"] = "Project Deleted Successfully!";

            return RedirectToAction("Index");
        }
    }
}
