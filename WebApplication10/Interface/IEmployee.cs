using WebApplication10.Models;

namespace WebApplication10.Interface
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetEmployees();
    }
}
