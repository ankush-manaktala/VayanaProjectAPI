using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VayanaProjectDataContracts;
using VayanaProjectDataModels;
using VayanaProjectServiceContracts;
using System.Linq;
using VayanaProjectServiceContracts.BusinessModels;

namespace VayanaProjectService
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IUnitOfWork unitOfWork,IEmployeeRepository employeeRepository)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Department>> GetDepartments()
        {
            try
            {
                var depts = await _employeeRepository.GetEntityListAsync<Department>();
                return depts.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<EmployeeModel>> GetEmployees()
        {
            try
            {
                var employees = await _employeeRepository.GetEmployees();
                return employees.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<AvgSalaryModel>> AvgSalaryByDepartment()
        {
            try
            {
                var avgSalaries = await _employeeRepository.AvgSalaryByDepartment();
                return avgSalaries.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddUpdateEmployee(int EmpId,string EmpFirstName, string EmpMiddleName, string EmpLastName, int EmpSalary, int EmpDeptId)
        {
            try
            {
                if (EmpId == 0)
                {
                    Employee employeeObj = new Employee();
                    employeeObj.EmpFirstName = EmpFirstName;
                    employeeObj.EmpMiddleName = EmpMiddleName;
                    employeeObj.EmpLastName = EmpLastName;
                    employeeObj.EmpDeptId = EmpDeptId;
                    employeeObj.EmpSalary = EmpSalary;
                    employeeObj.EmpIsDeleted = false;
                    employeeObj.EmpIsActive = "Y";
                    employeeObj.EmpCreatedBy = 1;
                    employeeObj.EmpCreatedOn = DateTime.Now;
                    _employeeRepository.Add(employeeObj);
                }
                else
                {
                    Employee employeeObj = await _employeeRepository.GetEntityAsync<Employee>(x => x.EmpId == EmpId && !x.EmpIsDeleted);
                    employeeObj.EmpFirstName = EmpFirstName;
                    employeeObj.EmpMiddleName = EmpMiddleName;
                    employeeObj.EmpLastName = EmpLastName;
                    employeeObj.EmpDeptId = EmpDeptId;
                    employeeObj.EmpSalary = EmpSalary;
                    employeeObj.EmpIsDeleted = false;
                    employeeObj.EmpIsActive = "Y";
                    employeeObj.EmpModifiedBy = 2;
                    employeeObj.EmpModifiedOn = DateTime.Now;
                    _employeeRepository.Update(employeeObj);
                }
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteEmployee(int EmpId)
        {
            try
            {
                Employee employeeObj = await _employeeRepository.GetEntityAsync<Employee>(x => x.EmpId == EmpId && !x.EmpIsDeleted);
                employeeObj.EmpIsDeleted = true;
                employeeObj.EmpModifiedBy = 3;
                employeeObj.EmpModifiedOn = DateTime.Now;
                _employeeRepository.Update(employeeObj);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
