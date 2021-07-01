using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VayanaProjectDataModels;
using VayanaProjectServiceContracts.BusinessModels;

namespace VayanaProjectServiceContracts
{
    public interface IEmployeeService
    {
        Task<List<Department>> GetDepartments();
        Task<List<EmployeeModel>> GetEmployees();
        Task AddUpdateEmployee(int EmpId,string EmpFirstName, string EmpMiddleName, string EmpLastName, int EmpSalary, int EmpDeptId);
        Task DeleteEmployee(int EmpId);
        Task<List<AvgSalaryModel>> AvgSalaryByDepartment();
    }
}
