namespace Microsoft.ILP2025.EmployeeCRUD.Entities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public DateTime DateOfJoining { get; set; }
        public decimal Salary { get; set; }
    }
}
