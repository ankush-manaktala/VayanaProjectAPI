using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VayanaProjectServiceContracts.BusinessModels;

namespace VayanaProjectDataContracts
{
    public interface IEmployeeRepository:IBaseRepository
    {
        Task<List<EmployeeModel>> GetEmployees();
        Task<List<AvgSalaryModel>> AvgSalaryByDepartment();
    }
}
