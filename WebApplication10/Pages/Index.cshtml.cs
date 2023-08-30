using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication10.Interface;
using WebApplication10.Models;
using WebApplication10.Services;

namespace WebApplication10.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmployee employee;
        public IEnumerable<Employee> Employees;

        public IndexModel(ILogger<IndexModel> logger,IEmployee employee)
        {
            _logger = logger;
            this.employee = employee;
        }

        public void OnGet()
        {
            Employees = this.employee.GetEmployees();
        }
    }
}
