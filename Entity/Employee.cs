using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Entity
{
    public class Employee
    {
        [Key]
        [MaxLength(6)]
        [Required]
        public string EmployeeNumber { get; set; }
        [Required]
        [MaxLength(20)]
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        
        public int PositionId { get; set; }

        public char GenderCode{get; set;}
        [MaxLength(6)]
        public string ?ReportedToEmployeeNumber { get; set; }

        [Range(1, 24)]
        public int VacationDaysLeft { get; set; } = 24;

        [Column(TypeName = "decimal(10,2)")]
        public double Salary { get; set; }

        public Position position { get; set; }
        public Department department { get; set; }

        public LinkedList<VacationRequest> VacationRequests { get; set; }
        public Employee(string employeeNumber, string employeeName, int departmentId, int positionId, char genderCode, string? reportedToEmployeeNumber, int vacationDaysLeft, double salary)
        {
            EmployeeNumber = employeeNumber;
            EmployeeName = employeeName;
            DepartmentId = departmentId;
            PositionId = positionId;
            GenderCode = genderCode;
            ReportedToEmployeeNumber = reportedToEmployeeNumber;
            VacationDaysLeft = vacationDaysLeft;
            Salary = salary;
        }

        public Employee(string employeeNumber, string employeeName, int departmentId, int positionId, char genderCode, string? reportedToEmployeeNumber, double salary)
        {
            EmployeeNumber = employeeNumber;
            EmployeeName = employeeName;
            DepartmentId = departmentId;
            PositionId = positionId;
            GenderCode = genderCode;
            ReportedToEmployeeNumber = reportedToEmployeeNumber;
            Salary = salary;

        }
    }
}
