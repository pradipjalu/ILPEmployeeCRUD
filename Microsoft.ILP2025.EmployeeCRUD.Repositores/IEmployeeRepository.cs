using Microsoft.ILP2025.EmployeeCRUD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ILP2025.EmployeeCRUD.Repositores
{
    public interface IEmployeeRepository
    {
        Task<EmployeeEntity> GetEmployee(int id);

        Task<List<EmployeeEntity>> GetAllEmployees();

        Task AddEmployee(EmployeeEntity employee);
        Task UpdateEmployee(EmployeeEntity employee);
        Task DeleteEmployee(int id);

    }
}
