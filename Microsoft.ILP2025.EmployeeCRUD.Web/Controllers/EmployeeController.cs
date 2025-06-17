using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ILP2025.EmployeeCRUD.Repositores;
using Microsoft.ILP2025.EmployeeCRUD.Servcies;
using Microsoft.ILP2025.EmployeeCRUD.Entities;


namespace Microsoft.ILP2025.EmployeeCRUD.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public IEmployeeService employeeService { get; set; }

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            var employees = await this.employeeService.GetAllEmployees();
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var employee = await this.employeeService.GetEmployee(id);
            return View(employee);
        }

        // CREATE
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeeEntity employee)
        {
            await employeeService.AddEmployee(employee);
            return RedirectToAction(nameof(Index));
        }

        // EDIT
        public async Task<ActionResult> Edit(int id)
        {
            var employee = await employeeService.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EmployeeEntity employee)
        {
            await employeeService.UpdateEmployee(employee);
            return RedirectToAction(nameof(Index));
        }

        // DELETE
        public async Task<ActionResult> Delete(int id)
        {
            var employee = await employeeService.GetEmployee(id);
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await employeeService.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
