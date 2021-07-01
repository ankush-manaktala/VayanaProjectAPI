using System;
using System.Collections.Generic;

#nullable disable

namespace VayanaProjectDataModels
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpMiddleName { get; set; }
        public string EmpLastName { get; set; }
        public int EmpDeptId { get; set; }
        public int EmpSalary { get; set; }
        public string EmpIsActive { get; set; }
        public bool EmpIsDeleted { get; set; }
        public DateTime EmpCreatedOn { get; set; }
        public int EmpCreatedBy { get; set; }
        public DateTime? EmpModifiedOn { get; set; }
        public int? EmpModifiedBy { get; set; }

        public virtual Department EmpDept { get; set; }
    }
}
