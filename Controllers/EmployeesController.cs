using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCcrud.Data;
using MVCcrud.Models;
using MVCcrud.Models.Domain;

namespace MVCcrud.Controllers;

public class EmployeesController: Controller
{
   private readonly MVCDemoDbContext _dbContext;

   public EmployeesController(MVCDemoDbContext dbContext)
   {
      this._dbContext = dbContext;
   }
   
   [HttpGet]
   public async Task<IActionResult> Index()
   {
      var employees = await _dbContext.Employees.ToListAsync();
      return View(employees);
   }
   
   [HttpGet]
   public IActionResult Add()
   {
      return View();
   }
   
   [HttpPost]
   public async Task<IActionResult> Add(AddEmployeeViewModel employeeViewModel)
   {
      var employee = new Employee()
      {
         Id = Guid.NewGuid(),
         Name = employeeViewModel.Name,
         Email = employeeViewModel.Email,
         Salary = employeeViewModel.Salary,
         Department = employeeViewModel.Department,
         DateOfBirth = employeeViewModel.DateOfBirth
      };
      await _dbContext.Employees.AddAsync(employee);
      await _dbContext.SaveChangesAsync();
      return RedirectToAction("Index");
   }

   [HttpGet]
   public async Task<IActionResult> View(Guid id)
   {
      var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
      if (employee != null)
      {
         var employeeViewModel = new UpdateEmployeeViewModel()
         {
            Id = employee.Id,
            Name = employee.Name,
            Email = employee.Email,
            Salary = employee.Salary,
            Department = employee.Department,
            DateOfBirth = employee.DateOfBirth
         };
         return await Task.Run(() => View("View", employeeViewModel));
      }

      return RedirectToAction("Index");
   }

   [HttpPost]
   public async Task<IActionResult> View(UpdateEmployeeViewModel employeeViewModel)
   {
      var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeViewModel.Id);
      if (employee != null)
      {
         employee.Name = employeeViewModel.Name;
         employee.Email = employeeViewModel.Email;
         employee.Salary = employeeViewModel.Salary;
         employee.DateOfBirth = employeeViewModel.DateOfBirth;
         employee.Department = employeeViewModel.Department;

         await _dbContext.SaveChangesAsync();

         return RedirectToAction("Index");
      }

      return RedirectToAction("Index");
   }

   [HttpPost]
   public async Task<IActionResult> Delete(UpdateEmployeeViewModel employeeViewModel)
   {
      var employee = await _dbContext.Employees.FindAsync(employeeViewModel.Id);
      if (employee != null)
      {
         _dbContext.Employees.Remove(employee);
         await _dbContext.SaveChangesAsync();
         return RedirectToAction("Index");
      }
      return RedirectToAction("Index");
   }

}