using Microsoft.AspNetCore.Mvc;
using Trabajo.Api.Models;
using Trabajo.Api.Services;
using System;
using System.Collections.Generic;

namespace Trabajo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("Register")]
        public IActionResult RegisterEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Datos del empleado no válidos");
            }

            try
            {
                // Intenta registrar al empleado mediante el servicio
                _employeeService.RegisterEmployee(employee);
                return Ok(new { message = "Empleado creado con éxito" });
            }
            catch (Exception ex)
            {
                // Agregar el log de la excepción para diagnóstico
                Console.WriteLine(ex.ToString()); // Cambia a ILogger en producción

                // Retornar el error 500 con mensaje personalizado
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("GetEmployees")]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
                // Obtener lista de empleados a través del servicio
                var employees = _employeeService.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                // Agregar log de excepción en caso de error
                Console.WriteLine(ex.ToString()); // Cambia a ILogger en producción
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
