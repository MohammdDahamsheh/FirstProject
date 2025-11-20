using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Responses
{
    public class EmployeeResponse
    {
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public string ReportingToEmployeeName { get; set; }
        public int TotalVacationDaysLeft { get; set; }

        public EmployeeResponse(string employeeNumber, string employeeName, string departmentName, string positionName, string reportingToEmployeeName, int totalVacationDaysLeft)
        {
            EmployeeNumber = employeeNumber;
            EmployeeName = employeeName;
            DepartmentName = departmentName;
            PositionName = positionName;
            ReportingToEmployeeName = reportingToEmployeeName;
            TotalVacationDaysLeft = totalVacationDaysLeft;
        }

        public override string? ToString()
        {
            return "Employee Number: " + EmployeeNumber + 
                ", Employee Name: " + EmployeeName + 
                ", Department: " + DepartmentName + 
                ", Position: " + PositionName + 
                ", Reporting To: " + ReportingToEmployeeName +
                ", Vacation Days Left: " + TotalVacationDaysLeft;
        }
    }
}
