using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VayanaProjectDataModels;
using VayanaProjectServiceContracts;
using VayanaProjectServiceContracts.BusinessModels;

namespace VayanaProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet("GetDepartments")]
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            try
            {
                var depts = await _service.GetDepartments();
                return depts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetEmployees")]
        public async Task<ActionResult<List<EmployeeModel>>> GetEmployees()
        {
            try
            {
                var employees = await _service.GetEmployees();
                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("AddUpdateEmployee")]
        public async Task AddUpdateEmployee(int EmpId, string EmpFirstName, string EmpMiddleName, string EmpLastName, int EmpSalary, int EmpDeptId)
        {
            try
            {
                await _service.AddUpdateEmployee(EmpId, EmpFirstName, EmpMiddleName, EmpLastName, EmpSalary, EmpDeptId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("DeleteEmployee")]
        public async Task DeleteEmployee(int EmpId)
        {
            try
            {
                await _service.DeleteEmployee(EmpId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("AvgSalaryByDepartment")]
        public async Task<ActionResult<List<AvgSalaryModel>>> AvgSalaryByDepartment() 
        {
            try {
                var result = await _service.AvgSalaryByDepartment();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<AvgSalaryModel>();
        }

    }
}
