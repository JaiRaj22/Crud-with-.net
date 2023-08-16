using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Domain;

namespace WebApplication1.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MvcDbcontext _demoMvc;

        public EmployeesController(MvcDbcontext demoMvc)
        {
            _demoMvc = demoMvc;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeview addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                DOB = addEmployeeRequest.DOB.ToUniversalTime(),
                Department = addEmployeeRequest.Department,
            };
            await _demoMvc.Employees.AddAsync(employee);
            await _demoMvc.SaveChangesAsync();
            return RedirectToAction("Add"); 
        }
    }
}
