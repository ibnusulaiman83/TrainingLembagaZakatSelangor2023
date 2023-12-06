using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using TrainingLZS.Data;
using TrainingLZS.Models;

namespace TrainingLZS.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly TrainingLZSDbContext _context;

        public EmployeeController(TrainingLZSDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.Include("Departments");
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadDepartment(); // load department daripada function LoadDepartment()
            return View();
        }

        [NonAction]
        public void LoadDepartment()
        {
            var departments = _context.Departments.ToList();
            ViewBag.Departments = new SelectList(departments, "Id","Name");   
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            _context.Employees.Add(model);  
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

       
        //[HttpPost]
        //public async Task<IActionResult> Tambah(Employee model)
        //{
        //    var employee = new Employee()
        //    {
        //        Name = model.Name,
        //        PhoneNo = model.PhoneNo,
        //        DepartmentID = model.DepartmentID,
        //        Email = model.Email,
        //        Address = model.Address
        //    };

        //    await _context.Employees.AddAsync(employee);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id != null) {
                NotFound();
            }
            var employee = _context.Employees.Find(id);
            return View(employee);

        }

        [HttpGet]
        public IActionResult Edit(int ? id)
        {
            if (id != null)
            {
                NotFound();
            }

            LoadDepartment(); // load department daripada function LoadDepartment()
            var employee = _context.Employees.Find(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            ModelState.Remove("Departments");

            if (ModelState.IsValid)
            {
                _context.Employees.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        

        [HttpPost]
        public async Task<IActionResult> Kemaskini(Employee model)
        {
            var employee = await _context.Employees.FindAsync(model.Id);

            if (employee != null)
            {
                employee.Name = model.Name;
                employee.PhoneNo = model.PhoneNo;
                employee.DepartmentID = model.DepartmentID;
                employee.Email = model.Email;
                employee.Address = model.Address;
                employee.PhoneNo = model.PhoneNo;

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Employee model)
        {
            _context.Employees.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id != null)
            {
                NotFound();
            }
            var employee = _context.Employees.Find(id);
            return View(employee);

        }

        


    }
}
