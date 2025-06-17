using Microsoft.ILP2025.EmployeeCRUD.Entities;
using System.Text.Json;

namespace Microsoft.ILP2025.EmployeeCRUD.Repositores
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string filePath;

        public EmployeeRepository()
        {
            var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data");
            Directory.CreateDirectory(rootPath); // Ensures folder exists
            filePath = Path.Combine(rootPath, "employee.json");
        }

        public async Task<List<EmployeeEntity>> GetAllEmployees()
        {
            if (!File.Exists(filePath))
                return new List<EmployeeEntity>();

            var json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<List<EmployeeEntity>>(json) ?? new List<EmployeeEntity>();
        }

        public async Task<EmployeeEntity> GetEmployee(int id)
        {
            var employees = await GetAllEmployees();
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public async Task AddEmployee(EmployeeEntity employee)
        {
            var employees = await GetAllEmployees();
            employee.Id = employees.Count > 0 ? employees.Max(e => e.Id) + 1 : 1;
            employees.Add(employee);
            await SaveEmployees(employees);
        }

        public async Task UpdateEmployee(EmployeeEntity employee)
        {
            var employees = await GetAllEmployees();
            var index = employees.FindIndex(e => e.Id == employee.Id);
            if (index != -1)
            {
                employees[index] = employee;
                await SaveEmployees(employees);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            var employees = await GetAllEmployees();
            var employeeToRemove = employees.FirstOrDefault(e => e.Id == id);
            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
                await SaveEmployees(employees); // ← this MUST be called
            }
        }


        private async Task SaveEmployees(List<EmployeeEntity> employees)
        {
            var json = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
