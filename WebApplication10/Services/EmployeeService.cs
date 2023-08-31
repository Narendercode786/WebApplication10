using Microsoft.Data.SqlClient;
using WebApplication10.Interface;
using WebApplication10.Models;

namespace WebApplication10.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly IConfiguration configuration;

        public EmployeeService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(this.configuration["SQLConnection"]);
        }
        public IEnumerable<Employee> GetEmployees()
        {
            SqlConnection sqlConnection = GetSqlConnection();
            List<Employee> employees = new List<Employee>();
            string query = "SELECT Id,Name,Address FROM Employee WITH(NOLOCK)";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            using(SqlDataReader sqlDataReader= sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    employee.Name = sqlDataReader["Name"].ToString();
                    employee.Address = sqlDataReader["Address"].ToString();
                    employees.Add(employee);
                }
            }
            sqlConnection.Close();
            return employees;
        }
    }
}
