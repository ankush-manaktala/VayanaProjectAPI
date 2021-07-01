using System;
using System.Collections.Generic;

#nullable disable

namespace VayanaProjectDataModels
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptCode { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
