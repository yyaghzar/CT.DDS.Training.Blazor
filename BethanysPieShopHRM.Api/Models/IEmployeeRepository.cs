using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Api.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeModel> GetAllEmployees();
        EmployeeModel GetEmployeeById(int employeeId);
        EmployeeModel AddEmployee(EmployeeModel employee);
        EmployeeModel UpdateEmployee(EmployeeModel employee);
        void DeleteEmployee(int employeeId);
    }
}
