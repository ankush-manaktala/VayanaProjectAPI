using System;
using System.Collections.Generic;
using System.Text;

namespace VayanaProjectServiceContracts.BusinessModels
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpMiddleName { get; set; }
        public string EmpLastName { get; set; }
        public int EmpDeptId { get; set; }
        public int EmpSalary { get; set; }
        public string DeptName { get; set; }
    }
}
