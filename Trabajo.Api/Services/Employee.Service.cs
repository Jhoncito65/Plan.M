using System.Collections.Generic;
using System.Linq;
using Trabajo.Api.Models;

namespace Trabajo.Api.Services
{
    public class EmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return _context.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error obteniendo empleados", ex);
            }
        }

        public void RegisterEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error registrando empleado", ex);
            }
        }
    }
}
