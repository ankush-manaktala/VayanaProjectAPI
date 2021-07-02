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

        /// <summary>
        /// This method is used to get the departments list.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// This method is used to get all the employees details.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// This method is used to Add/Update Employee data.
        /// </summary>
        /// <param name="EmpId"></param>
        /// <param name="EmpFirstName"></param>
        /// <param name="EmpMiddleName"></param>
        /// <param name="EmpLastName"></param>
        /// <param name="EmpSalary"></param>
        /// <param name="EmpDeptId"></param>
        /// <returns></returns>

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

        /// <summary>
        /// This method is used to delete Employee data.
        /// </summary>
        /// <param name="EmpId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This method is used to get the Average salary per department.
        /// </summary>
        /// <returns></returns>
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
        }

    }
}
