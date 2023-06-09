﻿using Emp.DataAccess.Repository.IRepository;
using Emp.Model.Models;
using Emp.Model.ViewModels;
using Emp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;

namespace Employees.Areas.Employees.Controllers
{
    [Area("Employees")]
    [Authorize(Roles = KEYS.Role_ADMIN)]

    public class EmployeeDetailsController : Controller
    {

        private readonly IUnitOfWork repo;
        private readonly IWebHostEnvironment env;

        public EmployeeDetailsController(IUnitOfWork empRepo, IWebHostEnvironment environment)
        {
            repo = empRepo;
            env = environment;
        }


        [HttpPost]
        public IActionResult Upsert(EmpDetailsVM empDetailsVM, IFormFile? file)
        {
            if (ModelState.IsValid) //validations
            {
                string wweRootPath = env.WebRootPath;
                if (file != null)
                {
                    // File type validation
                    string[] allowedExtensions = { ".png", ".jpg", ".jpeg" };
                    string fileExtension = Path.GetExtension(file.FileName).ToLower();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("File", "Only .png, .jpeg and .jpg files are allowed.");
                        empDetailsVM.DeptList = repo.department.GetAll().Select(u => new SelectListItem
                        {
                            Text = u.DepartmentName,
                            Value = u.Id.ToString()
                        });
                        return View(empDetailsVM);
                    }

                    // File size validation
                    long maxFileSize = 5 * 1024 * 1024; // 5MB
                    if (file.Length > maxFileSize)
                    {
                        ModelState.AddModelError("File", "File size must be less than 5MB.");
                        empDetailsVM.DeptList = repo.department.GetAll().Select(u => new SelectListItem
                        {
                            Text = u.DepartmentName,
                            Value = u.Id.ToString()
                        });
                        return View(empDetailsVM);
                    }

                    string fileName = Guid.NewGuid().ToString() + fileExtension;

                    string empFilePath = Path.Combine(wweRootPath, @"images\employeeDetails\");

                    if (!string.IsNullOrEmpty(empDetailsVM.EmployeeDetails.ImageURL))
                    {
                        //delete old image path
                        var oldImagePath =
                            Path.Combine(wweRootPath, empDetailsVM.EmployeeDetails.ImageURL.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(empFilePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    empDetailsVM.EmployeeDetails.ImageURL = @"\images\employeeDetails\" + fileName;
                }
                if (empDetailsVM.EmployeeDetails.Id == null || empDetailsVM.EmployeeDetails.Id == 0)
                {
                    repo.employeeDetails.Add(empDetailsVM.EmployeeDetails); // add Product 

                    repo.Save(); //save
                    TempData["success"] = "Employee Created Successfully!";
                }
                else
                {
                    repo.employeeDetails.Update(empDetailsVM.EmployeeDetails); // add Product 

                    repo.Save(); //save
                    TempData["success"] = "Employee Updated Successfully!";
                }

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
        }

        public IActionResult Index()
        {
            List<EmployeeDetails> employeeDetails = repo.employeeDetails.GetAll(includeProperties: "Department").ToList();

            return View(employeeDetails);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<EmployeeDetails> employeesList = repo.employeeDetails.GetAll(includeProperties: "Department").ToList();

            return Json(new { data = employeesList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var employeeToBeDeleted = repo.employeeDetails.Get(u => u.Id == id);
            if (employeeToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            //delete old image path
            var oldImagePath =
                Path.Combine(env.WebRootPath, employeeToBeDeleted.ImageURL.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            repo.employeeDetails.Remove(employeeToBeDeleted);
            repo.Save();

            return Json(new { success = true, message = "Deleted Successfully!" });
        }


        public IActionResult Upsert(int? id)  // combining of 'Update' and 'Insert'.
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
            if (id == null || id == 0)
            {
                //create
                return View(empDetailsVM);
            }
            else
            {
                //update
                empDetailsVM.EmployeeDetails = repo.employeeDetails.Get(u => u.Id == id);
                return View(empDetailsVM);
            }
        }

        /*
         
        [HttpPost]
        public IActionResult Upsert(EmpDetailsVM empDetailsVM, IFormFile? file)
        {
            if (ModelState.IsValid) //validations
            {
                string wweRootPath = env.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string empFilePath = Path.Combine(wweRootPath, @"images\employeeDetails\");

                    if (!string.IsNullOrEmpty(empDetailsVM.EmployeeDetails.ImageURL))
                    {
                        //delete old image path
                        var oldImagePath =
                            Path.Combine(wweRootPath, empDetailsVM.EmployeeDetails.ImageURL.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(empFilePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    empDetailsVM.EmployeeDetails.ImageURL = @"\images\employeeDetails\" + fileName;
                }
                if (empDetailsVM.EmployeeDetails.Id == null || empDetailsVM.EmployeeDetails.Id == 0)
                {
                    repo.employeeDetails.Add(empDetailsVM.EmployeeDetails); // add Product 

                    repo.Save(); //save
                    TempData["success"] = "Employee Created Successfully!";
                }
                else
                {
                    repo.employeeDetails.Update(empDetailsVM.EmployeeDetails); // add Product 

                    repo.Save(); //save
                    TempData["success"] = "Employee Updated Successfully!";
                }

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
        } 
        
        */
    }
}