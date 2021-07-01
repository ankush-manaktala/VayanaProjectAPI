using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using VayanaProjectDataContracts;
using VayanaProjectServiceContracts.BusinessModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace VayanaProjectRepository
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        #region Private variables
        private readonly EmployeeContext _employeeContext;
        #endregion

        #region Constructor
        public EmployeeRepository(EmployeeContext employeeContext) : base(employeeContext)
        {
            _employeeContext = employeeContext;
        }
        #endregion

        public async Task<List<EmployeeModel>> GetEmployees()
        {
            
            return await _employeeContext.Employees.Where(x => !x.EmpIsDeleted).Select(x => new EmployeeModel
            {
                EmpId=x.EmpId,
                EmpFirstName = x.EmpFirstName,
                EmpLastName = x.EmpLastName,
                EmpMiddleName = x.EmpMiddleName,
                EmpSalary = x.EmpSalary,
                DeptName = x.EmpDept.DeptName,
                EmpDeptId=x.EmpDeptId
            }).ToListAsync();
        }


        public async Task<List<AvgSalaryModel>> AvgSalaryByDepartment()
        {
            List<AvgSalaryModel> avgSalaryModels = new List<AvgSalaryModel>();
            using (SqlConnection conn = new SqlConnection(_employeeContext.Database.GetDbConnection().ConnectionString))
            {
                SqlParameter[] sqlComm = new SqlParameter[]
                {

                };
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("usp_AvgSalaryByDepartment", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddRange(sqlComm);
                using (SqlDataReader dr = await sqlCommand.ExecuteReaderAsync())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AvgSalaryModel avgSalaryModel = new AvgSalaryModel();
                            avgSalaryModel.AvgSalary = dr["AvgSalary"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AvgSalary"]);
                            avgSalaryModel.DeptId = dr["DeptId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["DeptId"]);
                            avgSalaryModel.Department = dr["Department"] == DBNull.Value ? "" : Convert.ToString(dr["Department"]);
                            avgSalaryModels.Add(avgSalaryModel);
                        }
                    }
                }
            }
            return avgSalaryModels;
        }
    }
}
